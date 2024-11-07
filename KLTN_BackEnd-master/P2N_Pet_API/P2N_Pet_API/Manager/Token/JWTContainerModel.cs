using Microsoft.IdentityModel.Tokens;
using P2N_Pet_API.Manager.Token.Interface;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P2N_Pet_API.Manager.Token
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public string SecretKey { get; set; } = Utils.KeyToken;
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public int ExpireMinutes { get; set; } = 525600; // 1 năm
        public Claim[] Claims { get; set; }
    }
}
