using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FacilitiesManagementAPI.Tests;

public class SeedTests
{
    [Fact]
    public async Task SeedContractorType_AddsTypesWhenMissingEvenIfContractorsExist()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using var context = new DataContext(options);
        context.Contractors.Add(new Contractor
        {
            Id = Guid.NewGuid(),
            BusinessName = "Test Business",
            FirstName = "Test",
            LastName = "Contractor",
            GreenLightEnum = "Green",
            PhoneNumber1 = "1234567890",
            Email = "test@example.com",
            IsDeleted = false
        });
        await context.SaveChangesAsync();

        using (UseSeedDataDirectory())
        {
            await Seed.SeedContractorType(context);
        }

        var contractorTypes = await context.ContractorTypes.ToListAsync();

        Assert.NotEmpty(contractorTypes);
        Assert.Contains(contractorTypes, type => type.TypeDescription == "Plumber");
    }

    [Fact]
    public async Task SeedContractorType_SkipsWhenTypesAlreadyExist()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        await using var context = new DataContext(options);
        context.ContractorTypes.Add(new ContractorType
        {
            Id = 1,
            TypeDescription = "Existing",
            IsDeleted = false
        });
        await context.SaveChangesAsync();

        using (UseSeedDataDirectory())
        {
            await Seed.SeedContractorType(context);
        }

        var contractorTypes = await context.ContractorTypes.ToListAsync();

        Assert.Single(contractorTypes);
        Assert.Equal("Existing", contractorTypes[0].TypeDescription);
    }

    private static IDisposable UseSeedDataDirectory()
    {
        var originalDirectory = Directory.GetCurrentDirectory();
        var projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "FacilitiesManagementAPI"));
        Directory.SetCurrentDirectory(projectDirectory);
        return new DirectoryScope(originalDirectory);
    }

    private sealed class DirectoryScope : IDisposable
    {
        private readonly string _originalDirectory;
        private bool _disposed;

        public DirectoryScope(string originalDirectory)
        {
            _originalDirectory = originalDirectory;
        }

        public void Dispose()
        {
            if (_disposed) return;

            Directory.SetCurrentDirectory(_originalDirectory);
            _disposed = true;
        }
    }
}
