// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OneShop.ServiceDefaults.Models.Permissions
{
    public class PermissionGroupDefinitionResponse
    {
        public required string Name { get; init; }

        public string? DisplayName { get; set; }

        public required List<PermissionDefinitionResponse> Permissions { get; init; }
    }
}
