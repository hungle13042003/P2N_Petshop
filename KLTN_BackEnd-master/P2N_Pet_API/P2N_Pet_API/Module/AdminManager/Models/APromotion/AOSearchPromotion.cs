using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.APromotion
{
    public class AOSearchPromotion
    {
        public string Limit { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentPage { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
    }
}
