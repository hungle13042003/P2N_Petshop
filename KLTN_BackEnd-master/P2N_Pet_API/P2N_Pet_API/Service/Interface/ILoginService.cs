using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models.Login;

namespace P2N_Pet_API.Service.Interface
{
    public interface ILoginService
    {
        Task<(string, LoginSuccessModel)> Login(LoginModel login);
        string GenerateTokenByUser(LoginSuccessModel loginSuccess);
    }
}
