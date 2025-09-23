
var builder = WebApplication.CreateBuilder();

// add services to the container

builder.Services.AddApplicationServices(builder.Configuration);
try
{
    builder.Services.AddIdentityService(builder.Configuration);
}
catch (Exception ex)
{
    builder.Logging.AddConsole();
    var logger = LoggerFactory.Create(b => b.AddConsole()).CreateLogger("Startup");
    logger.LogCritical(ex, "Fatal config error: JWT TokenKey missing/invalid.");
    throw; 
}
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddCors();

// config Http Request pipeline
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

if (!app.Environment.IsEnvironment("Testing"))
{
    app.MapFallbackToController("Index", "Fallback");
}

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    if (!string.Equals(context.Database.ProviderName, "Microsoft.EntityFrameworkCore.InMemory", StringComparison.Ordinal))
    {
        await context.Database.MigrateAsync();
        await Seed.SeedUsers(userManager, roleManager);
        await Seed.SeedContractorType(context);
    }
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

await app.RunAsync();

public partial class Program
{
}
