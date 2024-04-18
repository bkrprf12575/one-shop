// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OneShop.IdentityService.Models.Accounts
{
    public class AccountRefreshRequest
    {
        public required string RefreshToken { get; init; }
    }
}
