using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.CloudMedia
{
    public class CloudMediaConfig
    {
        public string Folder { get; set; }
        public string FileName { get; set; }
        public List<CloudFileConfig> CloudFiles { get; set; }
    }
}
