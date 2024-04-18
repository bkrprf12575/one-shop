// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Identity;

namespace OneShop.IdentityService.Entities
{
    public class User : IdentityUser<int>
    {
        public DateTimeOffset CreationTime { get; init; } = TimeProvider.System.GetLocalNow();
    }
}
