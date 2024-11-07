using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IAOrderService
    {
        Task<List<AOrderListModel>> GetListOrder(AOSearchOrder aOSearchOrder);
        Task<PaginationModel> GetListOrderPagination(AOSearchOrder aOSearchOrder);
        Task<ObjectResponse> UpgradeStatusOrder(ForceInfo forceInfo, AOrderUpgradeStatusModel orderUpgradeStatusModel);
        Task<ObjectResponse> CancelOrder(ForceInfo forceInfo, AOrderCancelModel orderCancelModel);
        Task<AOrderModel> GetOrderDetail(ulong OrderId);
        Task<int> GetCountPeding();
        Task UpdateStatusPayment(ulong orderPaymentId, int statusPaymentId);
        Task UpdateStatusPendingOrder(DateTime dateNow, ulong userId, ulong orderId);
    }
}
