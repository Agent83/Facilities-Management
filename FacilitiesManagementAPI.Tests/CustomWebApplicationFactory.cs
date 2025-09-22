using FacilitiesManagementAPI.Controllers;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FacilitiesManagementAPI.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public CustomWebApplicationFactory()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");
    }

    public Guid ExistingNoteId { get; } = Guid.Parse("c3b733e5-a3d6-4b25-a66a-8b57f5c39274");
    public Guid SecondaryNoteId { get; } = Guid.Parse("b6f4c785-8b4a-42aa-bbb4-97579b0c12f5");

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.UseSetting(WebHostDefaults.EnvironmentKey, "Testing");

        builder.ConfigureAppConfiguration((context, configurationBuilder) =>
        {
            var settings = new Dictionary<string, string?>
            {
                ["TokenKey"] = "super_secret_testing_token_key"
            };

            configurationBuilder.AddInMemoryCollection(settings);
        });

        builder.ConfigureServices(services =>
        {
            services.AddControllers().AddApplicationPart(typeof(NoteController).Assembly);

            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<DataContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DataContext));
            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase("FacilitiesManagementApiTests");
            });

            var sp = services.BuildServiceProvider();

            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<DataContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            SeedDatabase(context);
        });
    }

    private void SeedDatabase(DataContext context)
    {
        if (context.Note.Any())
        {
            return;
        }

        var premisesId = Guid.Parse("5f43a2df-64a0-4c29-832b-bf6cfdc45d78");

        var firstNote = new Note
        {
            Id = ExistingNoteId,
            NoteContent = "Routine safety inspection completed.",
            IsPerm = true,
            IsDeleted = false,
            PremisesId = premisesId,
            DateCreated = DateTime.SpecifyKind(new DateTime(2024, 1, 1, 8, 30, 0), DateTimeKind.Utc)
        };

        var secondNote = new Note
        {
            Id = SecondaryNoteId,
            NoteContent = "Follow-up scheduled for next week.",
            IsPerm = false,
            IsDeleted = false,
            PremisesId = premisesId,
            DateCreated = DateTime.SpecifyKind(new DateTime(2024, 1, 2, 9, 45, 0), DateTimeKind.Utc)
        };

        context.Note.AddRange(firstNote, secondNote);
        context.SaveChanges();
    }
}
