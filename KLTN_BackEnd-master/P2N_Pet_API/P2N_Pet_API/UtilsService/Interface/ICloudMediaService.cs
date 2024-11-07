using P2N_Pet_API.Models.CloudMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.UtilsService.Interface
{
    public interface ICloudMediaService
    {
        Task<List<CloudMediaModel>> SaveFileData(CloudMediaConfig cloudMedia);
        Task<CloudOneMediaModel> SaveOneFileData(CloudOneMediaConfig cloudOneMedia);
    }
}
