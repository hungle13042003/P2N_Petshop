using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database;
using P2N_Pet_API.Models.Cart;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service
{
    public class CartService : ICartService
    {
        private readonly ICartAction _cartAction;
        private readonly ICartQuery _cartQuery;

        public CartService(ICartAction cartAction,
            ICartQuery cartQuery)
        {
            _cartAction = cartAction;
            _cartQuery = cartQuery;
        }

        public async Task<ObjectResponse> AddToCart(CartItemCreateModel cartItemCreate, ForceInfo forceInfo)
        {
            var isProduct = await _cartQuery.CheckProductExisted(cartItemCreate.ProductDetailId);

            if (isProduct.Item1 == 0)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Product không tồn tại"
                };
            }
            else
            {
                if(isProduct.Item2 == 3)
                {
                    return new ObjectResponse
                    {
                        result = 0,
                        message = "Thú cưng này hết hàng"
                    };
                }
                else if (isProduct.Item2 == 2)
                {
                    return new ObjectResponse
                    {
                        result = 0,
                        message = "Thú cưng này ngừng bán"
                    };
                }
            }

            var isValid = await _cartQuery.QueryCheckProductDetailExistedAndGetPrice(cartItemCreate.ProductDetailId);

            if( isValid.Item1 == 0) // check tồn tại
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "ProductDetailId không tồn tại"
                };
            }
            else
            {
                var isCart = await _cartQuery.QueryCheckCartExisted(forceInfo.UserId);

                if(isCart == 0) // check có cart 
                {
                    await _cartAction.CreateCartForUser(forceInfo);
                }

                if(isValid.Item3 < 1) // lấy quantity petdetail
                {
                    return new ObjectResponse
                    {
                        result = 0,
                        message = "Thú cưng này tạm thời hết hàng.Vui lòng đợi thông báo sau."
                    };
                }

                var cartId = await _cartQuery.GetCartIdByUser(forceInfo.UserId);

                if(cartId > 0)
                {
                    var isQuantity = await _cartQuery.GetQuantityAddCart(cartItemCreate.ProductDetailId, cartId);

                    var quantityOrder = isQuantity.Item2 + cartItemCreate.Quantity;

                    if(isQuantity.Item1 > 0 && quantityOrder > isValid.Item3)
                    {
                        return new ObjectResponse
                        {
                            result = 0,
                            message = "Số lượng bạn đặt đã vượt qua số lượng tối đa."
                        };
                    }
                }


                cartItemCreate.PriceDiscount = isValid.Item2; // lấy pricediscount

                var addToCart = await _cartAction.AddToCart(cartItemCreate, forceInfo);

                if(addToCart == null)
                {
                    return new ObjectResponse
                    {
                        result = 0,
                        message = "AddToCart thất bại"
                    };
                }

                return new ObjectResponse
                {
                    result = 1,
                    message = "AddToCart thành công",
                    content = new
                    {
                        CartItem = addToCart
                    }
                };
            }
        }

        public async Task<ObjectResponse> DeleteCartItem(ForceInfo forceInfo, ulong CartItemId)
        {
            var item = await _cartAction.DeteleCartItem(forceInfo, CartItemId);

            if(item == null)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Xoa item thất bại"
                };
            }

            return new ObjectResponse
            {
                result = 1,
                message = "Xoa item thành công",
            };
        }

        public async Task<ObjectResponse> GetListCartItem(ulong userId)
        {
            var itemList = await _cartQuery.GetListCartItem(userId);

            ulong i = 1;

            itemList.ForEach(a =>
            {
                a.Id = i++;
            });

            if(itemList == null || itemList.Count == 0)
            {
                return new ObjectResponse
                {
                    result = 1,
                    message = "Không có item nào.",
                    content = new
                    {
                        Count = itemList.Count()
                    }
                };
            }

            var total = itemList.Sum(x => x.TotalPriceItem);

            return new ObjectResponse
            {
                result = 1,
                message = "List item trong cart.",
                content = new
                {
                    CartItem = itemList,
                    Count = itemList.Count(),
                    Total = total
                }
            };
        }


        public async Task<ObjectResponse> GetQuantityByProductDetailIdAndUser(ulong productDetailId, ulong userId)
        {
            var quantity = await _cartQuery.GetQuantityCartByIdAndUser(productDetailId, userId);

            return new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Quantity = quantity
                }
            };
        }

        public async Task<ObjectResponse> GetCountQuantityCartItem(ulong userid)
        {
            var countQuantity = await _cartQuery.GetCountQuantityCartItem(userid);

            return new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    countQuantity
                }
            };
        }

        public async Task<ObjectResponse> UpdateQuantityCartItem(ForceInfo forceInfo, CartItemUpdateModel cartItemUpdate)
        {
            var isValid = await _cartQuery.QueryCheckProductDetailExistedAndGetPrice(cartItemUpdate.ProductDetailId);

            if (isValid.Item1 == 0) // check tồn tại
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "ProductDetailId không tồn tại"
                };
            }
            else
            {
                var cartId = await _cartQuery.GetCartIdByUser(forceInfo.UserId);

                if (cartId > 0)
                {
                    var isQuantity = await _cartQuery.GetQuantityAddCart(cartItemUpdate.ProductDetailId, cartId);

                    //var quantityOrder = isQuantity.Item2 + cartItemUpdate.Quantity;

                    if (isQuantity.Item1 > 0 && cartItemUpdate.Quantity > isValid.Item3)
                    {
                        return new ObjectResponse
                        {
                            result = 0,
                            message = "Số lượng bạn đặt đã vượt qua số lượng tối đa."
                        };
                    }
                }

                var item = await _cartAction.UpdateQuantityCartItem(forceInfo, cartItemUpdate);

                if (item == null)
                {
                    return new ObjectResponse
                    {
                        result = 0,
                        message = "Cập nhật số lượng thất bại"
                    };
                }

                return new ObjectResponse
                {
                    result = 1,
                    message = "Cập nhật số lượng thành công",
                };
            }
            
        }
    }
}
