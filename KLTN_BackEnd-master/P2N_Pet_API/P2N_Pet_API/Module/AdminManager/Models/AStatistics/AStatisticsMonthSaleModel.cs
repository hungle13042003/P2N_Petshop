using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AStatistics
{
    public class AStatisticsMonthSaleModel
    {
        public int MonthSale { get; set; }
        public int TotalOrder { get; set; }
        public double TotalMoneySale { get; set; }
    }
}
