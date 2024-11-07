using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Models.ANews
{
    public class ANewsModel
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string HtmlContent { get; set; }
        public string Image { get; set; }
        public int TypeNewsId { get; set; }
        public int Status { get; set; }
    }
}
