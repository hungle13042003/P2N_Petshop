using P2N_Pet_API.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query.Interface
{
    public interface IOrderQuery
    {
        Task<(ulong, ulong)> QueryCartIdAndTotalMoney(ulong userId);
        Task<List<OrderHistoryListModel>> QueryListHistoryOrder(ulong userId, OSearchHistoryProduct oSearchHistoryProduct);
        Task<int> QueryCountHistoryOrder(ulong userId);
        Task<List<OrderDetailModel>> QueryListOrderDetail(ulong userId, ulong orderId);
        Task<OrderModel> QueryOrderDetail(ulong OrderId);
        Task<OrderHistoryListModel> QueryOrderDetailHistory(ulong orderId);
    }
}
