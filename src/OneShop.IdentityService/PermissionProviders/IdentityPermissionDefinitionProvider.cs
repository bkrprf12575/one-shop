// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using OneShop.ServiceDefaults.Permissions;

namespace OneShop.IdentityService.PermissionProviders
{
    public class IdentityPermissionDefinitionProvider : IPermissionDefinitionProvider
    {
        public void Define(PermissionDefinitionContext context)
        {
            var identityGroup = context.AddGroup(IdentityPermissions.GroupName, "角色身份");

            var roles = identityGroup.AddPermission(IdentityPermissions.Roles.Default, "角色管理");
            roles.AddChild(IdentityPermissions.Roles.Create, "创建角色");
            roles.AddChild(IdentityPermissions.Roles.Update, "更新角色");
            roles.AddChild(IdentityPermissions.Roles.Delete, "删除角色");
            roles.AddChild(IdentityPermissions.Roles.ManageRoles, "管理角色");

            var users = identityGroup.AddPermission(IdentityPermissions.Users.Default, "用户管理");
            users.AddChild(IdentityPermissions.Users.Create, "创建用户");
            users.AddChild(IdentityPermissions.Users.Update, "更新用户");
            users.AddChild(IdentityPermissions.Users.Delete, "删除用户");
            users.AddChild(IdentityPermissions.Users.ManageUsers, "管理用户");
        }
    }
}
