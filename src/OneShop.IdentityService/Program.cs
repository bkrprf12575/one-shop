using Microsoft.EntityFrameworkCore;
using OneShop.IdentityService.Constants;
using OneShop.IdentityService.EntityFrameworks;
using OneShop.ServiceDefaults.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityServiceDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(DbConstants.ConnectionStringName));
});

builder.Services.AddDataSeedingProviders();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDataSeedingProviders();

app.Run();
