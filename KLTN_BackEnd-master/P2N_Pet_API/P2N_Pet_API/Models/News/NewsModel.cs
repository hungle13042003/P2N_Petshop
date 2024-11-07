using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.News
{
    public class NewsModel
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string HtmlContent { get; set; }
        public string Image { get; set; }
        public string TypeNewsText { get; set; }
        public string StatusText { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
