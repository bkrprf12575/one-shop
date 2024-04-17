// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OneShop.IdentityService.Entities;

namespace OneShop.IdentityService.EntityFrameworks.EntityConfigurations
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.Property(r => r.Id).HasColumnOrder(1);
            builder.Property(r => r.Name).HasMaxLength(16).HasColumnOrder(2);
            builder.Property(r => r.NormalizedName).HasMaxLength(16).HasColumnOrder(3);
            builder.Property(r => r.ConcurrencyStamp).HasMaxLength(64).HasColumnOrder(4);
            builder.Property(r => r.CreationTime).HasColumnOrder(5);
        }
    }
}
