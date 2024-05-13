using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserManagement.Utils
{
    public class JWT
    {
        private readonly IConfiguration config;
        private readonly IHttpContextAccessor httpContextAccessor;

        public JWT(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            this.config = config;
            this.httpContextAccessor = httpContextAccessor;
        }
        public string generateToken(string email,string role)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Secret").Value));
            SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: config.GetSection("JWT:Issuer").Value,
                audience: config.GetSection("JWT:Audence").Value,
                signingCredentials: signingCred
                );
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        public IEnumerable<Claim> GetClaims(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = httpContextAccessor.HttpContext.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();
            if (accessToken != null)
            {
                var token = tokenHandler.ReadJwtToken(accessToken);
                return token.Claims;
            }
            return null;
        }

        public bool isTokenValid(string jwt)
        {
            var claims = this.GetClaims(jwt);
            var expClaim =  claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;
            if (expClaim != null && long.TryParse(expClaim, out long exp))
            {
                var expiryDate = DateTimeOffset.FromUnixTimeSeconds(exp).UtcDateTime.AddHours(5);
                var date1 = expiryDate;
                var date2 = DateTime.UtcNow.AddHours(5);
                return expiryDate > DateTime.UtcNow.AddHours(5) ? true:false;
            }
            return false;
        }

        public string GetEmailFromJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = httpContextAccessor.HttpContext.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();
            if (accessToken != null)
            {
                var token = tokenHandler.ReadJwtToken(accessToken);
                return token.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            }
            return null;
        }
    }
}
