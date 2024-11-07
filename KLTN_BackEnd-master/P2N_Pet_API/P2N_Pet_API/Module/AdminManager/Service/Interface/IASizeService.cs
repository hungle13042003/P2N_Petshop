using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ASize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IASizeService
    {
        Task<List<ASizeListModel>> GetListSize(AOSearchSize aOSearchSize);
        Task<PaginationModel> GetListSizePagination(AOSearchSize aOSearchSize);
        Task<ASizeModel> GetSizeDetail(ulong Id);
        Task<Size> CreateSize(ForceInfo forceInfo, ASizeCreateModel aSizeCreateModel);
        Task<Size> UpdateSize(ForceInfo forceInfo, ASizeUpdateModel aSizeUpdateModel);
        Task<Size> DeleteSize(ForceInfo forceInfo, ulong Id);
    }
}
