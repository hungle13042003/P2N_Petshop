using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.APromotion;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class APromotionQuery : IAPromotionQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public APromotionQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<APromotionListModel>> QueryGetListPromotion(AOSearchPromotion aOSearchPromotion)
        {
            aOSearchPromotion.Limit = string.IsNullOrEmpty(aOSearchPromotion.Limit) ? "10" : aOSearchPromotion.Limit;
            aOSearchPromotion.CurrentDate = string.IsNullOrEmpty(aOSearchPromotion.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchPromotion.CurrentDate;
            aOSearchPromotion.CurrentPage = string.IsNullOrEmpty(aOSearchPromotion.CurrentPage) ? "0" : aOSearchPromotion.CurrentPage;
            aOSearchPromotion.Status = string.IsNullOrEmpty(aOSearchPromotion.Status) ? "0" : aOSearchPromotion.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchPromotion.Title))
            {
                condition += @" and p.title like @Title ";
            }

            if (Convert.ToInt32(aOSearchPromotion.Status) > 0)
            {
                condition += @" and p.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchPromotion.CurrentDate))
            {
                condition += @" and p.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select p.Id, ifnull(p.Title, N'') Title, p.FromDate, p.ToDate, 
                    case 
						when ifnull(p.image, N'') != '' 
						then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Promotion/Promotion_', p.id, '/', p.image)
						else ifnull(p.image, '') 
                    end Image, 
                    ifnull(st.Title, N'') StatusText, ifnull(uc.Name, N'') CreateUserName, p.CreateDate, 
                    ifnull(up.Name, N'') UpdateUserName, p.UpdateDate 
                from promotion p
	                left join status st on st.id = p.status
                    left join users uc on uc.id = p.createuser
                    left join users up on up.id = p.updateuser
                where p.status != @StatusExcep " + condition + @" 
                order by p.status asc, p.createdate desc, p.title collate utf8_unicode_ci asc  
                limit " + Convert.ToInt32(aOSearchPromotion.Limit) * Convert.ToInt32(aOSearchPromotion.CurrentPage) + @", " + aOSearchPromotion.Limit + @";";

            return await _p2NPetDapper.QueryAsync<APromotionListModel>(query, new
            {
                StatusExcep = 190,
                Title = "%" + aOSearchPromotion.Title + "%",
                Status = aOSearchPromotion.Status,
                CurrentDate = aOSearchPromotion.CurrentDate
            });
        }

        public async Task<int> QueryCountListPromotion(AOSearchPromotion aOSearchPromotion)
        {
            aOSearchPromotion.Limit = string.IsNullOrEmpty(aOSearchPromotion.Limit) ? "10" : aOSearchPromotion.Limit;
            aOSearchPromotion.CurrentDate = string.IsNullOrEmpty(aOSearchPromotion.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchPromotion.CurrentDate;
            aOSearchPromotion.CurrentPage = string.IsNullOrEmpty(aOSearchPromotion.CurrentPage) ? "0" : aOSearchPromotion.CurrentPage;
            aOSearchPromotion.Status = string.IsNullOrEmpty(aOSearchPromotion.Status) ? "0" : aOSearchPromotion.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchPromotion.Title))
            {
                condition += @" and p.title like @Title ";
            }

            if (Convert.ToInt32(aOSearchPromotion.Status) > 0)
            {
                condition += @" and p.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchPromotion.CurrentDate))
            {
                condition += @" and p.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select count(1) 
                from promotion p
	                left join status st on st.id = p.status
                    left join users uc on uc.id = p.createuser
                    left join users up on up.id = p.updateuser
                where p.status != @StatusExcep " + condition + @" ;";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                Title = "%" + aOSearchPromotion.Title + "%",
                Status = aOSearchPromotion.Status,
                CurrentDate = aOSearchPromotion.CurrentDate
            });
        }

        public async Task<APromotionModel> QueryGetPromotionDetail(ulong Id)
        {
            var query = @"select p.Id, ifnull(p.Title, N'') Title, p.FromDate, p.ToDate, 
                        case 
						    when ifnull(p.image, N'') != '' 
						    then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Promotion/Promotion_', p.id, '/', p.image)
						    else ifnull(p.image, '') 
                        end Image, p.Status 
                        from promotion p 
                        where p.status != @Status and p.id = @Id;";

            return await _p2NPetDapper.QuerySingleAsync<APromotionModel>(query, new
            {
                Status = 190,
                Id
            });
        }
    }
}
