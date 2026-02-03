using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReceptionFresh.Application.Interfaces;
using ReceptionFresh.Application.Services;
using ReceptionFresh.Domain.Interfaces;
using ReceptionFresh.Infrastructure.Persistence.Context;
using ReceptionFresh.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    // Filtros globales si los usas
    // options.Filters.Add<ValidationFilter>(); 
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: Registrar DbContext del módulo aquí
builder.Services.AddDbContext<ReceptionFreshDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReceptionFreshConnection")));

// Registrar repositorios y servicios del módulo aquí
 builder.Services.AddScoped<IPalletRepository, PalletRepository>();
 builder.Services.AddScoped<IPalletService, PalletService>();



// Configurar autenticación JWT que apunta al proveedor de identidad
var jwtSection = builder.Configuration.GetSection("Jwt");
var issuer = jwtSection["Issuer"];
var audience = jwtSection["Audience"];
var key = jwtSection["Key"];

if (string.IsNullOrWhiteSpace(key))
{
    throw new InvalidOperationException("Jwt:Key no está configurada.");
}

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ClockSkew = TimeSpan.FromMinutes(1)
        };
    });
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();