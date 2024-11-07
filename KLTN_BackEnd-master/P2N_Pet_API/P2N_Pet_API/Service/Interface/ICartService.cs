using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Cart;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service.Interface
{
    public interface ICartService
    {
        Task<ObjectResponse> AddToCart(CartItemCreateModel cartItemCreate, ForceInfo forceInfo);
        Task<ObjectResponse> UpdateQuantityCartItem(ForceInfo forceInfo, CartItemUpdateModel cartItemUpdate);
        Task<ObjectResponse> GetCountQuantityCartItem(ulong userid);
        Task<ObjectResponse> DeleteCartItem(ForceInfo forceInfo, ulong CartItemId);
        Task<ObjectResponse> GetListCartItem(ulong userId);
        Task<ObjectResponse> GetQuantityByProductDetailIdAndUser(ulong productDetailId, ulong userId);
    }
}
