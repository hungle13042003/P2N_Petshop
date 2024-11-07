using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.UtilsProject
{
    public class PaginationModel
    {
        public int CurrentPage { get; set; }
        public string CurrentDate { get; set; }
        public int Limit { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}
