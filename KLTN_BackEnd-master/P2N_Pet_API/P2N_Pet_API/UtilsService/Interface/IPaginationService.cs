using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.UtilsService.Interface
{
    public interface IPaginationService
    {
        Task<PaginationModel> BuildPagination(int count, int currentpage, string currentdate, int limit);
    }
}
