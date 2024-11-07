using P2N_Pet_API.Models.News;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query
{
    public class NewsQuery: INewsQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public NewsQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<NewsModel>> QueryListNews(OSearchNews oSearchNews)
        {
            var condition = @"";
            oSearchNews.Limit = oSearchNews.Limit != 0 ? oSearchNews.Limit : 20;

            if (!String.IsNullOrEmpty(oSearchNews.FindString))
            {
                condition = @" and n.title like @FindString ";
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
                where n.status = @Status " + condition + @" 
                order by n.createdate desc, n.title asc 
                limit @Offset, @Limit ";

            return await _p2NPetDapper.QueryAsync<NewsModel>(query, new
            {
                Status = 10,
                Offset = oSearchNews.CurrentPage * oSearchNews.Limit,
                Limit = oSearchNews.Limit,
                FindString  = "%" + oSearchNews.FindString + "%"
            });
        }
        public async Task<NewsOneModel> QueryOneNews(ulong newsId)
        {
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
                where n.status = @Status and n.id = @NewsId ";

            return await _p2NPetDapper.QuerySingleAsync<NewsOneModel>(query, new
            {
                Status = 10,
                NewsId = newsId
            });
        }

        public async Task<int> QueryCountListNews(OSearchNews oSearchNews)
        {
            var condition = @"";
            oSearchNews.Limit = oSearchNews.Limit != 0 ? oSearchNews.Limit : 20;

            if (!String.IsNullOrEmpty(oSearchNews.FindString))
            {
                condition = @" and n.title like @FindString ";
            }

            var query =
                @"select count(1) 
                from news n 
                    left join typenews tn on tn.id = n.typenewsid 
                    left join status s on s.id = n.status 
                    left join users cu on cu.id = n.createuser 
                    left join users uu on uu.id = n.updateuser 
                where n.status = @Status " + condition + @" ";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                Status = 10,
                FindString = "%" + oSearchNews.FindString + "%"
            });
        }
    }
}
