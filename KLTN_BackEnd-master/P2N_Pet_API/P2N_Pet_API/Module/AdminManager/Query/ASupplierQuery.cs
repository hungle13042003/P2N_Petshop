using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ASupplier;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class ASupplierQuery : IASupplierQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public ASupplierQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<ASupplierListModel>> QueryGetListSupplier(AOSearchSupplier aOSearchSupplier)
        {
            aOSearchSupplier.Limit = string.IsNullOrEmpty(aOSearchSupplier.Limit) ? "10" : aOSearchSupplier.Limit;
            aOSearchSupplier.CurrentDate = string.IsNullOrEmpty(aOSearchSupplier.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchSupplier.CurrentDate;
            aOSearchSupplier.CurrentPage = string.IsNullOrEmpty(aOSearchSupplier.CurrentPage) ? "0" : aOSearchSupplier.CurrentPage;
            aOSearchSupplier.Status = string.IsNullOrEmpty(aOSearchSupplier.Status) ? "0" : aOSearchSupplier.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchSupplier.Name))
            {
                condition += @" and sp.Name like @Name ";
            }

            if (!string.IsNullOrEmpty(aOSearchSupplier.Phone))
            {
                condition += @" and sp.Phone like @Phone ";
            }

            if (!string.IsNullOrEmpty(aOSearchSupplier.Email))
            {
                condition += @" and sp.Email like @Email ";
            }

            if (Convert.ToInt32(aOSearchSupplier.Status) > 0)
            {
                condition += @" and sp.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchSupplier.CurrentDate))
            {
                condition += @" and sp.createdate <= cast(@CurrentDate as DateTime) ";
            }
            var query =
                @"select sp.Id, ifnull(sp.Name, N'') Name, ifnull(sp.Address, N'') Address, ifnull(sp.Phone, '') Phone, ifnull(sp.Email, '') Email, ifnull(st.Title, N'') StatusText,  
	                ifnull(uc.Name, '') CreateUserName, sp.CreateDate, ifnull(up.Name, '') UpdateUserName, sp.UpdateDate 
                from supplier sp
	                left join status st on st.id = sp.status
                    left join users uc on uc.id = sp.createuser
                    left join users up on up.id = sp.updateuser
                where sp.status != @StatusExcep " + condition + @" 
                order by sp.status asc, sp.name collate utf8_unicode_ci asc 
                limit " + Convert.ToInt32(aOSearchSupplier.Limit) * Convert.ToInt32(aOSearchSupplier.CurrentPage) + @", " + aOSearchSupplier.Limit + @";";

            return await _p2NPetDapper.QueryAsync<ASupplierListModel>(query, new
            {
                StatusExcep = 190,
                Name = "%" + aOSearchSupplier.Name + "%",
                Phone = "%" + aOSearchSupplier.Phone + "%",
                Email = "%" + aOSearchSupplier.Email + "%",
                Status = aOSearchSupplier.Status,
                CurrentDate = aOSearchSupplier.CurrentDate
            });
        }

        public async Task<int> QueryCountListSupplier(AOSearchSupplier aOSearchSupplier)
        {
            aOSearchSupplier.Limit = string.IsNullOrEmpty(aOSearchSupplier.Limit) ? "10" : aOSearchSupplier.Limit;
            aOSearchSupplier.CurrentDate = string.IsNullOrEmpty(aOSearchSupplier.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchSupplier.CurrentDate;
            aOSearchSupplier.CurrentPage = string.IsNullOrEmpty(aOSearchSupplier.CurrentPage) ? "0" : aOSearchSupplier.CurrentPage;
            aOSearchSupplier.Status = string.IsNullOrEmpty(aOSearchSupplier.Status) ? "0" : aOSearchSupplier.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchSupplier.Name))
            {
                condition += @" and sp.Name like @Name ";
            }

            if (!string.IsNullOrEmpty(aOSearchSupplier.Phone))
            {
                condition += @" and sp.Phone like @Phone ";
            }

            if (!string.IsNullOrEmpty(aOSearchSupplier.Email))
            {
                condition += @" and sp.Email like @Email ";
            }

            if (Convert.ToInt32(aOSearchSupplier.Status) > 0)
            {
                condition += @" and sp.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchSupplier.CurrentDate))
            {
                condition += @" and sp.createdate <= cast(@CurrentDate as DateTime) ";
            }
            var query =
                @"select count(1) 
                from supplier sp
	                left join status st on st.id = sp.status
                    left join users uc on uc.id = sp.createuser
                    left join users up on up.id = sp.updateuser
                where sp.status != @StatusExcep " + condition + @" ;";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                Name = "%" + aOSearchSupplier.Name + "%",
                Phone = "%" + aOSearchSupplier.Phone + "%",
                Email = "%" + aOSearchSupplier.Email + "%",
                Status = aOSearchSupplier.Status,
                CurrentDate = aOSearchSupplier.CurrentDate
            });
        }

        public async Task<ASupplierModel> QueryGetSupplierDetail(ulong Id)
        {
            var query = @"select sp.Id, ifnull(sp.Name, N'') Name, ifnull(sp.Address, N'') Address, ifnull(sp.Phone, '') Phone, ifnull(sp.Email, '') Email, sp.Status 
                        from supplier sp 
                        where sp.status != @Status and sp.id = @Id;";

            return await _p2NPetDapper.QuerySingleAsync<ASupplierModel>(query, new
            {
                Status = 190,
                Id
            });
        }
    }
}
