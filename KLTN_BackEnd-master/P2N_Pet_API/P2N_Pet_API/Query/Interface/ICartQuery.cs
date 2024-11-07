using P2N_Pet_API.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query.Interface
{
    public interface ICartQuery
    {
        Task<(int, float, int)> QueryCheckProductDetailExistedAndGetPrice(ulong productDetailId);
        Task<(int, int)> CheckProductExisted(ulong productDetailId);
        Task<int> QueryCheckCartExisted(ulong userId);
        Task<List<CartItemListModel>> GetListCartItem(ulong userId);
        Task<int> GetCountQuantityCartItem(ulong userId);
        Task<(int, int)> GetQuantityAddCart(ulong productDetailId, ulong cartId);
        Task<ulong> GetCartIdByUser(ulong userId);
        Task<int> GetQuantityCartByIdAndUser(ulong productDetailId, ulong userId);
    }
}
