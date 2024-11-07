using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AStatistics;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class AStatisticsService : IAStatisticsService
    {
        private readonly IAStatisticsQuery _aStatisticsQuery;
        private readonly IPaginationService _paginationService;

        public AStatisticsService(IAStatisticsQuery aStatisticsQuery,
            IPaginationService paginationService)
        {
            _aStatisticsQuery = aStatisticsQuery;
            _paginationService = paginationService;
        }

        public async Task<AStatisticsModel> GetStatistics()
        {
            return await _aStatisticsQuery.QueryStatistics();
        }

        public async Task<List<AStatisticsBreedModel>> GetStatisticsBreed(AOSearchStatisticsBreed aOSearchStatisticsBreed)
        {
            return await _aStatisticsQuery.QueryGetStatisticsBreed(aOSearchStatisticsBreed);
        }

        public async Task<PaginationModel> GetStatisticsBreedPagination(AOSearchStatisticsBreed aOSearchStatisticsBreed)
        {
            var count = await _aStatisticsQuery.QueryCountStatisticsBreed(aOSearchStatisticsBreed);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchStatisticsBreed.CurrentPage),
                Utils.DateNow().ToString(), Convert.ToInt32(aOSearchStatisticsBreed.Limit));

            return pagination;
        }

    }
}
