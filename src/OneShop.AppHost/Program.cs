// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.OneShop_ApiService>("api-service");

builder.AddProject<Projects.OneShop_WebApp>("webfrontend")
    .WithReference(apiService);

builder.AddProject<Projects.OneShop_IdentityService>("identity-service");

builder.AddProject<Projects.OneShop_OrderingService>("ordering-service");

builder.AddProject<Projects.OneShop_ProductService>("product-service");

builder.AddProject<Projects.OneShop_BasketService>("basket-service");

builder.Build().Run();
