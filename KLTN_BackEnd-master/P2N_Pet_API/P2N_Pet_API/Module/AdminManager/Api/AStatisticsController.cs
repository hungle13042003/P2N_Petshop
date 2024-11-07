using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AStatistics;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ManagerAccess]
    public class AStatisticsController : ControllerBase
    {
        private readonly IAStatisticsService _aStatisticsService;

        public AStatisticsController(IAStatisticsService aStatisticsService)
        {
            _aStatisticsService = aStatisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                var statistics = await _aStatisticsService.GetStatistics();

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Statistics = statistics
                    }
                });
            }
            catch (Exception e)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Đã có lỗi xảy ra. Vui lòng thử lại.",
                    content = e.Message.ToString()
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetStatisticsBreed(AOSearchStatisticsBreed aOSearchStatisticsBreed)
        {
            try
            {
                var statisticsBreed = await _aStatisticsService.GetStatisticsBreed(aOSearchStatisticsBreed);

                var pagination = await _aStatisticsService.GetStatisticsBreedPagination(aOSearchStatisticsBreed);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        StatisticsBreed = statisticsBreed,
                        Pagination = pagination
                    }
                });
            }
            catch (Exception e)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Đã có lỗi xảy ra. Vui lòng thử lại.",
                    content = e.Message.ToString()
                });
            }
        }
    }
}
