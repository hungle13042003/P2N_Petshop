using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Database;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class AOrderAction : IAOrderAction
    {
        public readonly PetShopContext _petShopContext;

        public AOrderAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task UpgradeStatusOrder(ForceInfo forceInfo, AOrderUpgradeStatusModel orderUpgradeStatusModel, int statusOrderId)
        {
            var order = _petShopContext.Orders.Where(a => a.Id == orderUpgradeStatusModel.OrderId).FirstOrDefault();

            if (order != null)
            {
                //if (statusOrderId == 1)
                //{
                //    var cartitems = _petShopContext.Cartitems.Where(c => c.Orderid == order.Id);

                //    foreach (var cartitem in cartitems.ToList())
                //    {
                //        var petdetail = _petShopContext.Petdetails.Where(p => p.Id == cartitem.Petdetailid).FirstOrDefault();

                //        petdetail.Quantity = petdetail.Quantity - cartitem.Quantity;

                //        _petShopContext.Petdetails.Update(petdetail);
                //        await _petShopContext.SaveChangesAsync();
                //    }
                //}

                order.Statusorderid = statusOrderId + 1;
                order.Updateuser = forceInfo.UserId;
                order.Updatedate = forceInfo.DateNow;

                if(order.Statusorderid == 3)
                {
                    order.Statuspaymentid = 20;
                }

                _petShopContext.Orders.Update(order);
                await _petShopContext.SaveChangesAsync();
            }
        }

        public async Task CancelOrder(ForceInfo forceInfo, AOrderCancelModel orderCancelModel)
        {
            var order = _petShopContext.Orders.Where(a => a.Id == orderCancelModel.OrderId).FirstOrDefault();

            if (order != null)
            {
                if(order.Statusorderid != 3)
                {
                    var cartitems = _petShopContext.Cartitems.Where(c => c.Orderid == order.Id);

                    foreach(var cartitem in cartitems.ToList())
                    {
                        var productdetail = _petShopContext.Productdetails.Where(p => p.Id == cartitem.Productdetailid).FirstOrDefault();

                        productdetail.Quantity = productdetail.Quantity + cartitem.Quantity;

                        _petShopContext.Productdetails.Update(productdetail);
                        await _petShopContext.SaveChangesAsync();
                    }
                }

                order.Statusorderid = 4;
                order.Updateuser = forceInfo.UserId;
                order.Updatedate = forceInfo.DateNow;

                _petShopContext.Orders.Update(order);
                await _petShopContext.SaveChangesAsync();
            }
        }

        public async Task UpdateStatusPayment(ulong orderPaymentId, int statusPaymentId)
        {
            var order = await _petShopContext.Orders.FirstOrDefaultAsync(a => a.Id == orderPaymentId);

            if(order != null)
            {
                order.Statuspaymentid = statusPaymentId;

                _petShopContext.Orders.Update(order);
                await _petShopContext.SaveChangesAsync();
            }
        }

        public async Task UpdateStatusPendingOrder(DateTime dateNow, ulong userId, ulong orderId)
        {
            var order = await _petShopContext.Orders.FirstOrDefaultAsync(a => a.Id == orderId);

            if(order != null)
            {
                order.Statusorderid = 1;
                order.Updatedate = dateNow;
                order.Updateuser = userId;

                _petShopContext.Orders.Update(order);
                await _petShopContext.SaveChangesAsync();
            }
        }
    }
}
