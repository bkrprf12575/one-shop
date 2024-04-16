﻿// Copyright (c) HelloShop Corporation. All rights reserved.
// See the license file in the project root for more information.

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneShop.IdentityService.Entities;

namespace OneShop.IdentityService.EntityFrameworks.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(u => u.Id).HasColumnOrder(1);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreationTime);
        }
    }
}