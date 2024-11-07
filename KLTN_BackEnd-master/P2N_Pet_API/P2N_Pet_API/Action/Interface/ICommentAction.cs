using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.ProductComment;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action.Interface
{
    public interface ICommentAction
    {
        Task<Productcomment> CreateComment(ProductCommentCreateModel productCommentCreate, ForceInfo forceInfo);
        Task<Productcomment> UpdateComment(ProductCommentUpdateModel productCommentUpdate, ForceInfo forceInfo);
        Task<Productcomment> DeleteComment(ulong commentId, ForceInfo forceInfo);
    }
}
