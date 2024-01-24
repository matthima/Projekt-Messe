
using ApiContextNamespace;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;

namespace API {
    public class API {
        public static void Main(string[] args) {
            // Creates and configures ASP.NET Core WebApp
            // Adds Controllers, DBContext and the Web-Interface via a WebApp builder
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            }
            ); ;
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
                option.AddSecurityRequirement(new OpenApiSecurityRequirement { {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }});
            });



            // Add JWT-Authentication to WebApp
            byte[] key = GenerateRandomKey(32);

            builder.Services.AddSingleton(key);

            Console.WriteLine($"#### Generierter Authentifizierungskey: {Convert.ToBase64String(key)}");

            ConfigureJwtAuthentication(builder.Services, key);



            // Build WebApp
            WebApplication app = builder.Build();

            // displays Swagger UI when in dev mode
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // add needed configurations
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }


        private static void ConfigureJwtAuthentication(IServiceCollection services, byte[] key) {
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

        // Generate random JWT-Authentication key
        private static byte[] GenerateRandomKey(int length) {
            byte[] randomBytes;
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) {
                randomBytes = new byte[length];
                rng.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
