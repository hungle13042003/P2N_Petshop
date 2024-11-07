using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models.Login
{
    public class LoginModel
    {
        [DefaultValue("")]
        public string Email { get; set; }
        [DefaultValue("")]
        public string Password { get; set; }
    }
}
