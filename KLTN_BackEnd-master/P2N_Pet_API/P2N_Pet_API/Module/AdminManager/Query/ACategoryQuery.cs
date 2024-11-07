using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ACategory;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class ACategoryQuery : IACategoryQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public ACategoryQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<int> QueryCountListCategory(AOSearchCategory aOSearch)
        {
            aOSearch.Limit = aOSearch.Limit < 0 ? 10 : aOSearch.Limit;
            aOSearch.CurrentDate = string.IsNullOrEmpty(aOSearch.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearch.CurrentDate;


            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearch.Name))
            {
                condition += @" and b.title like @Name ";
            }

            if (aOSearch.CategoryRootId > 0)
            {
                condition += @" and b.categoryrootid = @CategoryRootId ";
            }

            if (Convert.ToInt32(aOSearch.Status) > 0)
            {
                condition += @" and b.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearch.CurrentDate))
            {
                condition += @" and b.createdate <= cast(@CurrentDate as DateTime) ";
            }

            if (aOSearch.TypeProductId > 0)
            {
                condition += @" and  b.typeproductid = @TypeProductId";
            }

            var query =
                @"select count(1) 
                from category b 
                    left join category br on br.id = b.categoryrootid 
	                left join status st on st.id = b.status
                    left join users uc on uc.id = b.createuser
                    left join users up on up.id = b.updateuser
                    left join typeproduct tp on tp.id = b.typeproductid
                where b.status != 190 and b.id != b.categoryrootid " + condition + @" ";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                Name = "%" + aOSearch.Name + "%",
                CategoryRootId = aOSearch.CategoryRootId,
                Status = aOSearch.Status,
                CurrentDate = aOSearch.CurrentDate,
                TypeProductId = aOSearch.TypeProductId
            });
        }

        public async Task<ACategoryModel> QueryDetailCategory(ulong Id)
        {
            var query =
                @"select c.id, c.title Name, c.categoryrootid CategoryRootId, cr.title CategoryIdName, c.Status, 
	                s.title StatusText, c.TypeProductId, tp.title TypeProductName
                from category c
	                left join category cr on c.categoryrootid = cr.id
                    left join typeproduct tp on tp.id = c.typeproductid
                    left join status s on s.id = c.status
                where c.status != @StatusExcep and cr.status != @StatusExcep and tp.status != @StatusExcep and c.id = @Id";

            var result = await _p2NPetDapper.QuerySingleAsync<ACategoryModel>(query, new
            {
                StatusExcep = 190,
                Id = Id
            });

            return result;
        }

        public async Task<List<ACategoryListModel>> QueryGetListCategory(AOSearchCategory aOSearch)
        {
            aOSearch.Limit = aOSearch.Limit < 0 ? 10 : aOSearch.Limit;
            aOSearch.CurrentDate = string.IsNullOrEmpty(aOSearch.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearch.CurrentDate;


            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearch.Name))
            {
                condition += @" and b.title like @Name ";
            }

            if (aOSearch.CategoryRootId > 0)
            {
                condition += @" and b.categoryrootid = @CategoryRootId ";
            }

            if (Convert.ToInt32(aOSearch.Status) > 0)
            {
                condition += @" and b.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearch.CurrentDate))
            {
                condition += @" and b.createdate <= cast(@CurrentDate as DateTime) ";
            }

            if (aOSearch.TypeProductId > 0)
            {
                condition += @" and  b.typeproductid = @TypeProductId";
            }

            var query =
                @"select b.Id, ifnull(b.title, N'') Name, ifnull(br.title, N'') CategoryIdName, ifnull(st.Title, N'') StatusText, 
	                ifnull(uc.Name, N'') CreateUserName, b.CreateDate, ifnull(up.Name, N'') UpdateUserName, b.UpdateDate,
                    b.typeproductid TypeProductId, tp.title TypeProductName
                from category b 
                    left join category br on br.id = b.categoryrootid 
	                left join status st on st.id = b.status
                    left join users uc on uc.id = b.createuser
                    left join users up on up.id = b.updateuser
                    left join typeproduct tp on tp.id = b.typeproductid
                where b.status != 190 and b.id != b.categoryrootid " + condition + @" 
                order by b.categoryrootid asc, b.status asc, b.title collate utf8_unicode_ci asc  
                limit " + Convert.ToInt32(aOSearch.Limit) * Convert.ToInt32(aOSearch.CurrentPage) + @", " + aOSearch.Limit + @";";

            return await _p2NPetDapper.QueryAsync<ACategoryListModel>(query, new
            {
                StatusExcep = 190,
                Name = "%" + aOSearch.Name + "%",
                CategoryRootId = aOSearch.CategoryRootId,
                Status = aOSearch.Status,
                CurrentDate = aOSearch.CurrentDate,
                TypeProductId = aOSearch.TypeProductId
            });
        }
    }
}
