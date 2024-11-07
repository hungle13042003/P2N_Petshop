using P2N_Pet_API.Models.Promotion;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query
{
    public class PromotionQuery : IPromotionQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;
        public PromotionQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<PromotionModel> QueryPromotion(DateTime dateNow)
        {
            var query =
                @"select p.Id, ifnull(p.title, '') Title,
		                case when ifnull(p.image, '') != '' 
			                then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Promotion/Promotion_', p.id, '/', p.image)
			                when ifnull(p.image, '') = '' 
			                then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Promotion/default.jpg')
			                else '' 
		                end Image 
                from promotion p
                where status = @Status and CAST(@DateNow as DateTime) >= CAST(fromdate as DateTime) 
                      and CAST(@DateNow as DateTime) <= CAST(todate as DateTime) 
                union
                select 0 Id, N'Quảng cáo mặc định' Title, CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/Promotion/default.jpg') Image;";

            return await _p2NPetDapper.QuerySingleAsync<PromotionModel>(query, new
            {
                Status = 10,
                DateNow = dateNow
            });
        }
    }
}
