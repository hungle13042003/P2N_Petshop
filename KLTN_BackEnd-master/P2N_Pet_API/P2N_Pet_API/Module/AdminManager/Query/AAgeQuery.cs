using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AAge;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class AAgeQuery : IAAgeQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public AAgeQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<AAgeListModel>> QueryGetListAge(AOSearchAge aOSearchAge)
        {
            aOSearchAge.Limit = string.IsNullOrEmpty(aOSearchAge.Limit) ? "10" : aOSearchAge.Limit;
            aOSearchAge.CurrentDate = string.IsNullOrEmpty(aOSearchAge.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchAge.CurrentDate;
            aOSearchAge.CurrentPage = string.IsNullOrEmpty(aOSearchAge.CurrentPage) ? "0" : aOSearchAge.CurrentPage;
            aOSearchAge.Status = string.IsNullOrEmpty(aOSearchAge.Status) ? "0" : aOSearchAge.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchAge.Title))
            {
                condition += @" and a.Title like @Title ";
            }

            if (Convert.ToInt32(aOSearchAge.Status) > 0)
            {
                condition += @" and a.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchAge.CurrentDate))
            {
                condition += @" and a.createdate <= cast(@CurrentDate as DateTime) ";
            }
            
            var query =
                @"select a.Id, ifnull(a.Title, '') Title, a.OrderView, ifnull(st.Title, '') StatusText, 
	                ifnull(uc.Name, '') CreateUserName, a.CreateDate, ifnull(up.Name, '') UpdateUserName, a.UpdateDate
                from age a
	                left join status st on st.id = a.status
                    left join users uc on uc.id = a.createuser
                    left join users up on up.id = a.updateuser
                where a.status != @StatusExcep " + condition + @" 
                order by a.status asc, a.orderview asc  
                limit " + Convert.ToInt32(aOSearchAge.Limit) * Convert.ToInt32(aOSearchAge.CurrentPage) + @", " + aOSearchAge.Limit + @";";

            return await _p2NPetDapper.QueryAsync<AAgeListModel>(query, new 
            {
                StatusExcep = 190,
                Title = "%" + aOSearchAge.Title + "%",
                Status = aOSearchAge.Status,
                CurrentDate = aOSearchAge.CurrentDate
            });
        }

        public async Task<int> QueryCountListAge(AOSearchAge aOSearchAge)
        {
            aOSearchAge.Limit = string.IsNullOrEmpty(aOSearchAge.Limit) ? "10" : aOSearchAge.Limit;
            aOSearchAge.CurrentDate = string.IsNullOrEmpty(aOSearchAge.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchAge.CurrentDate;
            aOSearchAge.CurrentPage = string.IsNullOrEmpty(aOSearchAge.CurrentPage) ? "0" : aOSearchAge.CurrentPage;
            aOSearchAge.Status = string.IsNullOrEmpty(aOSearchAge.Status) ? "0" : aOSearchAge.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchAge.Title))
            {
                condition += @" and a.Title like @Title ";
            }

            if (Convert.ToInt32(aOSearchAge.Status) > 0)
            {
                condition += @" and a.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchAge.CurrentDate))
            {
                condition += @" and a.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select count(1) 
                from age a
	                left join status st on st.id = a.status
                    left join users uc on uc.id = a.createuser
                    left join users up on up.id = a.updateuser
                where a.status != @StatusExcep " + condition + @";";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                Title = "%" + aOSearchAge.Title + "%",
                Status = aOSearchAge.Status,
                CurrentDate = aOSearchAge.CurrentDate
            });
        }

        public async Task<AAgeModel> QueryGetAgeDetail(ulong Id)
        {
            var query = @"select a.Id, ifnull(a.Title, N'') Title, a.OrderView, a.Status 
                        from age a 
                        where a.status != @Status and a.id = @Id;";

            return await _p2NPetDapper.QuerySingleAsync<AAgeModel>(query, new
            {
                Status = 190,
                Id
            });
        }
    }
}
