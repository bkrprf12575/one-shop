﻿// Copyright (c) HelloShop Corporation. All rights reserved.
// See the license file in the project root for more information.

namespace OneShop.ServiceDefaults.Infrastructure
{
    public interface IDataSeedingProvider
    {
        int Order => default;

        Task SeedingAsync(IServiceProvider serviceProvider);
    }
}
