using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.News
{
    public class OSearchNews
    {
        public int CurrentPage { get; set; }
        public int Limit { get; set; }
        public string FindString { get; set; }
    }
}
