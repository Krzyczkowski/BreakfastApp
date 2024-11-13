using BuberBreakfast.Authentication;
using BuberBreakfast.Common.Interfaces.Authentication;
using BuberBreakfast.Interfaces.Persistance;
using BuberBreakfast.Persistance;
using BuberBreakfast.Services.Authentication;
using BuberBreakfast.Services.Breakfast;

ConfigurationManager configurationManager = new();
configurationManager.SetBasePath(Directory.GetCurrentDirectory());
configurationManager.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var builder = WebApplication.CreateBuilder(args);

// Rejestracja usług
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();  // Rejestracja usług kontrolerów
builder.Services.AddScoped<IBreakfastService, BreakfastService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();
builder.Services.Configure<JwtSettings>(configurationManager.GetSection("JwtSettings"));

var app = builder.Build();

// Konfiguracja aplikacji
app.UseExceptionHandler("/error"); // obsługa exceptions
app.UseSwagger();  // Użycie Swaggera
app.UseSwaggerUI();  // Użycie interfejsu Swaggera
app.UseHttpsRedirection();  // Przekierowanie na HTTPS
app.MapControllers();  // Mapowanie kontrolerów
app.Run();  // Uruchomienie aplikacji
