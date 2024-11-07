using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ASize;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class ASizeQuery : IASizeQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public ASizeQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<ASizeListModel>> QueryGetListSize(AOSearchSize aOSearchSize)
        {
            aOSearchSize.Limit = string.IsNullOrEmpty(aOSearchSize.Limit) ? "10" : aOSearchSize.Limit;
            aOSearchSize.CurrentDate = string.IsNullOrEmpty(aOSearchSize.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchSize.CurrentDate;
            aOSearchSize.CurrentPage = string.IsNullOrEmpty(aOSearchSize.CurrentPage) ? "0" : aOSearchSize.CurrentPage;
            aOSearchSize.Status = string.IsNullOrEmpty(aOSearchSize.Status) ? "0" : aOSearchSize.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchSize.Title))
            {
                condition += @" and si.Title like @Title ";
            }

            if (Convert.ToInt32(aOSearchSize.Status) > 0)
            {
                condition += @" and si.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchSize.CurrentDate))
            {
                condition += @" and si.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select si.Id, ifnull(si.Title, N'') Title, si.OrderView, ifnull(st.Title, N'') StatusText, 
	                ifnull(uc.Name, N'') CreateUserName, si.CreateDate, ifnull(up.Name, N'') UpdateUserName, si.UpdateDate
                from size si
	                left join status st on st.id = si.status
                    left join users uc on uc.id = si.createuser
                    left join users up on up.id = si.updateuser
                where si.status != @StatusExcep " + condition + @" 
                order by  si.status asc, si.orderview asc  
                limit " + Convert.ToInt32(aOSearchSize.Limit) * Convert.ToInt32(aOSearchSize.CurrentPage) + @", " + aOSearchSize.Limit + @";"; 

            return await _p2NPetDapper.QueryAsync<ASizeListModel>(query, new
            {
                StatusExcep = 190,
                Title = "%" + aOSearchSize.Title + "%",
                Status = aOSearchSize.Status,
                CurrentDate = aOSearchSize.CurrentDate
            });
        }

        public async Task<int> QueryCountListSize(AOSearchSize aOSearchSize)
        {
            aOSearchSize.Limit = string.IsNullOrEmpty(aOSearchSize.Limit) ? "10" : aOSearchSize.Limit;
            aOSearchSize.CurrentDate = string.IsNullOrEmpty(aOSearchSize.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchSize.CurrentDate;
            aOSearchSize.CurrentPage = string.IsNullOrEmpty(aOSearchSize.CurrentPage) ? "0" : aOSearchSize.CurrentPage;
            aOSearchSize.Status = string.IsNullOrEmpty(aOSearchSize.Status) ? "0" : aOSearchSize.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchSize.Title))
            {
                condition += @" and si.Title like @Title ";
            }

            if (Convert.ToInt32(aOSearchSize.Status) > 0)
            {
                condition += @" and si.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchSize.CurrentDate))
            {
                condition += @" and si.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select count(1) 
                from size si
	                left join status st on st.id = si.status
                    left join users uc on uc.id = si.createuser
                    left join users up on up.id = si.updateuser
                where si.status != @StatusExcep " + condition + @" ;";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                Title = "%" + aOSearchSize.Title + "%",
                Status = aOSearchSize.Status,
                CurrentDate = aOSearchSize.CurrentDate
            });
        }

        public async Task<ASizeModel> QueryGetSizeDetail(ulong Id)
        {
            var query = @"select s.Id, ifnull(s.Title, N'') Title, s.OrderView, s.Status 
                        from size s 
                        where s.status != @Status and s.id = @Id;";

            return await _p2NPetDapper.QuerySingleAsync<ASizeModel>(query, new
            {
                Status = 190,
                Id
            });
        }
    }
}
