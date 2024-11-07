using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.ProductComment;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [UserAccess]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(ProductCommentCreateModel productCommentCreate)
        {
            if( productCommentCreate.ProductDetailId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng chọn productdetailid",
                });
            }

            if ( string.IsNullOrEmpty(productCommentCreate.Content.Trim()))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền nội dung bình luận",
                });
            }

            try
            {
                var forceInfo = new ForceInfo
                {
                    UserId = Utils.GetUserIdFromToken(Request),
                    DateNow = Utils.DateNow()
                };

                var result = await _commentService.CreateComment(productCommentCreate, forceInfo);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Gửi nội dụng bình luận thành công",
                    content = new
                    {
                        Comment = result
                    }
                });
            }
            catch (Exception e)
            {

                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = e.Message.ToString(),
                    content = new
                    {
                        e.InnerException
                    }
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(ProductCommentUpdateModel productCommentUpdate)
        {
            if (productCommentUpdate.ProductCommentId == 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng chọn productcommentid",
                });
            }

            if (string.IsNullOrEmpty(productCommentUpdate.Content.Trim()))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền nội dung bình luận",
                });
            }

            try
            {
                var forceInfo = new ForceInfo
                {
                    UserId = Utils.GetUserIdFromToken(Request),
                    DateNow = Utils.DateNow()
                };

                var result = await _commentService.UpdateComment(productCommentUpdate, forceInfo);

                if(result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Cập nhật bình luận thất bại!",
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Cập nhật bình luận thành công",
                    content = new
                    {
                        Comment = result
                    }
                });
            }
            catch (Exception e)
            {

                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = e.Message.ToString()
                });
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteComment(ulong CommentId)
        {            
            if ( CommentId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng chọn CommentId",
                });
            }

            try
            {
                var forceInfo = new ForceInfo
                {
                    UserId = Utils.GetUserIdFromToken(Request),
                    DateNow = Utils.DateNow()
                };

                var result = await _commentService.DeleteComment(CommentId, forceInfo);

                if(result == null)
                {
                    return Ok(new ObjectResponse
                    {
                        result = 0,
                        message = "Xoá comment thất bại",
                    });
                }

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "Xoá bình luận thành công",
                    content = new
                    {
                        Comment = result
                    }
                });
            }
            catch (Exception e)
            {

                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = e.Message.ToString()
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailComment(ulong commentId)
        {
            if(commentId <= 0)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền CommentId",
                });
            }
            var userId = Utils.GetUserIdFromToken(Request);

            var result = await _commentService.GetDetailComment(commentId, userId);

            if (result == null)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Lấy comment thất bại",
                });
            }

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "Lấy bình luận thành công",
                content = new
                {
                    Comment = result
                }
            });
        }
    }
}
