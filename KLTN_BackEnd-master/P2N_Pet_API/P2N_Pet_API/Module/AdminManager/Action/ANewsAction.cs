using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ANews;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class ANewsAction: IANewsAction
    {
        private readonly PetShopContext _petShopContext;
        private readonly ICloudMediaService _cloudMediaService;

        public ANewsAction(PetShopContext petShopContext,
            ICloudMediaService cloudMediaService)
        {
            _petShopContext = petShopContext;
            _cloudMediaService = cloudMediaService;
        }

        public async Task<News> CreateNews(ForceInfo forceInfo, ANewsCreateModel aNewsCreateModel)
        {
            var news = new News
            {
                Title = aNewsCreateModel.Title,
                Content = aNewsCreateModel.Content,
                Htmlcontent = aNewsCreateModel.HtmlContent,
                Typenewsid = aNewsCreateModel.TypeNewsId,
                Status = 10,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.News.Add(news);
            await _petShopContext.SaveChangesAsync();

            return news;
        }

        public async Task<CloudOneMediaModel> SaveOneMediaData(IFormFile imageNews, ulong newsId)
        {
            var cloudOneMediaConfig = new CloudOneMediaConfig
            {
                Folder = "Upload/News/News_" + newsId,
                FileName = "Image_News",
                FormFile = imageNews
            };

            return await _cloudMediaService.SaveOneFileData(cloudOneMediaConfig);
        }

        public async Task UpdateImageNews(ulong newsId, ForceInfo forceInfo, CloudOneMediaModel cloudOneMediaModel)
        {
            var news = await _petShopContext.News.FirstOrDefaultAsync(a => a.Id == newsId);

            if(news != null)
            {
                news.Image = cloudOneMediaModel.FileName;

                _petShopContext.News.Update(news);
                await _petShopContext.SaveChangesAsync();
            }
        }

        public async Task<News> UpdateNews(ForceInfo forceInfo, ANewsUpdateModel aNewsUpdateModel)
        {
            var news = await _petShopContext.News.FindAsync(aNewsUpdateModel.Id);

            if(news != null)
            {
                news.Title = aNewsUpdateModel.Title;
                news.Content = aNewsUpdateModel.Content;
                news.Htmlcontent = aNewsUpdateModel.HtmlContent;
                news.Typenewsid = aNewsUpdateModel.TypeNewsId;
                news.Status = aNewsUpdateModel.Status;
                news.Updateuser = forceInfo.UserId;
                news.Updatedate = forceInfo.DateNow;

                _petShopContext.News.Update(news);
                await _petShopContext.SaveChangesAsync();
            }

            return news;
        }

        public async Task DeleteNews(ForceInfo forceInfo, ulong NewsId)
        {
            var news = await _petShopContext.News.FindAsync(NewsId);

            if(news != null)
            {
                news.Status = 190;
                news.Updateuser = forceInfo.UserId;
                news.Updatedate = forceInfo.DateNow;

                _petShopContext.News.Update(news);
                await _petShopContext.SaveChangesAsync();
            }
        }
    }
}
