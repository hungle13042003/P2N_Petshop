using P2N_Pet_API.Manager.Token;
using P2N_Pet_API.Manager.Token.Interface;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models.Login;

namespace P2N_Pet_API.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginQuery _loginQuery;

        public LoginService(ILoginQuery loginQuery)
        {
            _loginQuery = loginQuery;
        }

        public async Task<(string, LoginSuccessModel)> Login(LoginModel login)
        {
            login.Password = Encryptor.MD5Hash(login.Password);

            var loginSuccess = await _loginQuery.Login(login.Email, login.Password);

            if (loginSuccess == null)
            {
                return ("Tài khoản không chính xác. Vui lòng thử lại.", null);
            }

            return ("", loginSuccess);
        }

        public string GenerateTokenByUser(LoginSuccessModel loginSuccess)
        {
            IAuthContainerModel model = Signature.GetJWTContainerModel(loginSuccess.Id.ToString(), loginSuccess.Email, loginSuccess.Password, loginSuccess.Role.ToString());
            IAuthService authService = new JWTService(model.SecretKey);

            return authService.GenerateToken(model);
        }
    }
}
