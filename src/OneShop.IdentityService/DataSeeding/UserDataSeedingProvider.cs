// Copyright (c) HelloShop Corporation. All rights reserved.
// See the license file in the project root for more information.

using Microsoft.AspNetCore.Identity;
using OneShop.IdentityService.Entities;
using OneShop.IdentityService.EntityFrameworks;
using OneShop.ServiceDefaults.Infrastructure;

namespace OneShop.IdentityService.DataSeeding
{
    public class UserDataSeedingProvider(IdentityServiceDbContext dbContext) : IDataSeedingProvider
    {
        public async Task SeedingAsync(IServiceProvider serviceProvider)
        {
            var guestUser = dbContext.Set<User>().SingleOrDefault(x => x.UserName == "guest");

            if (guestUser is null)
            {
                await dbContext.Set<User>().AddAsync(new User
                {
                    UserName = "guest",
                    PasswordHash = "AQAAAAEAACcQAAAAEJ"
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
