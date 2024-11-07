using P2N_Pet_API.Models.ProductComment;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query
{
    public class CommentQuery: ICommentQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public CommentQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<ProductCommentListModel>> QueryListComment(ulong productDetailId)
        {
            //oSearch.CurrentPage = oSearch.CurrentPage < 0 ? 0 : oSearch.CurrentPage;
            //oSearch.CurrentDate = string.IsNullOrEmpty(oSearch.CurrentDate)
            //    ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
            //    : oSearch.CurrentDate;

            //oSearch.Limit = oSearch.Limit == 0 ? 25 : oSearch.Limit;

            var condition = "";

            if(productDetailId > 0)
            {
                condition += @" and cmt.productdetailid = @ProductDetailId";
            }

            var query =
                @"select ifnull(cmt.id, 0) CommentId, ifnull(u.id, 0) UserId, ifnull(u.name, '') Name,
	                case 
	                  when ifnull(u.avatar, '') != ''
	                  then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Avatar/Avatar_', u.Id, '/', ifnull(u.Avatar, ''))
	                  else CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/System/avatardefault.jpg') 
	                end Avatar,
                    ifnull(cmt.content, '') Content, cmt.Rating, 
                    cmt.CreateDate 
                from productcomment cmt
                left join users u on cmt.userid = u.id
                left join productdetail pd on cmt.productdetailid = pd.id
                where u.status = @Status and pd.status = @Status and cmt.status = @Status and ifnull(cmt.commentrootid, 0) = 0 " + condition + @"
                order by cmt.createdate desc ";

            return await _p2NPetDapper.QueryAsync<ProductCommentListModel>(query, new
            {
                ProductDetailId = productDetailId,
                Status = 10,
                //offset = oSearch.CurrentPage * oSearch.Limit,
                //limit = oSearch.Limit,

            });
        }

        public async Task<int> QueryCheckProductDetailExisted(ulong productDetailId)
        {
            var query =
                @"select count(1), (price * (1 - discount / 100)) PriceDiscount, quantity
                from productdetail
                where statusdetailid = 1 and status = 10 and id = @Id";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                Id = productDetailId
            });
        }

        public async Task<int> QueryCountListComment(OSearchComment oSearch)
        {
            oSearch.CurrentPage = oSearch.CurrentPage < 0 ? 0 : oSearch.CurrentPage;
            oSearch.CurrentDate = string.IsNullOrEmpty(oSearch.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : oSearch.CurrentDate;

            oSearch.Limit = oSearch.Limit == 0 ? 25 : oSearch.Limit;

            var condition = "";

            if (oSearch.ProductDetailId > 0)
            {
                condition += @" and cmt.productdetailid = @ProductDetailId";
            }

            var query =
                @"select ifnull(cmt.id, 0) CommentId, ifnull(u.id, 0) UserId, ifnull(u.name, '') Name,
	                case 
	                  when ifnull(u.avatar, '') != ''
	                  then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Avatar/Avatar_', u.Id, '/', ifnull(u.Avatar, ''))
	                  else CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/System/avatardefault.jpg') 
	                end Avatar, 
                    cmt.createdate
                from productcomment cmt
                left join users u on cmt.userid = u.id
                left join productdetail pd on cmt.productdetailid = pd.id
                where u.status = @Status and pd.status = @Status " + condition + @"
                order by cmt.createdate desc";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                ProductDetailId = oSearch.ProductDetailId,
                Status = 10
            });
        }

        public async Task<float> QueryAverageRating(ulong ProductDetailId)
        {
            var query =
                @"select ifnull(avg(ifnull(rating, 0)), 0)   
                from productcomment 
                where status = @Status and productdetailid = @ProductDetailId and ifnull(commentrootid, 0) = 0 ";

            return await _p2NPetDapper.QuerySingleAsync<float>(query, new
            {
                Status = 10,
                ProductDetailId = ProductDetailId,
            });
        }

        public async Task<List<ProductCommentListModel>> QueryListCommentChilds(ulong productCommentId)
        {
            var query =
                @"select ifnull(cmt.id, 0) CommentId, ifnull(u.id, 0) UserId, ifnull(u.name, '') Name,
	                case 
	                  when ifnull(u.avatar, '') != ''
	                  then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Avatar/Avatar_', u.Id, '/', ifnull(u.Avatar, ''))
	                  else CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/System/avatardefault.jpg') 
	                end Avatar,
                    ifnull(cmt.content, '') Content, 
                    cmt.CreateDate 
                from productcomment cmt
                left join users u on cmt.userid = u.id
                left join productdetail pd on cmt.productdetailid = pd.id
                where u.status = @Status and pd.status = @Status and cmt.status = @Status and 
                    cmt.commentrootid = @ProductCommentId 
                order by cmt.createdate desc ";

            return await _p2NPetDapper.QueryAsync<ProductCommentListModel>(query, new
            {
                ProductCommentId = productCommentId,
                Status = 10,
            });
        }

        public async Task<ProductCommentModel> QueryCommentDetail(ulong commentId, ulong userId)
        {
            var query =
                @"select ifnull(cmt.id, 0) CommentId, ifnull(u.id, 0) UserId, ifnull(u.name, '') Name,
	                case 
	                  when ifnull(u.avatar, '') != ''
	                  then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Avatar/Avatar_', u.Id, '/', ifnull(u.Avatar, ''))
	                  else CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/System/avatardefault.jpg') 
	                end Avatar,
                    ifnull(cmt.content, '') Content 
                from productcomment cmt
                left join users u on cmt.userid = u.id
                left join productdetail pd on cmt.productdetailid = pd.id
                where u.status = 10 and pd.status = 10 and cmt.status = 10 and cmt.id = @CommentId "; // and cmt.userid = @UserId";

            return await _p2NPetDapper.QuerySingleAsync<ProductCommentModel>(query, new
            {
                CommentId = commentId,
                UserId = userId
            });
        }
    }
}
