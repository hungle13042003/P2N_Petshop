using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IAOrderAction
    {
        Task UpgradeStatusOrder(ForceInfo forceInfo, AOrderUpgradeStatusModel orderUpgradeStatusModel, int statusOrderId);
        Task CancelOrder(ForceInfo forceInfo, AOrderCancelModel orderCancelModel);
        Task UpdateStatusPayment(ulong orderPaymentId, int statusPaymentId);
        Task UpdateStatusPendingOrder(DateTime dateNow, ulong userId, ulong orderId);
    }
}
