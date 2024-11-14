using System.Text;
using BuberBreakfast.Authentication;
using BuberBreakfast.Common.Interfaces.Authentication;
using BuberBreakfast.Interfaces.Persistance;
using BuberBreakfast.Interfaces.Persistence;
using BuberBreakfast.Persistance;
using BuberBreakfast.Persistance.Repository;
using BuberBreakfast.Services.Authentication;
using BuberBreakfast.Services.Breakfast;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

ConfigurationManager configurationManager = new();
configurationManager.SetBasePath(Directory.GetCurrentDirectory());
configurationManager.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var jwtSettings = new JwtSettings();
configurationManager.Bind("JwtSettings", jwtSettings);
var builder = WebApplication.CreateBuilder(args);

// Rejestracja usług
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();  // Rejestracja usług kontrolerów
builder.Services.AddScoped<IBreakfastService, BreakfastService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();
builder.Services.AddScoped<IBreakfastRepository, SqlBreakfastRepository>();
// builder.Services.Configure<JwtSettings>(configurationManager.GetSection("JwtSettings"));
builder.Services.AddSingleton(Options.Create(jwtSettings));
builder.Services.AddDbContext<BuberBreakfastDbContext>(options =>
    options.UseSqlite("Data Source=BuberBreakfast.db"));



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
    };
});
var app = builder.Build();

// Konfiguracja aplikacji
app.UseExceptionHandler("/error"); // obsługa exceptions
app.UseSwagger();  // Użycie Swaggera
app.UseSwaggerUI();  // Użycie interfejsu Swaggera
app.UseHttpsRedirection();  // Przekierowanie na HTTPS
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();  // Mapowanie kontrolerów
app.Run();  // Uruchomienie aplikacji
