using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AOrder;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class AOrderService : IAOrderService
    {
        private readonly IAOrderQuery _aOrderQuery;
        private readonly IAOrderAction _aOrderAction;
        private readonly IPaginationService _paginationService;

        public AOrderService(IAOrderQuery aOrderQuery,
            IAOrderAction aOrderAction,
            IPaginationService paginationService)
        {
            _aOrderQuery = aOrderQuery;
            _aOrderAction = aOrderAction;
            _paginationService = paginationService;
        }

        public async Task<List<AOrderListModel>> GetListOrder(AOSearchOrder aOSearchOrder)
        {
            return await _aOrderQuery.QueryGetListOrder(aOSearchOrder);
        }

        public async Task<PaginationModel> GetListOrderPagination(AOSearchOrder aOSearchOrder)
        {
            var count = await _aOrderQuery.QueryCountListOrder(aOSearchOrder);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchOrder.CurrentPage),
                aOSearchOrder.CurrentDate, Convert.ToInt32(aOSearchOrder.Limit));

            return pagination;
        }

        public async Task<ObjectResponse> UpgradeStatusOrder(ForceInfo forceInfo, AOrderUpgradeStatusModel orderUpgradeStatusModel)
        {
            var statusOrderId = await _aOrderQuery.GetStatusOrderId(orderUpgradeStatusModel);

            if (statusOrderId == 1 || statusOrderId == 2)
            {
                await _aOrderAction.UpgradeStatusOrder(forceInfo, orderUpgradeStatusModel, statusOrderId);

                return new ObjectResponse
                {
                    result = 1,
                    message = "Nâng cấp trạng thái đơn hàng thành công!"
                };
            }

            return new ObjectResponse
            {
                result = 0,
                message = "Không thể thực hiện nâng cấp trạng thái!"
            };
        }

        public async Task<ObjectResponse> CancelOrder(ForceInfo forceInfo, AOrderCancelModel orderCancelModel)
        {
            await _aOrderAction.CancelOrder(forceInfo, orderCancelModel);

            return new ObjectResponse
            {
                result = 1,
                message = "Hủy đơn hàng thành công!"
            };
        }

        public async Task<AOrderModel> GetOrderDetail(ulong OrderId)
        {
            var orderDetail = await _aOrderQuery.GetOrderDetail(OrderId);

            if(orderDetail != null)
            {
                orderDetail.OrderItems = await _aOrderQuery.GetListItemDetail(OrderId);
            }

            return orderDetail;
        }

        public async Task<int> GetCountPeding()
        {
            return await _aOrderQuery.GetCountPending();
        }

        public async Task UpdateStatusPayment(ulong orderPaymentId, int statusPaymentId)
        {
            await _aOrderAction.UpdateStatusPayment(orderPaymentId, statusPaymentId);
        }

        public async Task UpdateStatusPendingOrder(DateTime dateNow, ulong userId, ulong orderId)
        {
            await _aOrderAction.UpdateStatusPendingOrder(dateNow, userId, orderId);
        }
    }
}
