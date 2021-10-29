using FacilitiesManagementAPI.Data;
using FacilitiesManagementAPI.Helpers;
using FacilitiesManagementAPI.Interfaces;
using FacilitiesManagementAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FacilitiesManagementAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPremiseRepository, PremiseRepository>();
            services.AddScoped<IPremisesTaskRepository, PremisesTaskRepository>();
            services.AddScoped<IContractorRepository, ContractorRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<IAccountantRepository, AccountantRepository>();
            services.AddScoped<IContractorTypeRepository, ContractorTypeRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}