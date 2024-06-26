﻿// Copyright (c) OneShop Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OneShop.ServiceDefaults.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace OneShop.ServiceDefaults.Extensions
{
    public static class OpenApiExtensions
    {
        public static IServiceCollection AddOpenApi(this IServiceCollection services, Action<SwaggerGenOptions>? configureOptions = null)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(configureOptions);

            services.Configure<SwaggerGenOptions>(options =>
            {
                options.OperationFilter<AcceptLanguageHeaderOperationFilter>();

                options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app, Action<SwaggerOptions>? apiConfigureOptions = null, Action<SwaggerUIOptions>? uiConfigureOptions = null)
        {
            app.UseSwagger(apiConfigureOptions);
            app.UseSwaggerUI(uiConfigureOptions);

            return app;
        }
    }
}