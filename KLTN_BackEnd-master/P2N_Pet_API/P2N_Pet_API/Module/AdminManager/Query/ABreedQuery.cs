using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ABreed;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class ABreedQuery : IABreedQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public ABreedQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<ABreedListModel>> QueryGetListBreed(AOSearchBreed aOSearchBreed)
        {
            aOSearchBreed.Limit = string.IsNullOrEmpty(aOSearchBreed.Limit) ? "10" : aOSearchBreed.Limit;
            aOSearchBreed.CurrentDate = string.IsNullOrEmpty(aOSearchBreed.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchBreed.CurrentDate;
            aOSearchBreed.CurrentPage = string.IsNullOrEmpty(aOSearchBreed.CurrentPage) ? "0" : aOSearchBreed.CurrentPage;
            aOSearchBreed.BreedId = string.IsNullOrEmpty(aOSearchBreed.BreedId) ? "0" : aOSearchBreed.BreedId;
            aOSearchBreed.Status = string.IsNullOrEmpty(aOSearchBreed.Status) ? "0" : aOSearchBreed.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchBreed.Name))
            {
                condition += @" and b.name like @Name ";
            }

            if (Convert.ToInt32(aOSearchBreed.BreedId) > 0)
            {
                condition += @" and b.breedid = @BreedId ";
            }

            if (Convert.ToInt32(aOSearchBreed.Status) > 0)
            {
                condition += @" and b.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchBreed.CurrentDate))
            {
                condition += @" and b.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select b.Id, ifnull(b.Name, N'') Name, ifnull(br.Name, N'') BreedIdName, ifnull(st.Title, N'') StatusText, 
	                ifnull(uc.Name, N'') CreateUserName, b.CreateDate, ifnull(up.Name, N'') UpdateUserName, b.UpdateDate 
                from breed b 
                    left join breed br on br.id = b.breedid 
	                left join status st on st.id = b.status
                    left join users uc on uc.id = b.createuser
                    left join users up on up.id = b.updateuser
                where b.status != @StatusExcep and b.id != b.breedid " + condition + @" 
                order by b.breedid asc, b.status asc, b.name collate utf8_unicode_ci asc  
                limit " + Convert.ToInt32(aOSearchBreed.Limit) * Convert.ToInt32(aOSearchBreed.CurrentPage) + @", " + aOSearchBreed.Limit + @";";

            return await _p2NPetDapper.QueryAsync<ABreedListModel>(query, new
            {
                StatusExcep = 190,
                Name = "%" + aOSearchBreed.Name + "%",
                BreedId = aOSearchBreed.BreedId,
                Status = aOSearchBreed.Status,
                CurrentDate = aOSearchBreed.CurrentDate
            });
        }

        public async Task<int> QueryCountListBreed(AOSearchBreed aOSearchBreed)
        {
            aOSearchBreed.Limit = string.IsNullOrEmpty(aOSearchBreed.Limit) ? "10" : aOSearchBreed.Limit;
            aOSearchBreed.CurrentDate = string.IsNullOrEmpty(aOSearchBreed.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchBreed.CurrentDate;
            aOSearchBreed.CurrentPage = string.IsNullOrEmpty(aOSearchBreed.CurrentPage) ? "0" : aOSearchBreed.CurrentPage;
            aOSearchBreed.BreedId = string.IsNullOrEmpty(aOSearchBreed.BreedId) ? "0" : aOSearchBreed.BreedId;
            aOSearchBreed.Status = string.IsNullOrEmpty(aOSearchBreed.Status) ? "0" : aOSearchBreed.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchBreed.Name))
            {
                condition += @" and b.name like @Name ";
            }

            if (Convert.ToInt32(aOSearchBreed.BreedId) > 0)
            {
                condition += @" and b.breedid = @BreedId ";
            }

            if (Convert.ToInt32(aOSearchBreed.Status) > 0)
            {
                condition += @" and b.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchBreed.CurrentDate))
            {
                condition += @" and b.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select count(1) 
                from breed b 
                    left join breed br on br.id = b.breedid 
	                left join status st on st.id = b.status
                    left join users uc on uc.id = b.createuser
                    left join users up on up.id = b.updateuser
                where b.status != @StatusExcep and b.id != b.breedid " + condition + @" ;";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                Name = "%" + aOSearchBreed.Name + "%",
                BreedId = aOSearchBreed.BreedId,
                Status = aOSearchBreed.Status,
                CurrentDate = aOSearchBreed.CurrentDate
            });
        }

        public async Task<ABreedModel> QueryGetBreedDetail(ulong Id)
        {
            var query = @"select b.Id, ifnull(b.Name, N'') Name, b.BreedId, b.Status 
                        from breed b 
                        where b.status != @Status and b.id = @Id;";

            return await _p2NPetDapper.QuerySingleAsync<ABreedModel>(query, new
            {
                Status = 190,
                Id
            });
        }
    }
}
