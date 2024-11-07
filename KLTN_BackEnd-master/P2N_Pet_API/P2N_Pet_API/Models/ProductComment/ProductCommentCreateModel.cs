using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.ProductComment
{
    public class ProductCommentCreateModel
    {
        public ulong ProductDetailId { get; set; }

        [DefaultValue("")]
        public string Content { get; set; }
        public ulong CommentRootId { get; set; }
        public float Rating { get; set; }
    }
}
