using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using __Module__.Application.Interfaces;
using __Module__.Application.Services;
using __Module__.Domain.Interfaces;
using __Module__.Infrastructure.Persistence.Context;
using __Module__.Infrastructure.Repositories;
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
builder.Services.AddDbContext<__Module__DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("__Module__Connection")));

// Registrar repositorios y servicios del módulo aquí
// builder.Services.AddScoped<IRoleRepository, RoleRepository>();
// builder.Services.AddScoped<IRoleService, RoleService>();



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
            IssuerSigningKey = new Symmetric__Module__Key(Encoding.UTF8.GetBytes(key)),
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