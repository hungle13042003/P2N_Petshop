using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.CloudMedia
{
    public class CloudOneMediaConfig
    {
        public string Folder { get; set; }
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
