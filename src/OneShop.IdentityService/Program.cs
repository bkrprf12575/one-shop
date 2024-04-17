// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.EntityFrameworkCore;
using OneShop.IdentityService.Constants;
using OneShop.IdentityService.Entities;
using OneShop.IdentityService.EntityFrameworks;
using OneShop.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDataSeedingProviders();
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddIdentityApiEndpoints<User>(
    options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 5;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<IdentityServiceDbContext>();

builder.Services.AddDbContext<IdentityServiceDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(DbConstants.ConnectionStringName));
});

var app = builder.Build();

app.UseDataSeedingProviders();

app.MapDefaultEndpoints();

app.MapGroup("identity")
    .MapIdentityApi<User>();

app.UseOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
