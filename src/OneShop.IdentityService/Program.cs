// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OneShop.IdentityService.Authentication;
using OneShop.IdentityService.Constants;
using OneShop.IdentityService.Entities;
using OneShop.IdentityService.EntityFrameworks;
using OneShop.ServiceDefaults.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDataSeedingProviders();
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddDbContext<IdentityServiceDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(DbConstants.ConnectionStringName));
});

builder.Services.AddIdentity<User, Role>(
        options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 5;
            options.SignIn.RequireConfirmedAccount = false;
            options.ClaimsIdentity.SecurityStampClaimType = "securitystamp";
        })
    .AddEntityFrameworkStores<IdentityServiceDbContext>();

const string issuerSigningKey = OneShop.ServiceDefaults.Constants.IdentityConstants.IssuerSigningKey;

builder.Services.AddAuthentication(
        options =>
        {
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CustomJwtBearerDefaults.AuthenticationScheme;
        })
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters.ValidateIssuer = false;
            options.TokenValidationParameters.ValidateAudience = false;
            options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(issuerSigningKey));
        })
    .AddCustomJwtBearer(
        options =>
        {
            options.IssuerSigningKey = issuerSigningKey;
            options.SecurityAlgorithm = SecurityAlgorithms.HmacSha256;
        });

var app = builder.Build();

app.UseDataSeedingProviders();

app.MapDefaultEndpoints();

app.UseOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
