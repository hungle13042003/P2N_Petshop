using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.ProductComment;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentAction _commentAction;
        private readonly ICommentQuery _commentQuery;
        private readonly IPaginationService _paginationService;

        public CommentService(ICommentAction commentAction,
            ICommentQuery commentQuery,
            IPaginationService paginationService)
        {
            _commentAction = commentAction;
            _commentQuery = commentQuery;
            _paginationService = paginationService;
        }

        public async Task<Productcomment> CreateComment(ProductCommentCreateModel productCommentCreate, ForceInfo forceInfo)
        {
            return await _commentAction.CreateComment(productCommentCreate, forceInfo);
        }

        public async Task<Productcomment> UpdateComment(ProductCommentUpdateModel productCommentUpdate, ForceInfo forceInfo)
        {
            return await _commentAction.UpdateComment(productCommentUpdate, forceInfo);
        }

        public async Task<Productcomment> DeleteComment(ulong commentId, ForceInfo forceInfo)
        {
            return await _commentAction.DeleteComment(commentId, forceInfo);
        }

        public async Task<(List<ProductCommentListModel>, float)> GetListComment(ulong ProductDetailId)
        {
            var isChecked = await _commentQuery.QueryCheckProductDetailExisted(ProductDetailId);

            if( isChecked == 0)
            {
                return (null, 0);
            }

            var commentList = await _commentQuery.QueryListComment(ProductDetailId);

            foreach(var a in commentList)
            {
                a.CommentChilds = await _commentQuery.QueryListCommentChilds(a.CommentId);
            };

            var avg = await _commentQuery.QueryAverageRating(ProductDetailId);

            return (commentList, avg);
        }

        public async Task<PaginationModel> GetListProductPagination(OSearchComment oSearch)
        {
            var count = await _commentQuery.QueryCountListComment(oSearch);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(oSearch.CurrentPage),
                oSearch.CurrentDate, Convert.ToInt32(oSearch.Limit));

            return pagination;
        }

        public async Task<ProductCommentModel> GetDetailComment(ulong commentId, ulong userId)
        {
            var comment = await _commentQuery.QueryCommentDetail(commentId, userId);

            return comment;
        }
    }
}
