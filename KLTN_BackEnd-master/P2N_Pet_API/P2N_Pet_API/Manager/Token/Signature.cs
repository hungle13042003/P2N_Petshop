using P2N_Pet_API.Manager.Token.Interface;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P2N_Pet_API.Manager.Token
{
    public class Signature
    {
        public static JWTContainerModel GetJWTContainerModel(string userId, string email, string password, string role)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.AuthenticationMethod, password),
                    new Claim(ClaimTypes.Role, role)
                }
            };
        }

        public static bool CheckTokenValid(string token)
        {
            IAuthService authService = new JWTService(Utils.KeyToken);

            if (authService.IsTokenValid(token))
            {
                return true;
            }

            return false;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
