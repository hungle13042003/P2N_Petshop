using P2N_Pet_API.Module.AdminManager.Models.AOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IAOrderQuery
    {
        Task<List<AOrderListModel>> QueryGetListOrder(AOSearchOrder aOSearchOrder);
        Task<int> QueryCountListOrder(AOSearchOrder aOSearchOrder);
        Task<int> GetStatusOrderId(AOrderUpgradeStatusModel orderUpgradeStatusModel);
        Task<AOrderModel> GetOrderDetail(ulong OrderId);
        Task<List<AOrderItemModel>> GetListItemDetail(ulong OrderId);
        Task<int> GetCountPending();
    }
}
