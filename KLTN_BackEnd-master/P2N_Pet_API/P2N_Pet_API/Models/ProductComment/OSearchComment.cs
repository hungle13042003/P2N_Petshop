using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.ProductComment
{
    public class OSearchComment
    {
        public int CurrentPage { get; set; }

        [DefaultValue("")]
        public string CurrentDate { get; set; }
        public int Limit { get; set; }

        public ulong ProductDetailId { get; set; }
    }
}
