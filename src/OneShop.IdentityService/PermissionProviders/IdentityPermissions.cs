// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OneShop.IdentityService.PermissionProviders
{
    public static class IdentityPermissions
    {
        public const string GroupName = "Identity";

        public static class Roles
        {
            public const string Default = GroupName + ".Roles";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
            public const string ManageRoles = Default + ".ManageRoles";
        }

        public static class Users
        {
            public const string Default = GroupName + ".Users";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
            public const string ManageUsers = Update + ".ManageUsers";
        }
    }
}
