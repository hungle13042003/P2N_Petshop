using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.ProductComment;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action
{
    public class CommentAction : ICommentAction
    {
        private readonly PetShopContext _petShopContext;

        public CommentAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Productcomment> CreateComment(ProductCommentCreateModel productCommentCreate, ForceInfo forceInfo)
        {
            var comment = new Productcomment
            {
                Userid = forceInfo.UserId,
                Productdetailid = productCommentCreate.ProductDetailId,
                Content = productCommentCreate.Content.Trim(),
                Rating = productCommentCreate.Rating,
                Status = 10,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updatedate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId
            };

            if( productCommentCreate.CommentRootId > 0)
            {
                comment.Commentrootid = productCommentCreate.CommentRootId;
            }
            else
            {
                comment.Commentrootid = null;
            }

            _petShopContext.Productcomments.Add(comment);
            await _petShopContext.SaveChangesAsync();

            return comment;
        }

        public async Task<Productcomment> UpdateComment(ProductCommentUpdateModel productCommentUpdate, ForceInfo forceInfo)
        {
            var productComment = _petShopContext.Productcomments.Where(a => a.Id == productCommentUpdate.ProductCommentId).FirstOrDefault();

            if(productComment == null || productComment.Userid != forceInfo.UserId)
            {
                return null;
            }

            productComment.Content = productCommentUpdate.Content.Trim();
            productComment.Rating = productComment.Rating;

            productComment.Updatedate = forceInfo.DateNow;

            _petShopContext.Productcomments.Update(productComment);
            await _petShopContext.SaveChangesAsync();

            return productComment;
        }

        public async Task<Productcomment> DeleteComment(ulong commentId, ForceInfo forceInfo)
        {
            var comment = await _petShopContext.Productcomments.FirstOrDefaultAsync(a => a.Id == commentId && a.Status == 10);

            if(comment != null)
            {
                comment.Status = 190;
                comment.Updatedate = forceInfo.DateNow;
                comment.Updateuser = forceInfo.UserId;

                _petShopContext.Productcomments.Update(comment);
                await _petShopContext.SaveChangesAsync();
            }

            return comment;
        }
    }
}
