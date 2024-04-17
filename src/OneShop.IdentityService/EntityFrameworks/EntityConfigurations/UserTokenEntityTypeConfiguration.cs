// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace OneShop.IdentityService.EntityFrameworks.EntityConfigurations
{
    public class UserTokenEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserToken<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder)
        {
            builder.ToTable("UserTokens");

            builder.Property(ut => ut.Name).HasMaxLength(16);
            builder.Property(ut => ut.LoginProvider).HasMaxLength(16);
        }
    }
}
