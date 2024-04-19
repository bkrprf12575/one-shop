// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OneShop.ServiceDefaults.Permissions
{
    public interface IPermissionDefinitionProvider
    {
        void Define(PermissionDefinitionContext context);
    }
}
