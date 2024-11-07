using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ANews;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class ANewsQuery: IANewsQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public ANewsQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<int> QueryCountNews(AOSearchNews aOSearchNews)
        {
            var condition = @"";

            aOSearchNews.Limit = aOSearchNews.Limit != 0 ? aOSearchNews.Limit : 20;

            if (!String.IsNullOrEmpty(aOSearchNews.Title))
            {
                condition += " and n.title like @Title ";
            }

            if (aOSearchNews.TypeNewsId > 0)
            {
                condition += " and n.typenewsid = @TypeNewsId ";
            }

            if (aOSearchNews.Status > 0)
            {
                condition += " and n.status = @Status ";
            }

            var query =
                @"select count(1)
                from news n 
                    left join typenews tn on tn.id = n.typenewsid 
                    left join status s on s.id = n.status 
                    left join users cu on cu.id = n.createuser 
                    left join users uu on uu.id = n.updateuser 
                where n.status != @StatusException " + condition + @" ";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusException = 190,
                Status = aOSearchNews.Status,
                Title = "%" + aOSearchNews.Title + "%",
                TypeNewsId = aOSearchNews.TypeNewsId
            });
        }

        public async Task<List<ANewsListModel>> QueryListNews(AOSearchNews aOSearchNews)
        {
            var condition = @"";

            aOSearchNews.Limit = aOSearchNews.Limit != 0 ? aOSearchNews.Limit : 20;

            if (!String.IsNullOrEmpty(aOSearchNews.Title))
            {
                condition += " and n.title like @Title ";
            }

            if(aOSearchNews.TypeNewsId > 0)
            {
                condition += " and n.typenewsid = @TypeNewsId ";
            }

            if(aOSearchNews.Status > 0)
            {
                condition += " and n.status = @Status ";
            }

            var query =
                @"select n.Id, ifnull(n.title, N'') Title, ifnull(n.content, N'') Content, ifnull(n.htmlcontent, N'') HtmlContent, 
                case 
                    when ifnull(n.image, '') != ''
                    then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/News/News_', n.Id, '/', ifnull(n.image, ''))
                    else ''  
                end Image, 
                ifnull(tn.title, N'') TypeNewsText, ifnull(s.title, N'') StatusText, ifnull(cu.name, N'') CreateUserName, n.CreateDate,
                ifnull(uu.name, N'') UpdateUserName, n.UpdateDate 
                from news n 
                    left join typenews tn on tn.id = n.typenewsid 
                    left join status s on s.id = n.status 
                    left join users cu on cu.id = n.createuser 
                    left join users uu on uu.id = n.updateuser 
                where n.status != @StatusException " + condition + @" 
                order by n.createdate desc, n.title asc 
                limit @Offset, @Limit ";

            return await _p2NPetDapper.QueryAsync<ANewsListModel>(query, new
            {
                StatusException = 190,
                Status = aOSearchNews.Status,
                Title = "%" + aOSearchNews.Title +"%",
                TypeNewsId = aOSearchNews.TypeNewsId,
                Offset = aOSearchNews.CurrentPage * aOSearchNews.Limit,
                Limit = aOSearchNews.Limit
            });
        }

        public async Task<ANewsModel> QueryOneNews(ulong newsId)
        {
            var query =
                @"select Id, ifnull(title, N'') Title, ifnull(content, N'') Content, ifnull(htmlcontent, N'') HtmlContent, 
                case 
                    when ifnull(image, '') != ''
                    then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/News/News_', id, '/', ifnull(image, ''))
                    else ''  
                end Image, 
                TypeNewsId, Status 
                from news 
                where status != @StatusException and id = @NewsId ";

            return await _p2NPetDapper.QuerySingleAsync<ANewsModel>(query, new
            {
                StatusException = 190,
                NewsId = newsId
            });
        }
    }
}
