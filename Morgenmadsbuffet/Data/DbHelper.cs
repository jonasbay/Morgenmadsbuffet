using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Morgenmadsbuffet.Models;

namespace Morgenmadsbuffet.Data
{
    public class DbHelper
    {
        public static void SeedData(ApplicationDbContext db, UserManager<ApplicationUser> userManager, ILogger log)
        {
            SeedUsers(userManager, log);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager, ILogger log)
        {
            const string adminEmail = "admin@hotmail.dk";
            const string adminPassword = "Hej123!";

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                log.LogWarning("Seeding the admin user");
                var user = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Name = "Admin",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync
                    (user, adminPassword).Result;
                
                if (result.Succeeded)
                {
                    userManager.AddClaimAsync(user, new Claim("Admin", "Yes")).Wait();
                    userManager.AddClaimAsync(user, new Claim("Kitchen", "Yes")).Wait();
                    userManager.AddClaimAsync(user, new Claim("Receptionist", "Yes")).Wait();
                    userManager.AddClaimAsync(user, new Claim("Restaurant", "Yes")).Wait();
                }
            }
        }
    }
}
