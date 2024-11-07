using P2N_Pet_API.Module.AdminManager.Models.ANews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IANewsQuery
    {
        Task<List<ANewsListModel>> QueryListNews(AOSearchNews aOSearchNews);
        Task<ANewsModel> QueryOneNews(ulong newsId);
        Task<int> QueryCountNews(AOSearchNews aOSearchNews);
    }
}
