using Microsoft.AspNetCore.Hosting;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.UtilsService
{
    [Obsolete]
    public class CloudMediaService : ICloudMediaService
    {
        private readonly IHostingEnvironment _env;
        private readonly string _webRoot;

        public CloudMediaService(IHostingEnvironment env)
        {
            _env = env;
            _webRoot = _env.WebRootPath;
        }

        public async Task<List<CloudMediaModel>> SaveFileData(CloudMediaConfig cloudMedia)
        {
            var cloudMedias = new List<CloudMediaModel>();

            if (cloudMedia.CloudFiles != null && cloudMedia.CloudFiles.Count > 0)
            {
                foreach (var file in cloudMedia.CloudFiles)
                {
                    if (file.FormFile != null && file.FormFile.Length > 0)
                    {
                        var serverPath = Path.Combine(_webRoot, cloudMedia.Folder);

                        bool exists = Directory.Exists(serverPath);
                        if (!exists)
                        {
                            Directory.CreateDirectory(serverPath);
                        }

                        string extension = Path.GetExtension(file.FormFile.FileName);
                        string nameImage = cloudMedia.FileName + "_" + Utils.GenerateID() + extension;

                        var path = Path.Combine(serverPath, nameImage);
                        using var fileStream = new FileStream(path, FileMode.Create);
                        await file.FormFile.CopyToAsync(fileStream);

                        cloudMedias.Add(new CloudMediaModel
                        {
                            Index = file.Index,
                            FileName = nameImage,
                        });
                    }
                }
            }

            return cloudMedias;
        }

        public async Task<CloudOneMediaModel> SaveOneFileData(CloudOneMediaConfig cloudOneMedia)
        {
            var cloudOneMediaModel = new CloudOneMediaModel();

            if (cloudOneMedia.FormFile != null && cloudOneMedia.FormFile.Length > 0)
            {
                var serverPath = Path.Combine(_webRoot, cloudOneMedia.Folder);

                bool exists = Directory.Exists(serverPath);
                if (!exists)
                {
                    Directory.CreateDirectory(serverPath);
                }

                string extension = Path.GetExtension(cloudOneMedia.FormFile.FileName);
                string nameImage = cloudOneMedia.FileName + "_" + Utils.GenerateID() + extension;

                var path = Path.Combine(serverPath, nameImage);
                using var fileStream = new FileStream(path, FileMode.Create);
                await cloudOneMedia.FormFile.CopyToAsync(fileStream);

                cloudOneMediaModel = new CloudOneMediaModel
                {
                    FileName = nameImage,
                };
            }

            return cloudOneMediaModel;
        }
    }
}
