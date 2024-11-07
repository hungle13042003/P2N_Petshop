using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ANews
{
    public class AOSearchNews
    {
        public int CurrentPage { get; set; }
        public int Limit { get; set; }
        public string Title { get; set; }
        public int TypeNewsId { get; set; }
        public int Status { get; set; }
    }
}
