using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.UtilsService.Interface
{
    public interface IEmailService
    {
        void Send(string to, string subject, string html);
    }
}
