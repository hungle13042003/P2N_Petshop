using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Cart;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action.Interface
{
    public interface ICartAction
    {
        Task CreateCartForUser(ForceInfo forceInfo);
        Task<Cartitem> AddToCart(CartItemCreateModel cartItemCreate, ForceInfo forceInfo);

        Task<Cartitem> UpdateQuantityCartItem(ForceInfo forceInfo, CartItemUpdateModel cartItemUpdate);

        Task<Cartitem> DeteleCartItem(ForceInfo forceInfo, ulong cartItemId);
        Task UpdateOrderCartItem(List<ulong> cartItemIdList , ulong orderid, ForceInfo forceInfo);
    }
}
