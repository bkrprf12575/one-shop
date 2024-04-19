// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OneShop.ServiceDefaults.Permissions
{
    public class PermissionDefinition
    {
        /// <summary>
        /// Unique name of the permission.
        /// </summary>
        public string Name { get; } = default!;


        public string? DisplayName { get; set; }

        /// <summary>
        /// Parent of this permission if one exists.
        /// If set, this permission can be granted only if parent is granted.
        /// </summary>
        public PermissionDefinition? Parent { get; private set; }

        /// <summary>
        /// Indicates whether this permission is enabled or disabled.
        /// A permission is normally enabled.
        /// A disabled permission can not be granted to anyone, but it is still
        /// will be available to check its value (while it will always be false).
        ///
        /// Disabling a permission would be helpful to hide a related application
        /// functionality from users/clients.
        ///
        /// Default: true.
        /// </summary>
        public bool IsEnabled { get; set; }

        private readonly List<PermissionDefinition> _children = [];

        public IReadOnlyList<PermissionDefinition> Children => [.. _children];

        protected internal PermissionDefinition(string name, string? displayName = null, bool isEnabled = true)
        {
            Name = name;
            DisplayName = displayName;
            IsEnabled = isEnabled;
        }

        public virtual PermissionDefinition AddChild(string name, string? displayName = null, bool isEnabled = true)
        {
            var child = new PermissionDefinition(name, displayName, isEnabled) { Parent = this };

            _children.Add(child);

            return child;
        }
    }
}
