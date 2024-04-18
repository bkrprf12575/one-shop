// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace OneShop.IdentityService.Authentication
{
    public class CustomJwtBearerOptions : AuthenticationSchemeOptions
    {
        public TimeSpan AccessTokenExpiration { get; set; } = TimeSpan.FromHours(1);

        public TimeSpan RefreshTokenExpiration { get; set; } = TimeSpan.FromDays(14);

        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256;

        public string IssuerSigningKey { get; set; } = default!;

        public string Issuer { get; set; } = default!;

        public string Audience { get; set; } = default!;
    }
}
