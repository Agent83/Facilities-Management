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
    }
}