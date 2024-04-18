// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace OneShop.IdentityService.Models.Accounts
{
    public class AccountLoginRequest
    {
        public required string UserName { get; init; }

        public required string Password { get; init; }

        [JsonIgnore]
        public string? TwoFactorCode { get; init; }

        [JsonIgnore]
        public string? TwoFactorRecoveryCode { get; init; }
    }
}
