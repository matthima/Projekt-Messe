using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;



// Der Code konfiguriert und erstellt eine ASP.NET Core-Webanwendung.

// Die benötigten Abhängigkeiten werden über den 'builder' konfiguriert.
// Hierzu gehören Controller, ein DbContext für Kundendaten (In-Memory-Datenbank), API Explorer und Swagger.


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<MesseContext>(opt =>
    opt.UseInMemoryDatabase("messe.db"));
//options.UseSqlite($"Data Source={DbPath}");
// opt.UseSqlite("Data Source=messe.db"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Füge die JWT-Authentifizierung hinzu
var key = GenerateRandomKey(32); // Generierter Authentifizierungskey

Console.WriteLine($"#### Generierter Authentifizierungskey: {Convert.ToBase64String(key)}");

ConfigureJwtAuthentication(builder.Services, key);


// Die Webanwendung wird erstellt.
var app = builder.Build();

// Im Entwicklungsmodus wird Swagger für die API-Dokumentation aktiviert.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Füge die Authentifizierungsmiddleware hinzu
app.UseAuthentication();

// Die Anwendung wird auf HTTPS-Redirection, Autorisierung, und das Mappen von Controllern konfiguriert.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Die Anwendung wird gestartet.
app.Run();

// JWT-Authentifizierungskonfiguration
void ConfigureJwtAuthentication(IServiceCollection services, byte[] key) {
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });
}

// Methode für die zufällige Generierung eines Schlüssels
byte[] GenerateRandomKey(int length) {
    byte[] randomBytes;
    using (var rng = RandomNumberGenerator.Create()) {
        randomBytes = new byte[length];
        rng.GetBytes(randomBytes);
    }
    return randomBytes;
}