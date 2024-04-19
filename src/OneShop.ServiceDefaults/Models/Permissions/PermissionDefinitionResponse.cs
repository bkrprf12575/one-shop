// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OneShop.ServiceDefaults.Models.Permissions
{
    public class PermissionDefinitionResponse
    {
        public required string Name { get; init; }

        public string? DisplayName { get; set; }

        public string? ParentName { get; set; }
    }
}
