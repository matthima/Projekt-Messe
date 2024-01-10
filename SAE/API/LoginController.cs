using ApiContextNamespace;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.IdentityModel.Tokens;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    //JWT-Schlüssel zur Token-Erstellung
    private readonly byte[] _jwtKey;
    private readonly ApiContext _context; 

    //JWT-Schlüssel als Abhängigkeit aktzeptieren.
    public LoginController(byte[] jwtKey, ApiContext context)
    {
        _jwtKey = jwtKey;
        _context = context;

    }

    // HTTP-POST-Endpunkt für die Benutzerauthentifizierung und Token-Erstellung.
    [HttpPost, Route("login")]
    public IActionResult Login(LoginDTO loginDTO)
    {
        try
        {      
            // Prüfung eingegebene Benutzerdaten
            if (string.IsNullOrEmpty(loginDTO.UserName) || string.IsNullOrEmpty(loginDTO.Password))
                return BadRequest("Benutzerdaten nicht eingegeben.");

            // Überprüfung Benutzerdaten in der Datenbank
            var user = _context.Users.FirstOrDefault(u => u.Name == loginDTO.UserName);

        if (user != null) // Benutzer verfügbar 
        {

            // Überprüfe Passwort
            if (user.Passwort == loginDTO.Password)
            {
                // Erstellt einen geheimen Schlüssel für die Token-Signatur.
                var secretKey = new SymmetricSecurityKey(_jwtKey);

                // Erstellt Anmeldeinformationen für die Token-Signatur.
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                // Erstellt ein JWT-Sicherheitstoken mit den angegebenen Parametern.
                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: "MesseAPI", // Aussteller des Tokens
                    audience: "http://localhost:7190", // erwarteter Empfänger des Tokens
                    claims: new List<Claim>(), // Ansprüche, die reinkönnen
                    expires: DateTime.Now.AddMinutes(1), // Ablaufzeit 
                    signingCredentials: signinCredentials // Anmeldeinformationen für die Token-Signatur
                );

                // Gibt JWT-Token als OK-Antwort zurück
                return Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));

            }
            else
            {
                
                return BadRequest("Falsches Passwort");
            }
        }
        else
        {
            
            return BadRequest("Benutzer nicht gefunden");
        }
        }
        catch
        {



            return Unauthorized();
        }
        
    }
}
