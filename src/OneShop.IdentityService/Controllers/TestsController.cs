// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OneShop.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet(nameof(Foo))]
        [Authorize(Roles = "AdminRole")]
        public IActionResult Foo()
        {
            return Ok("Hello, World!");
        }

        [HttpGet(nameof(Bar))]
        [Authorize(Roles = "GuestRole")]
        public IActionResult Bar()
        {
            return Ok("Hello, World!");
        }

        [HttpGet(nameof(Baz))]
        public IActionResult Baz()
        {
            return Ok("Hello, World!");
        }
    }
}
