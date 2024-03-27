var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.OneShop_ApiService>("oneshop-apiservice");

builder.AddProject<Projects.OneShop_WebApp>("oneshop-webfrontend")
    .WithReference(apiService);

builder.AddProject<Projects.OneShop_IdentityService>("oneshop-identityservice");

builder.AddProject<Projects.OneShop_OrderingService>("oneshop-orderingservice");

builder.AddProject<Projects.OneShop_ProductService>("oneshop-productservice");

builder.AddProject<Projects.OneShop_BasketService>("oneshop-basketservice");

builder.Build().Run();
