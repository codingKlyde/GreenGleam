using Microsoft.Extensions.Configuration;

namespace GreenGleam.Api.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user)
        {
            Claim[] claims = [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
                ];

            var key = _configuration.GetValue<string>("Jwt:Key");
            var securityKey = Encoding.UTF8.GetBytes(key);
            var symmetricKey = new SymmetricSecurityKey(securityKey);
            var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            var expiration = _configuration.GetValue<int>("Jwt:ExpirationInMinutes");

            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiration),
                issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}