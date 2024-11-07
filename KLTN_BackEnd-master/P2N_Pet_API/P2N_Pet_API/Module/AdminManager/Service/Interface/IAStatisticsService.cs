using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AStatistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IAStatisticsService
    {
        Task<AStatisticsModel> GetStatistics();
        Task<List<AStatisticsBreedModel>> GetStatisticsBreed(AOSearchStatisticsBreed aOSearchStatisticsBreed);
        Task<PaginationModel> GetStatisticsBreedPagination(AOSearchStatisticsBreed aOSearchStatisticsBreed);
    }
}
