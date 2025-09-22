 using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FacilitiesManagementAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesManagementAPI.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            if ( await userManager.Users.AnyAsync()) return;

            //var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            //var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            //if(users == null) return;

            var roles = new List<AppRole>
            {
                new AppRole{Name = "Admin"},
                new AppRole{Name = "Member"},
                new AppRole{Name = "SuperUser"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            //foreach ( var user in users)
            //{ 
            //    user.UserName = user.UserName.ToLower();
 
            //  await userManager.CreateAsync(user, "Pa$$w0rd");
            //  await userManager.AddToRoleAsync(user, "Member");
            //}

            var admin = new AppUser
            {
                UserName = "chrissy@blackwoodpm.com",
                Email = "chrissy@blackwoodpm.com",
                KnownAs = "Chrissy"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] { "Admin" });

            var superUser = new AppUser
            {
                UserName = "alder83@hotmail.co.uk",
                Email= "alder83@hotmail.co.uk",
                KnownAs= "Chris"
            };
            
            await userManager.CreateAsync(superUser, "2512Blane4697!");
            await userManager.AddToRolesAsync(superUser, new[] { "SuperUser", "Admin"});

        }

        //public static async Task SeedPremisesAsync(DataContext context)
        //{
        //    if (await context.Premises.AnyAsync()) return;

        //    var premiseData = await System.IO.File.ReadAllTextAsync("Data/PremisesSeedData.json");
        //    var premises = JsonSerializer.Deserialize<List<Premises>>(premiseData);
        //    foreach (var premise in premises)
        //    {
        //        context.Premises.Add(premise);
        //    }
        //    context.SaveChanges();
        //}

        //public static async Task SeedContractor(DataContext context)
        //{
        //    if( await context.Contractors.AnyAsync()) return;
        //    var contractorData = await System.IO.File.ReadAllTextAsync("Data/contractorSeed.json");
        //    var contractors = JsonSerializer.Deserialize<List<Contractor>>(contractorData);
        //    foreach (var contractor in contractors)
        //    {
        //        context.Contractors.Add(contractor);
        //    }
        //    context.SaveChanges();
        //}

        public static async Task SeedContractorType(DataContext context)
        {
            if (await context.ContractorTypes.AnyAsync()) return;

            var contractorTypeData = await System.IO.File.ReadAllTextAsync("Data/ContractorType.json");
            var conTypes = JsonSerializer.Deserialize<List<ContractorType>>(contractorTypeData);

            if (conTypes == null || !conTypes.Any()) return;

            await context.ContractorTypes.AddRangeAsync(conTypes);
            await context.SaveChangesAsync();
        }
    }
}