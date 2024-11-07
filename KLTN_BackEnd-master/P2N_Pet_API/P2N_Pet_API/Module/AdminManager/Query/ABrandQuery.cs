using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ABrand;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class ABrandQuery : IABrandQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public ABrandQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<int> QueryCountListBrand(AOSearchBrand aOSearchBrand)
        {
            aOSearchBrand.CurrentDate = string.IsNullOrEmpty(aOSearchBrand.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchBrand.CurrentDate;

            aOSearchBrand.Limit = aOSearchBrand.Limit <= 0 ? 50 : aOSearchBrand.Limit;


            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchBrand.CurrentDate))
            {
                condition += @" and b.createdate <= cast(@CurrentDate as DateTime) ";
            }

            if (string.IsNullOrEmpty(aOSearchBrand.Email))
            {
                condition += @" and b.email like @Email ";
            }

            if (string.IsNullOrEmpty(aOSearchBrand.Phone))
            {
                condition += @" and b.phone like @Phone ";
            }

            if (string.IsNullOrEmpty(aOSearchBrand.Address))
            {
                condition += @" and b.address like @Address ";
            }

            if (aOSearchBrand.Status > 0)
            {
                condition += @" and b.status = @Status";
            }

            var query =
                @"select count(1)
                from brand b
                left join users cu on b.createuser = cu.id
                left join users au on b.updateuser = au.id
                left join status s on s.id = b.status
                where b.status != @StatusExcep and cu.status = 10 and au.status = 10 " + condition + @"
                order by b.status asc";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                Email = "%" + aOSearchBrand.Email + "%",
                Phone = "%" + aOSearchBrand.Phone + "%",
                Address = "%" + aOSearchBrand.Email + "%",
                Status = aOSearchBrand.Status,
                CurrentDate = aOSearchBrand.CurrentDate
            });
        }

        public async Task<List<ABrandListModel>> QueryGetListBrand(AOSearchBrand aOSearchBrand)
        {
            aOSearchBrand.CurrentDate = string.IsNullOrEmpty(aOSearchBrand.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchBrand.CurrentDate;

            aOSearchBrand.Limit = aOSearchBrand.Limit <= 0 ? 50 : aOSearchBrand.Limit;


            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchBrand.CurrentDate))
            {
                condition += @" and b.createdate <= cast(@CurrentDate as DateTime) ";
            }

            if(!string.IsNullOrEmpty(aOSearchBrand.Email))
            {
                condition += @" and b.email like @Email ";
            }

            if (!string.IsNullOrEmpty(aOSearchBrand.Phone))
            {
                condition += @" and b.phone like @Phone ";
            }

            if (!string.IsNullOrEmpty(aOSearchBrand.Address))
            {
                condition += @" and b.address like @Address ";
            }

            if( aOSearchBrand.Status > 0)
            {
                condition += @" and b.status = @Status";
            }

            var query =
                @"select b.Id, ifnull(b.phone, '') Phone, ifnull(b.email, '') Email, ifnull(b.address, '') Address,
	                ifnull(s.title, '') StatusText, b.CreateDate, ifnull(cu.name, '') CreateUserName,
                    b.UpdateDate, ifnull(au.name, '') UpdateUserName
                from brand b
                left join users cu on b.createuser = cu.id
                left join users au on b.updateuser = au.id
                left join status s on s.id = b.status
                where b.status != @StatusExcep and cu.status = 10 and au.status = 10 " + condition + @"
                order by b.status asc
                limit @offset, @limit";

            return await _p2NPetDapper.QueryAsync<ABrandListModel>(query, new
            {
                StatusExcep = 190,
                Email = "%" + aOSearchBrand.Email + "%",
                Phone = "%" + aOSearchBrand.Phone + "%",
                Address = "%" + aOSearchBrand.Address + "%",
                Status = aOSearchBrand.Status,
                CurrentDate = aOSearchBrand.CurrentDate,
                offset = aOSearchBrand.CurrentPage * aOSearchBrand.Limit,
                limit = aOSearchBrand.Limit
            });

        }

        public async Task<ABrandModel> QueryGetDetail(ulong BrandId)
        {
            var query =
                @"select b.Id, ifnull(b.phone, '') Phone, ifnull(b.email, '') Email, ifnull(b.address, '') Address,
	                ifnull(s.title, '') StatusText, b.Status
                from brand b
                left join status s on s.id = b.status
                where b.status != @StatusExcep and b.id = @BrandId";

            var brand = await _p2NPetDapper.QuerySingleAsync<ABrandModel>(query, new
            {
                BrandId = BrandId,
                StatusExcep = 190
            });

            if(brand != null)
            {
                brand.products = await QueryListBrandProduct(BrandId);
            }

            return brand;
        }

        public async Task<List<ABrandProductModel>> QueryListBrandProduct(ulong BrandId)
        {
            var query =
                @"select bp.BrandId, bp.ProductDetailId, pdetail.ProductName, bp.quantity QuantityInBrand
                from brandproduct bp
                left join (
	                select detail.id productdetailid, 
		                case 
		                when product.breedid != 0 then concat(product.breedname, ' - ', c.title, '/ ', s.title)
		                else concat(product.productname, ' - ', s.title)
		                end productname
	                from productdetail detail
	                inner join (
			                select p.id, br.id breedid, br.name breedname, br.breedid breedidroot, root.name breedrootname,
				                sup.id supplierid, sup.name suppliername,
				                ifnull(cate.title, '') categoryname, ifnull(p.productname, '') productname,
				                 ifnull (tp.id, 0) typeproductid, ifnull(tp.title, '') typeproductname
			                from product p
				                left join (select * from breed where status = 10) br on br.id = p.breedid
				                left join (select * from breed where status = 10) root on root.id = br.breedid
				                left join (select * from supplier where status = 10) sup on sup.id = p.supplierid
				                left join ( 
					                select id, title, typeproductid 
					                from category 
					                where status = 10) cate on cate.id = p.categoryid
				                left join typeproduct tp on cate.typeproductid = tp.id
			                where p.status = 10 -- and br.status = 10 and sup.status = 10 and root.status = 10
			                group by p.id
			                order by p.id asc
		                ) product on product.id = detail.productid
	                left join color c on detail.colorid = c.id
	                left join size s on detail.sizeid  = s.id
	                where detail.status = 10
	                order by product.id asc
                ) pdetail on bp.productdetailid = pdetail.productdetailid
                where bp.status = 10 and bp.brandid = @BrandId ";

            return await _p2NPetDapper.QueryAsync<ABrandProductModel>(query, new { BrandId = BrandId });
        }
    }
}
