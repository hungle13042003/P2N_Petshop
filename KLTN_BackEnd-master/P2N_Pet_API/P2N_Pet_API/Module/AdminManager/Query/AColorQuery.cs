using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AColor;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class AColorQuery : IAColorQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public AColorQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<AColorListModel>> QueryGetListColor(AOSearchColor aOSearchColor)
        {
            aOSearchColor.Limit = string.IsNullOrEmpty(aOSearchColor.Limit) ? "10" : aOSearchColor.Limit;
            aOSearchColor.CurrentDate = string.IsNullOrEmpty(aOSearchColor.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchColor.CurrentDate;
            aOSearchColor.CurrentPage = string.IsNullOrEmpty(aOSearchColor.CurrentPage) ? "0" : aOSearchColor.CurrentPage;
            aOSearchColor.Status = string.IsNullOrEmpty(aOSearchColor.Status) ? "0" : aOSearchColor.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchColor.Title))
            {
                condition += @" and c.Title like @Title ";
            }

            if (Convert.ToInt32(aOSearchColor.Status) > 0)
            {
                condition += @" and c.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchColor.CurrentDate))
            {
                condition += @" and c.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select c.Id, ifnull(c.Title, N'') Title, ifnull(st.Title, N'') StatusText, 
	                ifnull(uc.Name, N'') CreateUserName, c.CreateDate, ifnull(up.Name, N'') UpdateUserName, c.UpdateDate
                from color c
	                left join status st on st.id = c.status
                    left join users uc on uc.id = c.createuser
                    left join users up on up.id = c.updateuser
                where c.status != @StatusExcep " + condition + @" 
                order by c.status asc, c.title collate utf8_unicode_ci asc  
                limit " + Convert.ToInt32(aOSearchColor.Limit) * Convert.ToInt32(aOSearchColor.CurrentPage) + @", " + aOSearchColor.Limit + @";";

            return await _p2NPetDapper.QueryAsync<AColorListModel>(query, new
            {
                StatusExcep = 190,
                Title = "%" + aOSearchColor.Title + "%",
                Status = aOSearchColor.Status,
                CurrentDate = aOSearchColor.CurrentDate
            });
        }

        public async Task<int> QueryCountListColor(AOSearchColor aOSearchColor)
        {
            aOSearchColor.Limit = string.IsNullOrEmpty(aOSearchColor.Limit) ? "10" : aOSearchColor.Limit;
            aOSearchColor.CurrentDate = string.IsNullOrEmpty(aOSearchColor.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchColor.CurrentDate;
            aOSearchColor.CurrentPage = string.IsNullOrEmpty(aOSearchColor.CurrentPage) ? "0" : aOSearchColor.CurrentPage;
            aOSearchColor.Status = string.IsNullOrEmpty(aOSearchColor.Status) ? "0" : aOSearchColor.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchColor.Title))
            {
                condition += @" and c.Title like @Title ";
            }

            if (Convert.ToInt32(aOSearchColor.Status) > 0)
            {
                condition += @" and c.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchColor.CurrentDate))
            {
                condition += @" and c.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select count(1) 
                from color c
	                left join status st on st.id = c.status
                    left join users uc on uc.id = c.createuser
                    left join users up on up.id = c.updateuser
                where c.status != @StatusExcep " + condition + @" ;";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                Title = "%" + aOSearchColor.Title + "%",
                Status = aOSearchColor.Status,
                CurrentDate = aOSearchColor.CurrentDate
            });
        }

        public async Task<AColorModel> QueryGetColorDetail(ulong Id)
        {
            var query = @"select c.Id, ifnull(c.Title, N'') Title, c.Status 
                        from color c 
                        where c.status != @Status and c.id = @Id;";

            return await _p2NPetDapper.QuerySingleAsync<AColorModel>(query, new
            {
                Status = 190,
                Id
            });
        }
    }
}
