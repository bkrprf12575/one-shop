// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using OneShop.IdentityService.Entities;

namespace OneShop.IdentityService.Authentication
{
    public static class CustomJwtBearerExtensions
    {
        public static AuthenticationBuilder AddCustomJwtBearer(this AuthenticationBuilder builder) => builder.AddCustomJwtBearer(CustomJwtBearerDefaults.AuthenticationScheme);

        public static AuthenticationBuilder AddCustomJwtBearer(this AuthenticationBuilder builder, string authenticationScheme) => builder.AddCustomJwtBearer(authenticationScheme, _ => { });

        public static AuthenticationBuilder AddCustomJwtBearer(this AuthenticationBuilder builder, Action<CustomJwtBearerOptions> configure) => builder.AddCustomJwtBearer(CustomJwtBearerDefaults.AuthenticationScheme, configure);

        public static AuthenticationBuilder AddCustomJwtBearer(this AuthenticationBuilder builder, string authenticationScheme, Action<CustomJwtBearerOptions> configure)
        {
            ArgumentNullException.ThrowIfNull(builder);
            ArgumentNullException.ThrowIfNull(authenticationScheme);
            ArgumentNullException.ThrowIfNull(configure);

            builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomUserClaimsPrincipalFactory<User, Role>>();

            return builder.AddScheme<CustomJwtBearerOptions, CustomJwtBearerHandler>(authenticationScheme, configure);
        }
    }
}
