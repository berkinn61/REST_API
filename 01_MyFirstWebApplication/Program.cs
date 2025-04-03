var builder = WebApplication.CreateBuilder(args);

// CORS f�r lokale Anfragen aktivieren
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5109") // Erlaubt Anfragen von diesem Host
              .AllowAnyMethod() // Erlaubt GET, POST, PUT, DELETE, etc.
              .AllowAnyHeader(); // Erlaubt alle Header
    });
});

// Services hinzuf�gen
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// CORS aktivieren
app.UseCors("AllowLocalhost");

// Swagger aktivieren (nur im Development-Modus)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware-Konfiguration
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Anwendung starten
app.Run();
