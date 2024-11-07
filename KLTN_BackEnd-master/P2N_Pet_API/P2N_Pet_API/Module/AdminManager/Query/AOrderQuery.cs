using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AOrder;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class AOrderQuery : IAOrderQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public AOrderQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<AOrderListModel>> QueryGetListOrder(AOSearchOrder aOSearchOrder)
        {
            aOSearchOrder.Limit = string.IsNullOrEmpty(aOSearchOrder.Limit) ? "10" : aOSearchOrder.Limit;
            aOSearchOrder.CurrentDate = string.IsNullOrEmpty(aOSearchOrder.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchOrder.CurrentDate;
            aOSearchOrder.CurrentPage = string.IsNullOrEmpty(aOSearchOrder.CurrentPage) ? "0" : aOSearchOrder.CurrentPage;
            aOSearchOrder.StatusOrderId = string.IsNullOrEmpty(aOSearchOrder.StatusOrderId) ? "0" : aOSearchOrder.StatusOrderId;
            aOSearchOrder.Status = string.IsNullOrEmpty(aOSearchOrder.Status) ? "0" : aOSearchOrder.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchOrder.CustomerName))
            {
                condition += @" and cu.Name like @CustomerName ";
            }

            if (!string.IsNullOrEmpty(aOSearchOrder.CustomerPhone))
            {
                condition += @" and cu.Phone like @CustomerPhone ";
            }

            if (!string.IsNullOrEmpty(aOSearchOrder.CustomerEmail))
            {
                condition += @" and cu.Email like @CustomerEmail ";
            }

            if (Convert.ToInt32(aOSearchOrder.StatusOrderId) > 0)
            {
                condition += @" and o.statusorderid = @StatusOrderId ";
            }

            if (Convert.ToInt32(aOSearchOrder.TypePaymentId) > 0)
            {
                condition += @" and o.typepaymentid = @TypePaymentId ";
            }

            if (Convert.ToInt32(aOSearchOrder.StatusPaymentId) > 0)
            {
                condition += @" and o.statuspaymentid = @StatusPaymentId ";
            }

            if (Convert.ToInt32(aOSearchOrder.Status) > 0)
            {
                condition += @" and o.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchOrder.CurrentDate))
            {
                condition += @" and o.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select o.Id, ifnull(cu.Name, N'') CustomerName, ifnull(cu.Phone, N'') CustomerPhone, 
                    ifnull(cu.Email, N'') CustomerEmail, o.TotalMoney, ifnull(o.Note, N'') Note, ifnull(st.Title, '') StatusText, 
	                ifnull(uc.Name, N'') CreateUserName, o.CreateDate, ifnull(up.Name, N'') UpdateUserName, o.UpdateDate, 
                    ifnull(o.typepaymentid, 0) TypePaymentId, ifnull(o.statuspaymentid, 0) StatusPaymentId, 
                    ifnull(tp.title, N'Khi nhận hàng') TypePaymentName, ifnull(sp.title, N'Chưa thanh toán') StatusPaymentName 
                from `order` o
                    left join customer cu on cu.id = o.customerid
	                left join status st on st.id = o.status
                    left join users uc on uc.id = o.createuser
                    left join users up on up.id = o.updateuser 
                    left join typepayment tp on tp.id = o.typepaymentid 
                    left join statuspayment sp on sp.id = o.statuspaymentid 
                where o.status != @StatusExcep and cu.status = @StatusCustomer " + condition + @" 
                order by o.status asc, o.updatedate desc, o.id desc  
                limit " + Convert.ToInt32(aOSearchOrder.Limit) * Convert.ToInt32(aOSearchOrder.CurrentPage) + @", " + aOSearchOrder.Limit + @";";

            return await _p2NPetDapper.QueryAsync<AOrderListModel>(query, new
            {
                StatusExcep = 190,
                StatusCustomer = 10,
                CustomerName = "%" + aOSearchOrder.CustomerName + "%",
                CustomerPhone = "%" + aOSearchOrder.CustomerPhone + "%",
                CustomerEmail = "%" + aOSearchOrder.CustomerEmail + "%",
                TypePaymentId = aOSearchOrder.TypePaymentId,
                StatusPaymentId = aOSearchOrder.StatusPaymentId,
                StatusOrderId = aOSearchOrder.StatusOrderId,
                Status = aOSearchOrder.Status,
                CurrentDate = aOSearchOrder.CurrentDate
            });
        }

        public async Task<int> QueryCountListOrder(AOSearchOrder aOSearchOrder)
        {
            aOSearchOrder.Limit = string.IsNullOrEmpty(aOSearchOrder.Limit) ? "10" : aOSearchOrder.Limit;
            aOSearchOrder.CurrentDate = string.IsNullOrEmpty(aOSearchOrder.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchOrder.CurrentDate;
            aOSearchOrder.CurrentPage = string.IsNullOrEmpty(aOSearchOrder.CurrentPage) ? "0" : aOSearchOrder.CurrentPage;
            aOSearchOrder.StatusOrderId = string.IsNullOrEmpty(aOSearchOrder.StatusOrderId) ? "0" : aOSearchOrder.StatusOrderId;
            aOSearchOrder.Status = string.IsNullOrEmpty(aOSearchOrder.Status) ? "0" : aOSearchOrder.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchOrder.CustomerName))
            {
                condition += @" and cu.Name like @CustomerName ";
            }

            if (!string.IsNullOrEmpty(aOSearchOrder.CustomerPhone))
            {
                condition += @" and cu.Phone like @CustomerPhone ";
            }

            if (!string.IsNullOrEmpty(aOSearchOrder.CustomerEmail))
            {
                condition += @" and cu.Email like @CustomerEmail ";
            }

            if (Convert.ToInt32(aOSearchOrder.StatusOrderId) > 0)
            {
                condition += @" and o.statusorderid = @StatusOrderId ";
            }

            if (Convert.ToInt32(aOSearchOrder.TypePaymentId) > 0)
            {
                condition += @" and o.typepaymentid = @TypePaymentId ";
            }

            if (Convert.ToInt32(aOSearchOrder.StatusPaymentId) > 0)
            {
                condition += @" and o.statuspaymentid = @StatusPaymentId ";
            }

            if (Convert.ToInt32(aOSearchOrder.Status) > 0)
            {
                condition += @" and o.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchOrder.CurrentDate))
            {
                condition += @" and o.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select count(1) 
                from `order` o
                    left join customer cu on cu.id = o.customerid
	                left join status st on st.id = o.status
                    left join users uc on uc.id = o.createuser
                    left join users up on up.id = o.updateuser
                where o.status != @StatusExcep and cu.status = @StatusCustomer " + condition + @" ;";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                StatusCustomer = 10,
                CustomerName = "%" + aOSearchOrder.CustomerName + "%",
                CustomerPhone = "%" + aOSearchOrder.CustomerPhone + "%",
                CustomerEmail = "%" + aOSearchOrder.CustomerEmail + "%",
                StatusOrderId = aOSearchOrder.StatusOrderId,
                TypePaymentId = aOSearchOrder.TypePaymentId,
                StatusPaymentId = aOSearchOrder.StatusPaymentId,
                Status = aOSearchOrder.Status,
                CurrentDate = aOSearchOrder.CurrentDate
            });
        }

        public async Task<int> GetStatusOrderId(AOrderUpgradeStatusModel orderUpgradeStatusModel)
        {
            var query =
                @"select statusorderid 
                from `order`
                where status = @Status and id = @OrderId";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                Status = 10,
                OrderId = orderUpgradeStatusModel.OrderId
            });
        }

        public async Task<AOrderModel> GetOrderDetail(ulong OrderId)
        {
            var query =
                @"select o.Id, ifnull(u.Name, N'') UserName, ifnull(u.Phone, N'') UserPhone, ifnull(u.Email, N'') UserEmail, 
                    ifnull(u.Address, N'') UserAddress, ifnull(cu.Name, N'') CustomerName, ifnull(cu.Phone, N'') CustomerPhone, 
                    ifnull(cu.Email, N'') CustomerEmail, ifnull(cu.Address, N'') CustomerAddress, o.TotalMoney, ifnull(o.Note, N'') Note, 
                    ifnull(o.typepaymentid, 0) TypePaymentId, ifnull(o.statuspaymentid, 0) StatusPaymentId, 
                    ifnull(tp.title, N'Khi nhận hàng') TypePaymentName, ifnull(sp.title, N'Chưa thanh toán') StatusPaymentName 
                from `order` o inner join cart c on c.id = o.cartid
	                inner join users u on u.id = c.userid 
                    inner join customer cu on cu.id = o.customerid 
                    left join typepayment tp on tp.id = o.typepaymentid 
                    left join statuspayment sp on sp.id = o.statuspaymentid 
                where o.status = @Status and c.status = @Status and u.status = @Status and cu.status = @Status and o.id = @OrderId;";

            return await _p2NPetDapper.QuerySingleAsync<AOrderModel>(query, new
            {
                Status = 10,
                OrderId = OrderId
            });
        }

        public async Task<List<AOrderItemModel>> GetListItemDetail(ulong OrderId)
        {
            //var query =
            //    @"select c.Id, ifnull(b.Name, N'') ProductName, 
            //     case 
            //     when ifnull(pimage.image, N'') != '' 
            //     then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pimage.image)
            //     else ifnull(pimage.image, '') 
            //     end ProductImage, ifnull(cl.Title, N'') ColorTitle, ifnull(si.Title, N'') SizeTitle,
            //     ifnull(ag.Title, N'') AgeTitle, ifnull(se.Title, N'') SexTitle, pd.Price, 
            //        pd.Discount, (c.PriceDiscount*c.Quantity) Total, c.Quantity  
            //    from cartitem c 
            //        inner join productdetail pd on pd.id = c.productdetailid
            //     inner join product p on p.id = pd.productid 
            //        left join color cl on cl.id = pd.colorid
            //        left join size si on si.id = pd.sizeid
            //        left join age ag on ag.id = pd.ageid 
            //        left join sex se on se.id = pd.sexid 
            //        left join breed b on b.id = p.breedid 
            //     left join
            //         (select pdim.productdetailid, ifnull(pim.image, '') image
            //         from (select pif.productdetailid, min(pim.id) imageid
            //          from productimage pim inner join productimagefor pif on pif.productimageid = pim.id
            //          where pim.status = @Status and pif.status = @Status
            //          group by pif.productdetailid) pdim 
            //          inner join productimage pim on pim.id = pdim.imageid) pimage
            //     on pimage.productdetailid = pd.id
            //    where c.status = @Status and pd.status = @Status and c.orderid = @OrderId;";

            var query =
                @"select c.Id, 
	                case when ifnull(b.Name, N'') != '' then ifnull(b.Name, N'')
		                when ifnull(cate.title, '') != '' then ifnull(cate.title, '')
                        else ''
                    end ProductName, 
	                case 
	                when ifnull(pimage.image, N'') != '' 
	                then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pimage.image)
	                else ifnull(pimage.image, '') 
	                end ProductImage, ifnull(cl.Title, N'') ColorTitle, ifnull(si.Title, N'') SizeTitle,
	                ifnull(ag.Title, N'') AgeTitle, ifnull(se.Title, N'') SexTitle, pd.Price, 
                    pd.Discount, (c.PriceDiscount*c.Quantity) Total, c.Quantity  
                from cartitem c 
                    inner join productdetail pd on pd.id = c.productdetailid
	                inner join product p on p.id = pd.productid 
                    left join color cl on cl.id = pd.colorid
                    left join size si on si.id = pd.sizeid
                    left join age ag on ag.id = pd.ageid 
                    left join sex se on se.id = pd.sexid 
                    left join breed b on b.id = p.breedid
                    left join category cate on cate.id = p.categoryid and cate.status = @Status
	                left join
	                    (select pdim.productdetailid, ifnull(pim.image, '') image
	                    from (select pif.productdetailid, min(pim.id) imageid
		                    from productimage pim inner join productimagefor pif on pif.productimageid = pim.id
		                    where pim.status = @Status and pif.status = @Status
		                    group by pif.productdetailid) pdim 
		                    inner join productimage pim on pim.id = pdim.imageid) pimage
	                on pimage.productdetailid = pd.id
                where c.status = @Status and pd.status = @Status and c.orderid = @OrderId ";

            return await _p2NPetDapper.QueryAsync<AOrderItemModel>(query, new
            {
                Status = 10,
                OrderId = OrderId
            });
        }

        public async Task<int> GetCountPending()
        {
            var query =
                @"select count(1)
                from `order`
                where status = @Status and statusorderid = @StatusOrderPending;";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                Status = 10,
                StatusOrderPending = 1
            });
        }
    }
}
