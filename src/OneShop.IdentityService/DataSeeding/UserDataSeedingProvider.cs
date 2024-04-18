// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneShop.IdentityService.Entities;
using OneShop.IdentityService.EntityFrameworks;
using OneShop.ServiceDefaults.Infrastructure;

namespace OneShop.IdentityService.DataSeeding
{
    public class UserDataSeedingProvider(UserManager<User> userManager, RoleManager<Role> roleManager) : IDataSeedingProvider
    {
        public async Task SeedingAsync(IServiceProvider ServiceProvider)
        {
            var adminRole = await roleManager.Roles.SingleOrDefaultAsync(x => x.Name == "AdminRole");
            if (adminRole == null)
            {
                adminRole = new Role { Name = "AdminRole", };
                await roleManager.CreateAsync(adminRole);
            }

            var guestRole = await roleManager.Roles.SingleOrDefaultAsync(x => x.Name == "GuestRole");
            if (guestRole == null)
            {
                guestRole = new Role { Name = "GuestRole", };
                await roleManager.CreateAsync(guestRole);
            }

            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "admin",
                    Email = "admin@oneshop.com"
                };
                await userManager.CreateAsync(adminUser, adminUser.UserName);
            }

            await userManager.AddToRolesAsync(adminUser, ["AdminRole", "GuestRole"]);

            var guestUser = await userManager.FindByNameAsync("guest");
            if (guestUser == null)
            {
                guestUser = new User
                {
                    UserName = "guest",
                    Email = "guest@oneshop.com"
                };
                await userManager.CreateAsync(guestUser, guestUser.UserName);
            }

            await userManager.AddToRoleAsync(guestUser, "GuestRole");

            if (userManager.Users.Count() < 30)
            {
                for (int i = 0; i < 30; i++)
                {
                    var user = new User
                    {
                        UserName = $"user{i}",
                        Email = $"oneshop{i}@oneshop.com",
                    };
                    await userManager.CreateAsync(user, user.UserName);
                }
            }
        }
    }
}
