using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FacilitiesManagementAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilitiesManagementAPI.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if ( await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach ( var user in users)
            {
                using var hmac = new HMACSHA512();
                user.Username = user.Username.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }
            context.SaveChanges();
        }

        public static async Task SeedPremisesAsync(DataContext context)
        {
            if (await context.Premises.AnyAsync()) return;

            var premiseData = await System.IO.File.ReadAllTextAsync("Data/PremisesSeedData.json");
            var premises = JsonSerializer.Deserialize<List<Premises>>(premiseData);
            foreach (var premise in premises)
            {
                context.Premises.Add(premise);
            }
            context.SaveChanges();
        }
    }
}