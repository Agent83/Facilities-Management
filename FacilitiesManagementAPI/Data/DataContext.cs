using FacilitiesManagementAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace FacilitiesManagementAPI.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid,
        IdentityUserClaim<Guid>, AppUserRole, IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
       
        public DataContext(DbContextOptions options) : base(options)
        {

        }
       
        public DbSet<Note> Note {  get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Accountant> Accountant { get; set; }
        public DbSet<Premises> Premises { get; set; }
        public DbSet<PremisesTask> PremisesTask {  get; set; }
        public DbSet<ContractorType> ContractorTypes { get; set; }
        public DbSet<PremisesContractor> PremisesContractors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();


            modelBuilder.Entity<Premises>().HasMany(x => x.Contractors)
                    .WithMany(x => x.Premises)
                    .UsingEntity<PremisesContractor>(
                        x => x.HasOne(x => x.Contractor)
                        .WithMany().HasForeignKey(x => x.ContractorId),
                        x => x.HasOne(x => x.Premises)
                       .WithMany().HasForeignKey(x => x.PremisesId));
        }
    }

}