using HumanResource.Aplication.Interfaces;
using HumanResource.Aplication.Services;
using HumanResource.Domain.Interfaces;
using HumanResource.Infrastructure.Persistence;
using HumanResource.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text;
using CommonClass.Response;

var builder = WebApplication.CreateBuilder(args);

// 1. Localización (para validaciones en español)
builder.Services.AddLocalization();

// 2. Controllers y comportamiento de API
builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Formateo de errores de validación con BaseResponse
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            var response = new BaseResponse(
                isSuccess: false,
                message: "Se encontraron uno o más errores de validación.",
                errors: errors,
                statusCode: 400
            );

            return new BadRequestObjectResult(response);
        };
    });

// 3. Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4. DbContext de HumanResource
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HR_Connection")));
builder.Services.AddDbContext<ContractDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HR_Connection")));

// 5. Inyección de Dependencias (DI) para HumanResource
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IContractService, ContractService>();

// 6. Autenticación JWT (este servicio CONSUME tokens, no los crea)
// La configuración es la misma que en AuthService, porque debe confiar en el mismo emisor.
var jwtSection = builder.Configuration.GetSection("Jwt");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSection["Issuer"],
        ValidAudience = jwtSection["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["Key"]))
    };
});

var app = builder.Build();

// --- Pipeline de Middlewares ---

// Cultura por defecto
var supportedCultures = new[] { new CultureInfo("es-ES") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("es-ES"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// MUY IMPORTANTE: Activar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();