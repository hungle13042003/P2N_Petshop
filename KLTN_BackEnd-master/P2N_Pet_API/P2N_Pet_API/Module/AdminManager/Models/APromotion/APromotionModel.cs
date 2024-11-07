using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.APromotion
{
    public class APromotionModel
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Status { get; set; }
    }
}
