using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Order;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service
{
    public class OrderService: IOrderService
    {
        private readonly IOrderAction _orderAction;
        private readonly PetShopContext _petShopContext;
        private readonly ICartAction _cartAction;
        private readonly ICartQuery _cartQuery;
        private readonly IOrderQuery _orderQuery;
        private readonly IPaymentMomoService _paymentMomoService;
        private readonly IPaymentVNPayService _paymentVNPayService;
        private readonly IPaginationService _paginationService;

        public OrderService(IOrderAction orderAction,
            PetShopContext petShopContext,
            ICartAction cartAction,
            ICartQuery cartQuery,
            IOrderQuery orderQuery,
            IPaymentMomoService paymentMomoService,
            IPaymentVNPayService paymentVNPayService,
            IPaginationService paginationService)
        {
            _orderAction = orderAction;
            _petShopContext = petShopContext;
            _cartAction = cartAction;
            _cartQuery = cartQuery;
            _orderQuery = orderQuery;
            _paymentMomoService = paymentMomoService;
            _paymentVNPayService = paymentVNPayService;
            _paginationService = paginationService;
        }

        public async Task<Customer> CreateInforCustomer(OrderCustomerCreateModel orderCustomerCreate, ForceInfo forceInfo)
        {
            return await _orderAction.CreateInforCustomer(orderCustomerCreate, forceInfo);
        }

        public async Task<ObjectResponse> CreateOrder(OrderCreateModel orderCreate, ForceInfo forceInfo)
        {

            var customerCreate = new OrderCustomerCreateModel
            {
                Name = orderCreate.Name,
                Address = orderCreate.Address,
                Phone = orderCreate.Phone,
                Email = orderCreate.Email
            };

            try
            {
                var cartItem = await _orderQuery.QueryCartIdAndTotalMoney(forceInfo.UserId);

                if (cartItem == (null, null) || cartItem == (0, 0))
                {
                    return new ObjectResponse
                    {
                        result = 0,
                        message = "Không có sản phẩm để tiến hàng đặt hàng"
                    };
                }

                var customer = await CreateInforCustomer(customerCreate, forceInfo);

                if (customer == null)
                {
                    return new ObjectResponse
                    {
                        result = 0,
                        message = "Đặt hàng thất bại. Vui lòng thử lại"
                    };
                }

                orderCreate.CartId = cartItem.Item1;
                orderCreate.TotalMoney = cartItem.Item2;
                orderCreate.CustomerId = customer.Id;

                var order = await _orderAction.CreateOrder(orderCreate, forceInfo);

                if(order == null)
                {
                    return new ObjectResponse
                    {
                        result = 0,
                        message = "Đặt hàng thất bại. Vui lòng thử lại"
                    };
                }
                else
                {
                    var cartItemList = await _cartQuery.GetListCartItem(forceInfo.UserId);

                    var idList = new List<ulong>();
                    idList = cartItemList.Select(x => x.CartItemId).ToList();

                    await _cartAction.UpdateOrderCartItem(idList, order.Id, forceInfo);
                    await _orderAction.UpdateQuantityProductDetail(order.Id, forceInfo);
                    await _orderAction.DeleteItemWhenOtherOrdered(order.Id, forceInfo);
                    await SendEmailOrder(forceInfo, order.Id);

                    var linkPayment = "";

                    if (orderCreate.TypePaymentId == 20)
                    {
                        linkPayment = await _paymentMomoService.PaymentMomo("Đơn hàng " + order.Id, order.Totalmoney.ToString());
                    }
                    else if(orderCreate.TypePaymentId == 30)
                    {
                        linkPayment = await _paymentVNPayService.PaymentVNPay("Đơn hàng " + order.Id, order.Totalmoney.ToString());
                    }

                    return new ObjectResponse
                    {
                        result = 1,
                        message = "Đặt hàng thành công",
                        content = new
                        {
                            LinkPayment = linkPayment
                        }
                    };
                }

            }
            catch(Exception e)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Đã xảy ra lỗi. Vui lòng thử lại",
                    content = e.Message.ToString()
                };
            }

            
        }

        public async Task<List<OrderHistoryListModel>> GetListHistoryOrder(ForceInfo forceInfo, OSearchHistoryProduct oSearchHistoryProduct)
        {
            return await _orderQuery.QueryListHistoryOrder(forceInfo.UserId, oSearchHistoryProduct);
        }

        public async Task<PaginationModel> GetListHistoryOrderPagination(ForceInfo forceInfo, OSearchHistoryProduct oSearchHistoryProduct)
        {
            var count = await _orderQuery.QueryCountHistoryOrder(forceInfo.UserId);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(oSearchHistoryProduct.CurrentPage),
                Utils.DateNow().ToString(), Convert.ToInt32(oSearchHistoryProduct.Limit));

            return pagination;
        }

        public async Task<ObjectResponse> GetOrderDetail(ForceInfo forceInfo, ulong orderId)
        {
            var order = await _orderQuery.QueryOrderDetailHistory(orderId);

            var detail = await _orderQuery.QueryListOrderDetail(forceInfo.UserId, orderId);

            if (detail == null || detail.Count() == 0)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Xem chi tiết đơn hàng thất bại"
                };
            }

            ulong i = 1;

            detail.ForEach(a =>
            {
                a.Id = i++;
            });

            return new ObjectResponse
            {
                result = 1,
                message = "Xem chi tiết đơn hàng thành công",
                content = new
                {
                    Order = order,
                    OrderDetail = detail
                }
            };
        }

        public async Task<ObjectResponse> CancelOrder(ForceInfo forceInfo, ulong orderId)
        {
            var order = await _orderAction.CancelOrder(orderId, forceInfo);

            if (order == null)
            {
                return new ObjectResponse
                {
                    result = 0,
                    message = "Huỷ đặt hàng thất bại"
                };
            }

            return new ObjectResponse
            {
                result = 1,
                message = "Huỷ đặt hàng thành công",
            };
        }

        public async Task SendEmailOrder(ForceInfo forceInfo, ulong orderId)
        {
            var order = await _orderQuery.QueryOrderDetail(orderId);

            var detail = await _orderQuery.QueryListOrderDetail(forceInfo.UserId, orderId);

            await _orderAction.SendEmailOrder(orderId, order, detail);
        }

        public async Task PaymentMomoSuccess(string orderInfo, int errorCode)
        {
            var orderId = !String.IsNullOrEmpty(orderInfo) ? orderInfo.Replace("Đơn hàng ", "") : "";

            if (errorCode == 0 || errorCode == 9000)
            {
                await _orderAction.PaymentMomoSuccess(orderId);
            }
        }

        public async Task PaymentVNPaySuccess(string orderInfo, string responseCode)
        {
            var orderId = !String.IsNullOrEmpty(orderInfo) ? orderInfo.Replace("Đơn hàng ", "") : "";

            if (responseCode.Trim().Equals("00"))
            {
                await _orderAction.PaymentMomoSuccess(orderId);
            }
        }
    }
}
