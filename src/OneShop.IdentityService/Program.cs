// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.EntityFrameworkCore;
using OneShop.IdentityService.Constants;
using OneShop.IdentityService.EntityFrameworks;
using OneShop.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDataSeedingProviders();
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddDbContext<IdentityServiceDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(DbConstants.ConnectionStringName));
});

var app = builder.Build();

app.UseDataSeedingProviders();

app.MapDefaultEndpoints();

app.UseOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
