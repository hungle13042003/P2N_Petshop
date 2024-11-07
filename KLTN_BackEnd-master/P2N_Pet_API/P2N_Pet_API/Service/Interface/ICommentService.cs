using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.ProductComment;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service.Interface
{
    public interface ICommentService
    {
        Task<Productcomment> CreateComment(ProductCommentCreateModel productCommentCreate, ForceInfo forceInfo);
        Task<Productcomment> UpdateComment(ProductCommentUpdateModel productCommentUpdate, ForceInfo forceInfo);
        Task<Productcomment> DeleteComment(ulong commentId, ForceInfo forceInfo);

        Task<(List<ProductCommentListModel>, float)> GetListComment(ulong ProductDetailId);
        Task<PaginationModel> GetListProductPagination(OSearchComment oSearch);
        Task<ProductCommentModel> GetDetailComment(ulong commentId, ulong userId);
    }
}
