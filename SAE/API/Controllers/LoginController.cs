using API.Controllers;
using ApiContextNamespace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase {
    // JWT-Authentication Key
    private readonly byte[] _jwtKey;
    private readonly ApiContext _context;

    public LoginController(byte[] jwtKey, ApiContext context) {
        this._jwtKey = jwtKey;
        this._context = context;

    }

    // HTTP-POST-Endpoint for authenticating users via login. Returns the User's Authentication-Token.
    [HttpPost, Route("login")]
    public IActionResult Login(LoginDTO loginDTO) {
        try {
            // Force username + password to be required
            if (string.IsNullOrEmpty(loginDTO.UserName) || string.IsNullOrEmpty(loginDTO.Password))
                return this.BadRequest("Benutzerdaten nicht eingegeben.");

            // Fetch user with given name
            Database.User? user = this._context.Users.FirstOrDefault(u => u.Name == loginDTO.UserName);

            if (user != null) // Benutzer verfügbar 
            {
                if (user.Passwort == loginDTO.Password) {
                    // create secret key, used in token-generation
                    SymmetricSecurityKey secretKey = new SymmetricSecurityKey(this._jwtKey);

                    // create credentials, used in token-generation
                    SigningCredentials signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    // create JWT-Auth-Token
                    JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                    issuer: "MesseAPI",
                    audience: "http://localhost:7190", // defines where the token can be used
                    claims: new List<Claim>(), // assertions that need to be true for the token to be valid (here: no special assertions)
                    expires: DateTime.Now.AddMinutes(1), // token expires in n minutes
                    signingCredentials: signinCredentials
                );

                    // returns the JWT-Token
                    return this.Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));

                }
                else {
                    return this.BadRequest("Falsches Passwort");
                }
            }
            else {
                return this.BadRequest("Benutzer nicht gefunden");
            }
        }
        catch {
            return this.Unauthorized();
        }

    }
}
