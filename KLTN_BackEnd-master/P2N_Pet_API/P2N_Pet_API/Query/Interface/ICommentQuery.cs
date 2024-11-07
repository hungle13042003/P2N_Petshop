using P2N_Pet_API.Models.ProductComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query.Interface
{
    public interface ICommentQuery
    {
        Task<List<ProductCommentListModel>> QueryListComment(ulong productDetailId);
        Task<int> QueryCheckProductDetailExisted(ulong productDetailId);
        Task<int> QueryCountListComment(OSearchComment oSearch);
        Task<float> QueryAverageRating(ulong ProductDetailId);
        Task<List<ProductCommentListModel>> QueryListCommentChilds(ulong productCommentId);
        Task<ProductCommentModel> QueryCommentDetail(ulong commentId, ulong userid);
    }
}
