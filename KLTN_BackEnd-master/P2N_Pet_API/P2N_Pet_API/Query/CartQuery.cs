using P2N_Pet_API.Models.Cart;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query
{
    public class CartQuery : ICartQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public CartQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<(int, int)> CheckProductExisted(ulong productDetailId)
        {
            var query =
                @"select count(1), pd.statusdetailid
                from product p
                    left join productdetail pd on pd.productid = p.id
                where p.status = 10 and pd.status = 10 and pd.id = @Id ";

            return await _p2NPetDapper.QuerySingleAsync<(int, int)>(query, new
            {
                Id = productDetailId
            });
        }

        public async Task<List<CartItemListModel>> GetListCartItem(ulong userId)
        {
            var query =
                @"select distinct item.id CartItemId, item.cartid CartId, item.productdetailid ProductDetailId,
                    case when product.breedname != '' then concat(product.breedname, ' - ', col.title)
						when product.categoryname != '' then concat(product.categoryname, ' - ', size.title)
                    end ProductTitle, detail.price Price, 
                    detail.discount Discount, item.pricediscount PriceDiscount,
                    item.quantity Quantity,
                    case 
	                    when ifnull(pimage.image, N'') != '' 
	                    then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pimage.image)
	                    else ifnull(pimage.image, '') 
	                end ProductImage, item.quantity * item.pricediscount TotalPriceItem,
                    detail.Quantity QuantityProduct,
                    ifnull(item.brandid, 0) BrandId, ifnull(brp.address, '') Address
                from cartitem item
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
							left join (select * from breed where status = @Status) br on br.id = p.breedid
							left join (select * from supplier where status = @Status) sup on sup.id = p.supplierid
                            left join (select * from category where status = @Status) cate on cate.id = p.categoryid
                            left join ( select * from typeproduct where status = @Status) tp on tp.id = cate.typeproductid
						where p.status = 10
						group by p.id, br.id, br.name, sup.id, sup.name, p.content, 
							p.categoryid, tp.id, tp.title, cate.title
						order by p.id asc
                    ) product on product.id = detail.productid
                    left join (select * from color where status = @Status) col on col.id = detail.colorid
                    left join (select * from size where status = @Status) size on size.id = detail.sizeid
                    left join (
						select b.id brandid, b.address, bp.productdetailid, bp.quantity quantitybrand
						from brand b
							inner join brandproduct bp on b.id = bp.brandid
						where b.status = @Status and bp.status = @Status and bp.quantity > 0
					) brp on brp.brandid = item.brandid 
                where item.status = 10 and c.status = 10 
                    and detail.statusdetailid = 1 and detail.status = 10 and ifnull(item.orderid, 0) = 0
                    and c.userid = @Id ";

            return await _p2NPetDapper.QueryAsync<CartItemListModel>(query, new
            {
                Id = userId,
                Status = 10
            });
        }

        public async Task<int> GetCountQuantityCartItem(ulong userId)
        {
            //var query =
            //    @"select ifnull(sum(item.quantity), 0)  
            //    from cartitem item
            //        left join cart c on c.id =  item.cartid
            //        left join productdetail detail on detail.id = item.productdetailid
            //        left join (
		          //          select pdim.productdetailid, ifnull(pim.image, '') image
		          //          from (
			         //           select pif.productdetailid, min(pim.id) imageid
			         //           from productimage pim 
				        //            inner join productimagefor pif on pif.productimageid = pim.id
			         //           where pim.status = 10 and pif.status = 10
			         //           group by pif.productdetailid
			         //           ) pdim 
			         //           inner join productimage pim on pim.id = pdim.imageid
		          //          order by pdim.productdetailid asc
	           //         ) pimage
	           //         on pimage.productdetailid = detail.id
            //        inner join (
	           //         select p.id, br.id breedid, br.name breedname,sup.id supplierid, sup.name suppliername, p.content
	           //         from product p
		          //          left join productdetail detail on detail.productid = p.id
		          //          left join breed br on br.id = p.breedid
		          //          left join supplier sup on sup.id = p.supplierid
	           //         where p.status = 10 and br.status = 10 and sup.status = 10
	           //         group by p.id, br.id, br.name, sup.id, sup.name, p.content 
	           //         order by p.id asc
            //        ) product on product.id = detail.productid
            //        left join color col on col.id = detail.colorid
            //    where item.status = 10 and c.status = 10 
            //        and detail.statusdetailid = 1 and detail.status = 10 and ifnull(item.orderid, 0) = 0
            //        and col.status = 10 and c.userid = @Id ";

            var query =
                @"select ifnull(sum(countitem.Quantity), 0) 
                from (select distinct item.id CartItemId, item.cartid CartId, item.productdetailid ProductDetailId,
                    case when product.breedname != '' then concat(product.breedname, ' - ', col.title)
						when product.categoryname != '' then concat(product.categoryname, ' - ', size.title)
                    end ProductTitle, detail.price Price, 
                    detail.discount Discount, item.pricediscount PriceDiscount,
                    item.quantity Quantity,
                    case 
	                    when ifnull(pimage.image, N'') != '' 
	                    then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pimage.image)
	                    else ifnull(pimage.image, '') 
	                end ProductImage, item.quantity * item.pricediscount TotalPriceItem,
                    detail.Quantity QuantityProduct,
                    ifnull(item.brandid, 0) BrandId, ifnull(brp.address, '') Address 
                from cartitem item
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
							left join (select * from breed where status = @Status) br on br.id = p.breedid
							left join (select * from supplier where status = @Status) sup on sup.id = p.supplierid
                            left join (select * from category where status = @Status) cate on cate.id = p.categoryid
                            left join ( select * from typeproduct where status = @Status) tp on tp.id = cate.typeproductid
						where p.status = 10
						group by p.id, br.id, br.name, sup.id, sup.name, p.content, 
							p.categoryid, tp.id, tp.title, cate.title
						order by p.id asc
                    ) product on product.id = detail.productid
                    left join (select * from color where status = @Status) col on col.id = detail.colorid
                    left join (select * from size where status = @Status) size on size.id = detail.sizeid
                    left join (
						select b.id brandid, b.address, bp.productdetailid, bp.quantity quantitybrand
						from brand b
							inner join brandproduct bp on b.id = bp.brandid
						where b.status = @Status and bp.status = @Status and bp.quantity > 0
					) brp on brp.brandid = item.brandid
                where item.status = 10 and c.status = 10 
                    and detail.statusdetailid = 1 and detail.status = 10 and ifnull(item.orderid, 0) = 0
                    and c.userid = @Id) countitem ";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                Id = userId,
                Status = 10
            });
        }

        public async Task<(int, int)> GetQuantityAddCart(ulong productDetailId, ulong cartId)
        {
            var query =
                @"select count(1), quantity
                from cartitem
                where status = 10 and ifnull(orderid, 0) = 0 and productdetailid = @ProductDetailId and cartid = @CartId 
                group by quantity ";

            return await _p2NPetDapper.QuerySingleAsync<(int, int)>(query, new
            {
                ProductDetailId = productDetailId,
                CartId = cartId
            });
        }

        public async Task<ulong> GetCartIdByUser(ulong userId)
        {
            var query =
                @"select ifnull(id, 0) id
                from cart
                where status = 10 and userid = @Id ";

            return await _p2NPetDapper.QuerySingleAsync<ulong>(query, new
            {
                Id = userId
            });
        }

        public async Task<int> QueryCheckCartExisted(ulong userId)
        {
            var query =
                @"select count(1)
                from cart
                where status = 10 and userid = @Id ";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                Id = userId
            });
        }

        public async Task<(int, float, int)> QueryCheckProductDetailExistedAndGetPrice(ulong productDetailId)
        {
            var query =
                @"select count(1), (price * (1 - discount / 100)) PriceDiscount, quantity
                from productdetail
                where statusdetailid = 1 and status = 10 and id = @Id";

            return await _p2NPetDapper.QuerySingleAsync<(int, float, int)>(query, new
            {
                Id = productDetailId
            });
        }

        public async Task<int> GetQuantityCartByIdAndUser(ulong productDetailId, ulong userId)
        {
            var query =
                @"select ifnull(item.quantity, 0) quantity
                from cartitem item
                    left join cart c on c.id = item.cartid
                where item.status = 10 and ifnull(item.orderid, 0) = 0
                    and item.productdetailid = @ProductDetailId and c.userid = @UserId";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                ProductDetailId = productDetailId,
                UserId = userId
            });
        }
    }
}
