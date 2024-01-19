
using ApiContextNamespace;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

//using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace API {
    public class Program {
        public static void Main(string[] args) {



            // Der Code konfiguriert und erstellt eine ASP.NET Core-Webanwendung.

            // Die benötigten Abhängigkeiten werden über den 'builder' konfiguriert.
            // Hierzu gehören Controller, ein DbContext für Kundendaten (In-Memory-Datenbank), API Explorer und Swagger.


            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApiContext>(opt => { });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(option => {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Authenticate API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });



            // Füge die JWT-Authentifizierung hinzu
            byte[] key = GenerateRandomKey(32); // Generierter Authentifizierungskey

            builder.Services.AddSingleton(key);

            Console.WriteLine($"#### Generierter Authentifizierungskey: {Convert.ToBase64String(key)}");

            ConfigureJwtAuthentication(builder.Services, key);



            // Die Webanwendung wird erstellt.
            WebApplication app = builder.Build();

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
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) {
                    randomBytes = new byte[length];
                    rng.GetBytes(randomBytes);
                }
                return randomBytes;
            }
        }
    }
}
