// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

namespace OneShop.ServiceDefaults.Infrastructure
{
    public interface IDataSeedingProvider
    {
        int Order => default;

        Task SeedingAsync(IServiceProvider serviceProvider);
    }
}
