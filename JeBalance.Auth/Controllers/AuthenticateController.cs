using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using JeBalance.Administration.Authentication;

namespace JeBalance.Auth.Controllers;

[Route("api/v1/auth")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthenticateController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    // Hardcoded admin and inspector credentials
    private const string HardcodedAdminUsername = "admin";

    private const string HardcodedAdminPasswordHash =
        "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

    private const string HardcodedInspectorUsername = "inspector";

    private const string HardcodedInspectorPasswordHash =
        "98fe442255035a1459bb5b86fda03d7c34c23d512b1b5bf3a5ecb7a802601895";


    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        var passwordHash = ComputeSha256Hash(model.Password);

        if (model.Username == HardcodedAdminUsername && passwordHash == HardcodedAdminPasswordHash)
        {
            var adminToken = _jwtService.GenerateToken(model.Username, "Admin");
            return Ok(adminToken);
        }

        if (model.Username == HardcodedInspectorUsername && passwordHash == HardcodedInspectorPasswordHash)
        {
            var inspectorToken = _jwtService.GenerateToken(model.Username, "Inspector");
            return Ok(inspectorToken);
        }

        return Unauthorized("Invalid username or password.");
    }

    private static string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            var builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}