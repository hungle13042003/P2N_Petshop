using P2N_Pet_API.Models.Order;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query
{
    public class OrderQuery : IOrderQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public OrderQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<(ulong, ulong)> QueryCartIdAndTotalMoney(ulong userId)
        {
            var query =
                @"select item.cartid, sum(item.pricediscount * item.quantity) totalmoney
                from cartitem item
		            left join cart c on c.id = item.cartid
                    left join users u on u.id = c.userid
	            where item.status = 10 and c.status = 10 and c.userid = @Id and ifnull(item.orderid, 0) = 0
                group by item.cartid";

            return await _p2NPetDapper.QuerySingleAsync<(ulong, ulong)>(query, new
            {
                Id = userId
            });
        }

        public async Task<List<OrderHistoryListModel>> QueryListHistoryOrder(ulong userId, OSearchHistoryProduct oSearchHistoryProduct)
        {
            var query =
                @"select o.id OrderId,  o.createdate CreateOrder, item.totalmoney TotalMoney, 
	                item.numorder NumOrder, c.address Address, o.statusorderid StatusOrderId, std.title StatusOrderText,
                    item.numbreed NumBreed, c.name CustomerName, c.email Email, c.phone Phone, ifnull(tp.title, N'Khi nhận hàng') TypePaymentName,
                    ifnull(sp.title, N'Chưa thanh toán') StatusPaymentName 
                from `order` o
                left join (
	                select item.orderid orderid, count(1) numbreed, sum(item.quantity) numorder, sum(item.pricediscount * item.quantity) totalmoney
                    from cartitem item
		                left join cart c on c.id = item.cartid
	                where item.status = 10
                    group by item.orderid
                ) item on item.orderid = o.id
                left join customer c on c.id = o.customerid
                left join users u on u.id = c.userid
                left join statusorder std on std.id = o.statusorderid 
                left join typepayment tp on tp.id = o.typepaymentid 
                left join statuspayment sp on sp.id = o.statuspaymentid 
                where o.status = 10 and std.status = 10 and u.status = 10 and u.id = @Id
	               -- and datediff( @DateNow , o.createdate) < 365 
                order by o.createdate desc 
                limit @Offset, @Limit ";

            return await _p2NPetDapper.QueryAsync<OrderHistoryListModel>(query, new
            {
                Id = userId,
                DateNow = Utils.DateNow(),
                Offset = oSearchHistoryProduct.CurrentPage * oSearchHistoryProduct.Limit,
                Limit = oSearchHistoryProduct.Limit
            });

        }

        public async Task<int> QueryCountHistoryOrder(ulong userId)
        {
            var query =
                @"select count(1)  
                from `order` o
                left join (
	                select item.orderid orderid, count(1) numbreed, sum(item.quantity) numorder, sum(item.pricediscount * item.quantity) totalmoney
                    from cartitem item
		                left join cart c on c.id = item.cartid
	                where item.status = 10
                    group by item.orderid
                ) item on item.orderid = o.id
                left join customer c on c.id = o.customerid
                left join users u on u.id = c.userid
                left join statusorder std on std.id = o.statusorderid 
                left join typepayment tp on tp.id = o.typepaymentid 
                left join statuspayment sp on sp.id = o.statuspaymentid 
                where o.status = 10 and std.status = 10 and u.status = 10 and u.id = @Id
	               -- and datediff( @DateNow , o.createdate) < 365 ";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                Id = userId,
                DateNow = Utils.DateNow()
            });

        }

        public async Task<List<OrderDetailModel>> QueryListOrderDetail(ulong userId, ulong orderId)
        {
            var query =
                @"select case when product.breedname != '' then concat(product.breedname, ' - ', col.title)
						when product.categoryname != '' then concat(product.categoryname, ' - ', size.title)
                    end ProductTitle, detail.price Price, 
                    detail.discount Discount, item.pricediscount PriceDiscount,
                    item.quantity Quantity,
                    case 
	                    when ifnull(pimage.image, N'') != '' 
	                    then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pimage.image)
	                    else ifnull(pimage.image, '') 
                    end ProductImage, item.quantity * item.pricediscount TotalPriceItem
                from `order` o
                    left join cartitem item on item.orderid = o.id
                    left join cart c on c.id =  item.cartid
                    left join productdetail detail on detail.id = item.productdetailid
                    left join (
		                    select pdim.productdetailid, ifnull(pim.image, '') image
		                    from (
			                    select pif.productdetailid, min(pim.id) imageid
			                    from productimage pim 
				                    inner join productimagefor pif on pif.productimageid = pim.id
			                    where pim.status = 10 and pif.status = 10
			                    group by pif.productdetailid
			                    ) pdim 
			                    inner join productimage pim on pim.id = pdim.imageid
		                    order by pdim.productdetailid asc
	                    ) pimage
	                    on pimage.productdetailid = detail.id
                    inner join (
	                    select p.id, ifnull(br.id, 0) breedid, ifnull(br.name, '') breedname, sup.id supplierid, sup.name suppliername, p.content,
							ifnull(tp.id, 10) typeproductid, ifnull(tp.title, 'Thú cưng') typeproductname,
                            ifnull(p.categoryid, 0) categoryid, ifnull(cate.title, '') categoryname
						from product p
							left join productdetail detail on detail.productid = p.id
							left join (select * from breed where status = 10) br on br.id = p.breedid
							left join (select * from supplier where status = 10) sup on sup.id = p.supplierid
                            left join (select * from category where status = 10) cate on cate.id = p.categoryid
                            left join ( select * from typeproduct where status = 10) tp on tp.id = cate.typeproductid
						where p.status = 10
						group by p.id, br.id, br.name, sup.id, sup.name, p.content, 
							p.categoryid, tp.id, tp.title, cate.title
						order by p.id asc
                    ) product on product.id = detail.productid 
                    left join (select * from color where status = 10) col on col.id = detail.colorid 
                    left join (select * from size where status = 10) size on size.id = detail.sizeid 
                where item.status = 10 and c.status = 10 
                    and detail.status = 10 and c.userid = @UserId and o.id = @OrderId";

            return await _p2NPetDapper.QueryAsync<OrderDetailModel>(query, new
            {
                UserId = userId,
                OrderId = orderId
            });
        }

        public async Task<OrderModel> QueryOrderDetail(ulong OrderId)
        {
            var query =
                @"select o.Id, ifnull(u.Name, N'') UserName, ifnull(u.Phone, N'') UserPhone, ifnull(u.Email, N'') UserEmail, 
                    ifnull(u.Address, N'') UserAddress, ifnull(cu.Name, N'') CustomerName, ifnull(cu.Phone, N'') CustomerPhone, 
                    ifnull(cu.Email, N'') CustomerEmail, ifnull(cu.Address, N'') CustomerAddress, o.TotalMoney, ifnull(o.Note, N'') Note 
                from `order` o inner join cart c on c.id = o.cartid
	                inner join users u on u.id = c.userid 
                    inner join customer cu on cu.id = o.customerid
                where o.status = @Status and c.status = @Status and u.status = @Status and cu.status = @Status and o.id = @OrderId;";

            return await _p2NPetDapper.QuerySingleAsync<OrderModel>(query, new
            {
                Status = 10,
                OrderId = OrderId
            });
        }

        public async Task<OrderHistoryListModel> QueryOrderDetailHistory(ulong orderId)
        {
            var query =
                @"select o.id OrderId,  o.createdate CreateOrder, item.totalmoney TotalMoney, 
	                item.numorder NumOrder, c.address Address, o.statusorderid StatusOrderId, std.title StatusOrderText,
                    item.numbreed NumBreed, c.name CustomerName, c.email Email, c.phone Phone,  ifnull(o.Note, N'') Note 
                from `order` o
                left join (
	                select item.orderid orderid, count(1) numbreed, sum(item.quantity) numorder, sum(item.pricediscount * item.quantity) totalmoney
                    from cartitem item
		                left join cart c on c.id = item.cartid
	                where item.status = 10
                    group by item.orderid
                ) item on item.orderid = o.id
                left join customer c on c.id = o.customerid
                left join users u on u.id = c.userid
                left join statusorder std on std.id = o.statusorderid
                where o.status = 10 and std.status = 10 and u.status = 10 and o.id = @Id ";

            return await _p2NPetDapper.QuerySingleAsync<OrderHistoryListModel>(query, new 
            {
                Id = orderId
            });
        }
    }
}
