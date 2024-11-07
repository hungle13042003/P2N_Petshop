using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.UtilsService
{
    public class PaginationService: IPaginationService
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public PaginationService(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<PaginationModel> BuildPagination(int count, int currentpage, string currentdate, int limit)
        {
            var pagination = new PaginationModel
            {
                TotalCount = count,
                CurrentPage = currentpage,
                CurrentDate = currentdate,
                Limit = limit,
                TotalPage = (int)Math.Ceiling(count / (double)limit),
                HasPrevious = currentpage > 0,
            };

            pagination.HasNext = currentpage < (pagination.TotalPage - 1);

            return pagination;
        }
    }
}
