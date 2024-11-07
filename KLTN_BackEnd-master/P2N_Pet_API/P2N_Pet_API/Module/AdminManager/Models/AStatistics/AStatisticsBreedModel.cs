using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.AStatistics
{
    public class AStatisticsBreedModel
    {
        public ulong Id { get; set; }
        public string BreedName { get; set; }
        public int TotalQuantityBreed { get; set; }
        public double TotalMoneyBreed { get; set; }
    }
}
