using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema_api.Helpers
{
    public static class JwtToken
    {
        private const string SECRET_KEY = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJFeGVtcGxlSXNzdWVyIiwiVXNlcm5hbWUiOiJTZWNyZXRVc2VyIiwiQXVkaWVuY2UiOiJFeGVtcGxlQXVkaWVuY2UiLCJleHAiOjE2MjQ4MjMzNjgsImlhdCI6MTYxMTc3Njk2OH0.Z-G_TPg-ZaSBNWsJ5R-CO5TpGKZ7-JBEIDWydcSy8Us";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJwtToken()
        {
            var credentials = new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);

            DateTime Expiry = DateTime.Now.AddMinutes(120);
            int ts = Convert.ToInt32((Expiry - new DateTime(1970, 1, 1)).TotalSeconds);

            var payload = new JwtPayload
            {
                {"sub", "testeSubject" },
                {"Name", "Teste" },
                {"email", "teste@teste.com" },
                {"exp", ts },
                {"iss", "https://localhost:44362" },
                {"aud", "http://localhost:44362" }

            };

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();

            var tokenString = handler.WriteToken(secToken);


            return tokenString;
        }
    }
}
