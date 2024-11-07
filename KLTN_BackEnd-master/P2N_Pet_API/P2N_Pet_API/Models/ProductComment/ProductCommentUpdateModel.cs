using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.ProductComment
{
    public class ProductCommentUpdateModel
    {
        public ulong ProductCommentId { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; }
    }
}
