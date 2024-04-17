// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Mvc;
using OneShop.IdentityService.Entities;
using OneShop.IdentityService.EntityFrameworks;

namespace OneShop.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IdentityServiceDbContext dbContext)
        : ControllerBase
    {
        [HttpGet("{id}")]
        public User? Get(int id)
        {
            return dbContext.Set<User>().Find(id);
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            dbContext.Set<User>().Add(user);
            dbContext.SaveChanges();
        }
    }
}
