// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace OneShop.IdentityService.EntityFrameworks.EntityConfigurations
{
    public class UserLoginEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUserLogin<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<int>> builder)
        {
            builder.ToTable("UserLogins");

            builder.Property(ul => ul.LoginProvider).HasMaxLength(16);
            builder.Property(ul => ul.ProviderDisplayName).HasMaxLength(16);
        }
    }
}
