// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OneShop.ServiceDefaults.Permissions
{
    public interface IPermissionDefinitionManager
    {
        Task<PermissionDefinition> GetAsync(string name);

        Task<PermissionDefinition?> GetOrNullAsync(string name);

        Task<IReadOnlyList<PermissionDefinition>> GetPermissionsAsync();

        Task<IReadOnlyList<PermissionGroupDefinition>> GetGroupsAsync();
    }
}
