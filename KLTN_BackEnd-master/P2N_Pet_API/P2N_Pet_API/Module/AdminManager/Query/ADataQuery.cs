using P2N_Pet_API.Module.AdminManager.Models.AData;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class ADataQuery : IADataQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public ADataQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<AStatusSelectionModel>> QueryNormalStatusSelection()
        {
            var query =
                @"select Id, ifnull(Title, N'') Title 
                from status
                where id != 190;";

            return await _p2NPetDapper.QueryAsync<AStatusSelectionModel>(query);
        }

        public async Task<List<AAgeSelectionModel>> QueryNormalAgeSelection()
        {
            var query =
                @"select Id, ifnull(Title, N'') Title 
                from age 
                where status = @Status 
                order by orderview desc, title asc;";

            return await _p2NPetDapper.QueryAsync<AAgeSelectionModel>(query, new
            {
                Status = 10
            });
        }

        public async Task<List<AColorSelectionModel>> QueryNormalColorSelection()
        {
            var query =
                @"select Id, ifnull(Title, N'') Title 
                from color 
                where status = @Status 
                order by title collate utf8_unicode_ci asc;";

            return await _p2NPetDapper.QueryAsync<AColorSelectionModel>(query, new
            {
                Status = 10
            });
        }

        public async Task<List<ASizeSelectionModel>> QueryNormalSizeSelection()
        {
            var query =
                @"select Id, ifnull(Title, N'') Title 
                from size  
                where status = @Status 
                order by orderview desc;";

            return await _p2NPetDapper.QueryAsync<ASizeSelectionModel>(query, new
            {
                Status = 10
            });
        }

        public async Task<List<ASexSelectionModel>> QueryNormalSexSelection()
        {
            var query =
                @"select Id, ifnull(Title, N'') Title 
                from sex   
                where status = @Status;";

            return await _p2NPetDapper.QueryAsync<ASexSelectionModel>(query, new
            {
                Status = 10
            });
        }

        public async Task<List<ABreedDefaultSelectionModel>> QueryNormalBreedDefaultSelection()
        {
            var query =
                @"select Id, ifnull(Name, N'') Name 
                from breed   
                where status = @Status and id = breedid 
                order by name collate utf8_unicode_ci asc;";

            return await _p2NPetDapper.QueryAsync<ABreedDefaultSelectionModel>(query, new
            {
                Status = 10
            });
        }

        public async Task<List<ABreedSelectionModel>> QueryNormalBreedSelection()
        {
            var query =
                @"select Id, ifnull(Name, N'') Name  
                from breed    
                where status = @Status and id != breedid 
                order by name collate utf8_unicode_ci asc;";

            return await _p2NPetDapper.QueryAsync<ABreedSelectionModel>(query, new
            {
                Status = 10
            });
        }

        public async Task<List<ASupplierSelectionModel>> QueryNormalSupplierSelection()
        {
            var query =
                @"select Id, ifnull(Name, N'') Name  
                from supplier     
                where status = @Status 
                order by name collate utf8_unicode_ci asc;";

            return await _p2NPetDapper.QueryAsync<ASupplierSelectionModel>(query, new
            {
                Status = 10
            });
        }

        public async Task<List<ABreedSelectionModel>> QueryNormalBreedProductDetailSelection(ulong supplierid)
        {
            var condition = @"";

            if (supplierid != 0) 
            {
                condition = " and p.supplierid = @SupplierId ";
            }

            var query =
                @"select b.Id, b.Name
                from (select 0 Id, N'' Name 
                    union 
                    (select distinct b.Id, ifnull(b.name, N'') Name 
                    from product p inner join breed b on b.id = p.breedid 
                                inner join supplier su on su.id = p.supplierid 
                    where p.status = @Status and b.status = @Status and su.status = @Status " + condition + @" 
                    )) b 
                order by b.Name collate utf8_unicode_ci asc;";

            return await _p2NPetDapper.QueryAsync<ABreedSelectionModel>(query, new
            {
                Status = 10,
                SupplierId = supplierid
            });
        }

        public async Task<List<ASupplierSelectionModel>> QueryNormalSupplierProductDetailSelection(ulong breedid)
        {
            var condition = @"";

            if (breedid != 0)
            {
                condition = " and p.breedid = @BreedId ";
            }

            var query =
                @"select su.Id, su.Name
                from (select 0 Id, N'' Name 
                    union 
                    (select distinct su.Id, ifnull(su.name, N'') Name 
                    from product p inner join breed b on b.id = p.breedid 
                               inner join supplier su on su.id = p.supplierid 
                    where p.status = @Status and b.status = @Status and su.status = @Status " + condition + @" 
                    )) su 
                order by su.Name collate utf8_unicode_ci asc;";

            return await _p2NPetDapper.QueryAsync<ASupplierSelectionModel>(query, new
            {
                Status = 10,
                BreedId = breedid
            });
        }

        public async Task<List<AStatusDetailSelectionModel>> QueryNormalStatusDetailSelection()
        {
            var query =
                @"select Id, ifnull(Title, N'') Title 
                from statusdetail      
                where status = @Status;";

            return await _p2NPetDapper.QueryAsync<AStatusDetailSelectionModel>(query, new
            {
                Status = 10
            });
        }

        public async Task<List<AProductSelectionModel>> QueryNormalProductDetailSelection()
        {
            var query =
                @"select detail.id Id, 
		            case 
		            when product.breedid != 0 then concat(product.breedname, ' - ', c.title, '/ ', s.title)
		            else concat(product.categoryname, ' - ', s.title)
		            end ProductName
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
	            order by product.id asc ";

            return await _p2NPetDapper.QueryAsync<AProductSelectionModel>(query);
        }

        public async Task<List<ABrandSelectionModel>> QueryNormalBrandSelection()
        {
            var query =
                @"select Id, Address
                from brand
                where status = 10 ";

            return await _p2NPetDapper.QueryAsync<ABrandSelectionModel>(query);
        }

        public async Task<List<ATypeProductSelection>> QueryNormalTypeProduct()
        {
            var query =
                @"select id TypeProductId, title TypeProductName
                from typeproduct
                where status = 10";

            return await _p2NPetDapper.QueryAsync<ATypeProductSelection>(query);
        }

        public async Task<List<ACategorySelectionModel>> QueryNormalCategoryRootSelection()
        {
            var query =
                @"select Id, Title, TypeProductId 
                from category
                where status = 10 and id = categoryrootid
                order by title asc";

            return await _p2NPetDapper.QueryAsync<ACategorySelectionModel>(query);
        }

        public async Task<List<ACategorySelectionModel>> QueryNormalCategorySelection()
        {
            var query =
                @"select Id, Title, TypeProductId 
                from category
                where status = 10 and id != categoryrootid
                order by title asc";

            return await _p2NPetDapper.QueryAsync<ACategorySelectionModel>(query);

        }

        public async Task<List<ACategorySelectionModel>> QueryCategorySelectionSupplier(ulong supplierid)
        {
            var condition = @"";

            if (supplierid != 0)
            {
                condition = " and p.supplierid = @SupplierId ";
            }

            var query =
                @"select cate.Id, cate.Title
                from (select 0 Id, N'' Title 
	                    union 
	                    (select distinct c.Id, ifnull(c.title, N'') Title 
	                    from product p 
		                    inner join category c on c.id = p.categoryid 
		                    inner join supplier su on su.id = p.supplierid 
	                    where p.status = 10 and c.status = 10 and su.status = 10 " + condition + @"
	                    )) cate
                order by cate.Title collate utf8_unicode_ci asc;";

            return await _p2NPetDapper.QueryAsync<ACategorySelectionModel>(query, new
            {
                Status = 10,
                SupplierId = supplierid
            });
        }

        public async Task<List<ASupplierSelectionModel>> QuerySupplierProductDetailSelection(ulong categoryid)
        {
            var condition = @"";

            if (categoryid != 0)
            {
                condition = " and p.categoryid = @Categoryid ";
            }

            var query =
                @"select su.Id, su.Name
                from (select 0 Id, N'' Name 
                    union 
                    (select distinct su.Id, ifnull(su.name, N'') Name 
                    from product p 
                        inner join category b on b.id = p.categoryid 
                        inner join supplier su on su.id = p.supplierid 
                    where p.status = @Status and b.status = @Status and su.status = @Status " + condition + @" 
                    )) su 
                order by su.Name collate utf8_unicode_ci asc;";

            return await _p2NPetDapper.QueryAsync<ASupplierSelectionModel>(query, new
            {
                Status = 10,
                Categoryid = categoryid
            });
        }

        public async Task<List<ATypeNewsSelectionModel>> QueryTypeNewsSelection()
        {
            var query =
                @"select Id, Title 
                from typenews 
                where status = @Status ";

            return await _p2NPetDapper.QueryAsync<ATypeNewsSelectionModel>(query, new
            {
                Status = 10
            });
        }
    }
}
