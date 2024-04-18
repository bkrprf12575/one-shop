// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OneShop.IdentityService.Models.Accounts
{
    public class AccountRegisterRequest
    {
        public required string UserName { get; init; }

        public required string Password { get; init; }

        public string? Email { get; init; }
    }
}
