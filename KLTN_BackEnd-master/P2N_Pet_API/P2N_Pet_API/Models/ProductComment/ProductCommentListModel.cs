using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.ProductComment
{
    public class ProductCommentListModel
    {
        public ulong CommentId { get; set; }
        public ulong UserId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; }
        public DateTime CreateDate { get; set; }

        public List<ProductCommentListModel> CommentChilds { get; set; }
    }
}
