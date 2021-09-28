using FacilitiesManagementAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesManagementAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }   

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Premises> Premises { get; set; }
        public DbSet<ContractorType> ContractorTypes { get; set; }
    }
}