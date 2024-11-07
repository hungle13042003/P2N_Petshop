using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.UtilsProject
{
    public class ObjectResponse
    {
        public int result { get; set; }
        public string message { get; set; }
        public Object content { get; set; }
    }
}
