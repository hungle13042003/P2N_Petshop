using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models.Login;

namespace P2N_Pet_API.Query.Interface
{
    public interface ILoginQuery
    {
        Task<LoginSuccessModel> Login(string email, string password);
    }
}
