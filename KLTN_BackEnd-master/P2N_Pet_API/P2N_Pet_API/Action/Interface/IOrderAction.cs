using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Order;
using P2N_Pet_API.Models.UtilsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action.Interface
{
    public interface IOrderAction
    {
        Task<Customer> CreateInforCustomer(OrderCustomerCreateModel orderCustomerCreate, ForceInfo forceInfo);
        Task<Order> CreateOrder(OrderCreateModel orderCreate, ForceInfo forceInfo);
        Task UpdateQuantityProductDetail(ulong orderId, ForceInfo forceInfo);
        Task<Order> CancelOrder(ulong orderId, ForceInfo forceInfo);
        Task SendEmailOrder(ulong orderId, OrderModel orderModel, List<OrderDetailModel> orderDetailModels);
        Task DeleteItemWhenOtherOrdered(ulong orderId, ForceInfo forceInfo);
        Task PaymentMomoSuccess(string orderId);
    }
}
