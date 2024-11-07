using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Order;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action
{
    [Obsolete]
    public class OrderAction: IOrderAction
    {
        private readonly PetShopContext _petShopContext;
        private readonly IHostingEnvironment _env;
        private readonly IEmailService _emailService;

        public OrderAction(PetShopContext petShopContext,
            IHostingEnvironment env,
            IEmailService emailService)
        {
            _petShopContext = petShopContext;
            _env = env;
            _emailService = emailService;
        }

        public async Task<Customer> CreateInforCustomer(OrderCustomerCreateModel orderCustomerCreate, ForceInfo forceInfo)
        {
            var user = await _petShopContext.Users.FirstOrDefaultAsync(a => a.Id == forceInfo.UserId);

            if(user == null)
            {
                return null;
            }

            var customer = new Customer
            {
                Userid = user.Id,
                Name = string.IsNullOrEmpty(orderCustomerCreate.Name) ? user.Name : orderCustomerCreate.Name.Trim(),
                Address = string.IsNullOrEmpty(orderCustomerCreate.Address) ? user.Address : orderCustomerCreate.Address.Trim(),
                Phone = string.IsNullOrEmpty(orderCustomerCreate.Phone) ? user.Phone : orderCustomerCreate.Phone.Trim(),
                Email = string.IsNullOrEmpty(orderCustomerCreate.Email) ? user.Email : orderCustomerCreate.Email.Trim(),
                Status = 10,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Customers.Add(customer);
            await _petShopContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Order> CreateOrder(OrderCreateModel orderCreate, ForceInfo forceInfo)
        {
            var order = new Order
            {
                Cartid = orderCreate.CartId,
                Customerid = orderCreate.CustomerId,
                Statusorderid = 1,
                Totalmoney = orderCreate.TotalMoney,
                Typepaymentid = orderCreate.TypePaymentId,
                Statuspaymentid = 10,
                Status = 10,
                Note = orderCreate.Note,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Orders.Add(order);
            await _petShopContext.SaveChangesAsync();

            return order;
        }

        public async Task UpdateQuantityProductDetail(ulong orderId, ForceInfo forceInfo)
        {
            var productDetailEntity = _petShopContext.Productdetails.Where(a => a.Status == 10 && a.Statusdetailid == 1);

            var cartItemEntity = _petShopContext.Cartitems.Where(a => a.Orderid == orderId
                                              && a.Status == 10).ToList();

            var brandCartId = cartItemEntity.Where(c => c.Brandid != null).Select(c => c.Brandid).ToList();
            var brandProductEntity = _petShopContext.Brandproducts.Where(b => brandCartId.Contains(b.Brandid)).ToList();

            if ( productDetailEntity != null && productDetailEntity.Count() > 0 &&
                cartItemEntity != null && cartItemEntity.Count() > 0)
            {
                await productDetailEntity.ForEachAsync(p =>
               {
                   var existItem = cartItemEntity.Where(a => a.Productdetailid == p.Id).FirstOrDefault();

                   if (existItem != null && p.Quantity >= existItem.Quantity)
                   {
                       p.Quantity = p.Quantity - existItem.Quantity;
                       p.Updateuser = forceInfo.UserId;
                       p.Updatedate = forceInfo.DateNow;
                   }

                   if (existItem != null && brandCartId.Contains(existItem.Brandid))
                   {
                       var brandProduct = brandProductEntity.Where(b => b.Brandid == existItem.Brandid && b.Productdetailid == p.Id).FirstOrDefault();
                       if (brandProduct != null)
                       {
                           if (brandProduct.Quantity > existItem.Quantity)
                           {
                               brandProductEntity.Where(b => b.Brandid == existItem.Brandid && b.Productdetailid == p.Id).FirstOrDefault().Quantity = brandProduct.Quantity - existItem.Quantity;
                           }
                       }
                   }    
                   
                   if (p.Quantity <= 0)
                   {
                       p.Statusdetailid = 3;
                       p.Updatedate = forceInfo.DateNow;
                   }
               });

                _petShopContext.Brandproducts.UpdateRange(brandProductEntity);
            }

            await _petShopContext.SaveChangesAsync();
        }

        public async Task<Order> CancelOrder(ulong orderId, ForceInfo forceInfo)
        {
            var order = await _petShopContext.Orders.FirstOrDefaultAsync(a => a.Id == orderId &&
                               a.Statusorderid == 1);

            if(order != null)
            {
                var cartitems = _petShopContext.Cartitems.Where(c => c.Orderid == order.Id && c.Status == 10);

                foreach (var cartitem in cartitems.ToList())
                {
                    var productdetail = _petShopContext.Productdetails.Where(p => p.Id == cartitem.Productdetailid).FirstOrDefault();

                    productdetail.Quantity = productdetail.Quantity + cartitem.Quantity;

                    _petShopContext.Productdetails.Update(productdetail);
                    await _petShopContext.SaveChangesAsync();
                }

                order.Statusorderid = 4;
                order.Updateuser = forceInfo.UserId;
                order.Updatedate = forceInfo.DateNow;

                _petShopContext.Orders.Update(order);
                await _petShopContext.SaveChangesAsync();
            }

            return order;
        }

        public async Task SendEmailOrder(ulong orderId, OrderModel orderModel, List<OrderDetailModel> orderDetailModels)
        {
            string content = "";
            string subject = "P2N Pet_Đơn hàng #" + orderId.ToString();

            var absoPath = Path.Combine("wwwroot", "Assets", "Template", "Email", "OrderForm.html");
            var pathTemp = Path.Combine(_env.ContentRootPath, absoPath);

            content = File.ReadAllText(pathTemp);

            string orderdetail = @"";

            if(orderDetailModels.Count > 0)
            {
                foreach(var orderDetailModel in orderDetailModels)
                {
                    orderdetail +=
                        @" <tr>
                                <td width = '25%' align = 'center' style = 'font-family: Open Sans, Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 24px; padding: 15px 10px 5px 10px;'> <b>" + orderDetailModel.ProductTitle + @"</b> </td>
                                <td width = '25%' align = 'center' style = 'font-family: Open Sans, Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 24px; padding: 15px 10px 5px 10px;' > " + orderDetailModel.Quantity.ToString() + @" </ td > 
                                <td width = '25%' align = 'center' style = 'font-family: Open Sans, Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 24px; padding: 15px 10px 5px 10px;' > " + String.Format("{0:0,0}", orderDetailModel.PriceDiscount) + @" </ td >
                                <td width = '25%' align = 'center' style = 'font-family: Open Sans, Helvetica, Arial, sans-serif; font-size: 16px; font-weight: 400; line-height: 24px; padding: 15px 10px 5px 10px;' > " + String.Format("{0:0,0}", orderDetailModel.TotalPriceItem) + @" </ td >
                           </tr> ";
                }
            }

            content = content.Replace("{{name}}", orderModel.CustomerName);
            content = content.Replace("{{phone}}", orderModel.CustomerPhone);
            content = content.Replace("{{address}}", orderModel.CustomerAddress);
            content = content.Replace("{{total}}", String.Format("{0:0,0} VNĐ", orderModel.TotalMoney));

            content = content.Replace("{{orderdetail}}", orderdetail);

            _emailService.Send(orderModel.CustomerEmail.Trim(), subject, content);
        }

        public async Task DeleteItemWhenOtherOrdered(ulong orderId, ForceInfo forceInfo)
        {
            var itemMeOrder = _petShopContext.Cartitems.Where(a => a.Orderid == orderId &&
                                        a.Status == 10).ToList();

            foreach ( var i in itemMeOrder)
            {
                var itemOtherOrder = _petShopContext.Cartitems.Where(a => a.Orderid == null &&
                                       a.Productdetailid == i.Productdetailid &&
                                       a.Status == 10).ToList();

                var productQuantity = _petShopContext.Productdetails.Where(p => p.Id == i.Productdetailid &&
                                        p.Statusdetailid != 2 &&
                                        p.Status == 10).FirstOrDefault();

                foreach( var a in itemOtherOrder)
                {
                    if (a.Quantity > productQuantity.Quantity)
                    {
                        a.Status = 190;
                        a.Quantity = 0;
                        a.Updatedate = forceInfo.DateNow;
                        a.Updateuser = forceInfo.UserId;
                    }

                    _petShopContext.Cartitems.Update(a);
                    await _petShopContext.SaveChangesAsync();
                }
            }
            
        }

        public async Task PaymentMomoSuccess(string orderId)
        {
            var order = await _petShopContext.Orders.FirstOrDefaultAsync(a => a.Id == Convert.ToUInt64(orderId));

            if(order != null)
            {
                order.Statusorderid = 2;
                order.Statuspaymentid = 20;

                _petShopContext.Orders.Update(order);
                await _petShopContext.SaveChangesAsync();
            }
        }
    }
}
