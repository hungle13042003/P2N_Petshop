using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Cart;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action
{
    public class CartAction : ICartAction
    {
        private readonly PetShopContext _petShopContext;

        public CartAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task CreateCartForUser(ForceInfo forceInfo)
        {
            var cart = new Cart
            {
                Userid = forceInfo.UserId,
                Status = 10,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Add(cart);
            await _petShopContext.SaveChangesAsync();
        }

        public async Task<Cartitem> AddToCart(CartItemCreateModel cartItemCreate, ForceInfo forceInfo)
        {
            var cart = await _petShopContext.Carts.FirstOrDefaultAsync(a => a.Userid == forceInfo.UserId &&
                                    a.Status == 10);

            if(cart != null)
            {

                var item = await _petShopContext.Cartitems.FirstOrDefaultAsync(a => a.Cartid == cart.Id &&
                                    a.Productdetailid == cartItemCreate.ProductDetailId &&
                                    a.Orderid == null &&
                                    a.Createuser == forceInfo.UserId);

                if(item != null)
                {
                    if (item.Status == 190)
                    {
                        item.Quantity = cartItemCreate.Quantity > 1 ? cartItemCreate.Quantity : 1;
                    }
                    else
                    {
                        item.Quantity = cartItemCreate.Quantity > 1 ? item.Quantity + cartItemCreate.Quantity : item.Quantity + 1;
                    }

                    item.Status = 10;

                    if( cartItemCreate.BrandId > 0)
                    {
                        item.Brandid = cartItemCreate.BrandId;
                    }

                    item.Updatedate = forceInfo.DateNow;
                    item.Updateuser = forceInfo.UserId;

                    _petShopContext.Cartitems.Update(item);
                    await _petShopContext.SaveChangesAsync();

                    return item;
                }
                else
                {
                    var cartItem = new Cartitem
                    {
                        Cartid = cart.Id,
                        Productdetailid = cartItemCreate.ProductDetailId,
                        Status = 10,
                        Quantity = cartItemCreate.Quantity <= 0 ? 1 : cartItemCreate.Quantity,
                        Pricediscount = cartItemCreate.PriceDiscount,
                        Createuser = forceInfo.UserId,
                        Createdate = forceInfo.DateNow,
                        Updateuser = forceInfo.UserId,
                        Updatedate = forceInfo.DateNow
                    };

                    if (cartItemCreate.BrandId > 0)
                    {
                        cartItem.Brandid = cartItemCreate.BrandId;
                    }

                    _petShopContext.Cartitems.Add(cartItem);
                    await _petShopContext.SaveChangesAsync();

                    return cartItem;
                }
            }

            return null;
        }

        public async Task<Cartitem> UpdateQuantityCartItem(ForceInfo forceInfo, CartItemUpdateModel cartItemUpdate)
        {
            var item = await _petShopContext.Cartitems.FirstOrDefaultAsync(a => a.Id == cartItemUpdate.CartItemId && 
                                    a.Status == 10 &&
                                    a.Orderid == null &&
                                    a.Createuser == forceInfo.UserId);

            if(item != null)
            {
                item.Quantity = cartItemUpdate.Quantity;
                item.Status = 10;
                item.Updatedate = forceInfo.DateNow;
                item.Updateuser = forceInfo.UserId;

                if(cartItemUpdate.BrandId > 0)
                {
                    item.Brandid = cartItemUpdate.BrandId;
                }

                _petShopContext.Update(item);
                await _petShopContext.SaveChangesAsync();
            }

            return item;
        }

        public async Task<Cartitem> DeteleCartItem(ForceInfo forceInfo, ulong cartItemId)
        {
            var item = await _petShopContext.Cartitems.FirstOrDefaultAsync(a => a.Id == cartItemId &&
                                    a.Status == 10 &&
                                    a.Createuser == forceInfo.UserId);

            if(item != null)
            {
                item.Status = 190;
                item.Updatedate = forceInfo.DateNow;
                item.Updateuser = forceInfo.UserId;

                _petShopContext.Update(item);
                await _petShopContext.SaveChangesAsync();
            }

            return item;
        }

        public async Task UpdateOrderCartItem(List<ulong> cartItemIdList, ulong orderid, ForceInfo forceInfo)
        {
            if( cartItemIdList != null && cartItemIdList.Count() > 0)
            {
                var cartItemEntity = _petShopContext.Cartitems.Where(a => a.Createuser == forceInfo.UserId &&
                                            a.Orderid == null &&
                                            a.Status == 10);

                if(cartItemEntity != null && cartItemEntity.Count() > 0)
                {
                    await cartItemEntity.ForEachAsync(item =>
                   {
                       if (cartItemIdList.Contains(item.Id) && item.Status == 10)
                       {
                           item.Orderid = orderid;
                           item.Status = 10;
                           item.Updatedate = forceInfo.DateNow;
                           item.Updateuser = forceInfo.UserId;
                       }
                   });
                }

                await _petShopContext.SaveChangesAsync();
            }
        }
    }
}
