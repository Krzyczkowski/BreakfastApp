using BuberBreakfast.Services.Breakfast;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();  // Rejestracja usług kontrolerów
    builder.Services.AddScoped<IBreakfastService,BreakfastService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error"); // obsluga exceptions
    app.UseSwagger();  // Użycie Swaggera
    app.UseSwaggerUI();  // Użycie interfejsu Swaggera
    app.UseHttpsRedirection();  // Przekierowanie na HTTPS
    app.MapControllers();  // Mapowanie kontrolerów
    app.Run();  // Uruchomienie aplikacji
}