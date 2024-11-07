using Microsoft.AspNetCore.Http;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ANews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IANewsAction
    {
        Task<News> CreateNews(ForceInfo forceInfo, ANewsCreateModel aNewsCreateModel);
        Task<CloudOneMediaModel> SaveOneMediaData(IFormFile imageNews, ulong newsId);
        Task UpdateImageNews(ulong newsId, ForceInfo forceInfo, CloudOneMediaModel cloudOneMediaModel);
        Task<News> UpdateNews(ForceInfo forceInfo, ANewsUpdateModel aNewsUpdateModel);
        Task DeleteNews(ForceInfo forceInfo, ulong NewsId);
    }
}
