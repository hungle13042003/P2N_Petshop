using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.User
{
    public class UserForgotPasswordV2Model
    {
        [DefaultValue("")]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
