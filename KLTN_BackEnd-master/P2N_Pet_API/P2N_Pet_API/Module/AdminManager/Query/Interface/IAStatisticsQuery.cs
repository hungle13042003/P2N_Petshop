using P2N_Pet_API.Module.AdminManager.Models.AStatistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IAStatisticsQuery
    {
        Task<AStatisticsModel> QueryStatistics();
        Task<List<AStatisticsBreedModel>> QueryGetStatisticsBreed(AOSearchStatisticsBreed aOSearchStatisticsBreed);
        Task<int> QueryCountStatisticsBreed(AOSearchStatisticsBreed aOSearchStatisticsBreed);
    }
}
