using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.Order
{
    public class OrderCreateModel
    {
        [DefaultValue("")]
        public string Name { get; set; }
        [DefaultValue("")]
        public string Address { get; set; }
        [DefaultValue("")]
        public string Phone { get; set; }
        [DefaultValue("")]
        public string Email { get; set; }
        public int TypePaymentId { get; set; }

        // Order
        [DefaultValue("")]
        public string Note { get; set; }

        [JsonIgnore]
        public ulong CartId { get; set; }
        [JsonIgnore]
        public ulong TotalMoney { get; set; }
        [JsonIgnore]
        public ulong CustomerId { get; set; }
    }
}
