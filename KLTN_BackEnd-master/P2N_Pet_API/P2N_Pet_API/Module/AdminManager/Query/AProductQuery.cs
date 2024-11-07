using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AProduct;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class AProductQuery : IAProductQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public AProductQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<AProductListModel>> QueryGetListProduct(AOSearchProduct aOSearchProduct)
        {
            aOSearchProduct.Limit = string.IsNullOrEmpty(aOSearchProduct.Limit) ? "10" : aOSearchProduct.Limit;
            aOSearchProduct.CurrentDate = string.IsNullOrEmpty(aOSearchProduct.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchProduct.CurrentDate;
            aOSearchProduct.CurrentPage = string.IsNullOrEmpty(aOSearchProduct.CurrentPage) ? "0" : aOSearchProduct.CurrentPage;
            aOSearchProduct.BreedId = string.IsNullOrEmpty(aOSearchProduct.BreedId) ? "0" : aOSearchProduct.BreedId;
            aOSearchProduct.SupplierId = string.IsNullOrEmpty(aOSearchProduct.SupplierId) ? "0" : aOSearchProduct.SupplierId;
            aOSearchProduct.Status = string.IsNullOrEmpty(aOSearchProduct.Status) ? "0" : aOSearchProduct.Status;

            var condition = @"";

            if (Convert.ToInt32(aOSearchProduct.BreedId) > 0)
            {
                condition += @" and p.breedid = @BreedId ";
            }

            if (Convert.ToInt32(aOSearchProduct.SupplierId) > 0)
            {
                condition += @" and p.supplierid = @SupplierId ";
            }

            if (Convert.ToInt32(aOSearchProduct.Status) > 0)
            {
                condition += @" and p.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchProduct.CurrentDate))
            {
                condition += @" and p.createdate <= cast(@CurrentDate as DateTime) ";
            }

            if(aOSearchProduct.CategoryId > 0)
            {
                condition += @" and ifnull(p.categoryid, 0) = @CategoryId ";
            }

            if (aOSearchProduct.TypeProductId > 0)
            {
                condition += @" and ifnull(tp.id, 10) = @TypeProductId ";
            }

            var query =
                @"select p.Id, ifnull(b.Name, N'') BreedName, ifnull(su.Name, N'') SupplierName, ifnull(p.Content, N'') Content, 
                    ifnull(st.Title, N'') StatusText, ifnull(uc.Name, N'') CreateUserName, p.CreateDate, ifnull(up.Name, N'') UpdateUserName, 
                    p.UpdateDate, ifnull(p.ProductName, '') ProductName, ifnull(p.CategoryId, 0) CategoryId, ifnull(c.title, '') CategoryName, 
                    ifnull(c.typeproductid, 10) TypeProductId, 
                    case when ifnull(c.typeproductid, 10) = 10 then 'Thú cưng'
                     else ifnull(tp.title, '')
                     end TypeProductName 
                from product p  
                    left join (select * from breed where status = @StatusRoot) b on b.id = p.breedid 
                    left join (select * from supplier where status = @StatusRoot )su on su.id = p.supplierid 
	                left join status st on st.id = p.status
                    left join users uc on uc.id = p.createuser
                    left join users up on up.id = p.updateuser
                    left join (select * from category where status = @StatusRoot) c on c.id = p.categoryid
                    left join typeproduct tp on tp.id = c.typeproductid
                where p.status != @StatusExcep " + condition + @"
                order by p.createdate desc, p.status asc, b.name collate utf8_unicode_ci asc, su.name collate utf8_unicode_ci asc  
                limit " + Convert.ToInt32(aOSearchProduct.Limit) * Convert.ToInt32(aOSearchProduct.CurrentPage) + @", " + aOSearchProduct.Limit + @";";

            return await _p2NPetDapper.QueryAsync<AProductListModel>(query, new
            {
                StatusExcep = 190,
                StatusRoot = 10,
                BreedId = aOSearchProduct.BreedId,
                SupplierId = aOSearchProduct.SupplierId,
                Status = aOSearchProduct.Status,
                CurrentDate = aOSearchProduct.CurrentDate,
                CategoryId = aOSearchProduct.CategoryId,
                TypeProductId = aOSearchProduct.TypeProductId
            });
        }

        public async Task<int> QueryCountListProduct(AOSearchProduct aOSearchProduct)
        {
            aOSearchProduct.Limit = string.IsNullOrEmpty(aOSearchProduct.Limit) ? "10" : aOSearchProduct.Limit;
            aOSearchProduct.CurrentDate = string.IsNullOrEmpty(aOSearchProduct.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchProduct.CurrentDate;
            aOSearchProduct.CurrentPage = string.IsNullOrEmpty(aOSearchProduct.CurrentPage) ? "0" : aOSearchProduct.CurrentPage;
            aOSearchProduct.BreedId = string.IsNullOrEmpty(aOSearchProduct.BreedId) ? "0" : aOSearchProduct.BreedId;
            aOSearchProduct.SupplierId = string.IsNullOrEmpty(aOSearchProduct.SupplierId) ? "0" : aOSearchProduct.SupplierId;
            aOSearchProduct.Status = string.IsNullOrEmpty(aOSearchProduct.Status) ? "0" : aOSearchProduct.Status;

            var condition = @"";

            if (Convert.ToInt32(aOSearchProduct.BreedId) > 0)
            {
                condition += @" and p.breedid = @BreedId ";
            }

            if (Convert.ToInt32(aOSearchProduct.SupplierId) > 0)
            {
                condition += @" and p.supplierid = @SupplierId ";
            }

            if (Convert.ToInt32(aOSearchProduct.Status) > 0)
            {
                condition += @" and p.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchProduct.CurrentDate))
            {
                condition += @" and p.createdate <= cast(@CurrentDate as DateTime) ";
            }

            if (aOSearchProduct.CategoryId > 0)
            {
                condition += @" and ifnull(p.categoryid, 0) = @CategoryId ";
            }

            if (aOSearchProduct.TypeProductId > 0)
            {
                condition += @" and ifnull(tp.id, 10) = @TypeProductId ";
            }

            var query =
                @"select count(1) 
                from product p  
                    left join (select * from breed where status = @StatusRoot) b on b.id = p.breedid 
                    left join (select * from supplier where status = @StatusRoot )su on su.id = p.supplierid 
	                left join status st on st.id = p.status
                    left join users uc on uc.id = p.createuser
                    left join users up on up.id = p.updateuser
                    left join (select * from category where status = @StatusRoot) c on c.id = p.categoryid
                    left join typeproduct tp on tp.id = c.typeproductid
                where p.status != @StatusExcep " + condition + @" ";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                StatusRoot = 10,
                BreedId = aOSearchProduct.BreedId,
                SupplierId = aOSearchProduct.SupplierId,
                Status = aOSearchProduct.Status,
                CurrentDate = aOSearchProduct.CurrentDate,
                CategoryId = aOSearchProduct.CategoryId,
                TypeProductId = aOSearchProduct.TypeProductId
            });
        }

        public async Task<AProductModel> QueryGetProductDetail(ulong Id)
        {
            var query = @"select p.Id, p.BreedId, p.SupplierId, p.Content, p.Status, ifnull(p.productname, '') ProductName,
                            ifnull(p.categoryid, 0) CategoryId
                        from product p  
                        where p.status != @Status and p.id = @Id;";

            return await _p2NPetDapper.QuerySingleAsync<AProductModel>(query, new
            {
                Status = 190,
                Id
            });
        }
    }
}
