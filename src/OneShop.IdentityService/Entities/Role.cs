// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Identity;

namespace OneShop.IdentityService.Entities
{
    public class Role : IdentityRole<int>
    {
        public DateTimeOffset CreationTime { get; set; } = TimeProvider.System.GetUtcNow();

    }
}
