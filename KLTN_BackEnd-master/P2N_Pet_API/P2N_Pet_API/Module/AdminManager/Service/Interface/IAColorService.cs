using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IAColorService
    {
        Task<List<AColorListModel>> GetListColor(AOSearchColor aOSearchColor);
        Task<PaginationModel> GetListColorPagination(AOSearchColor aOSearchColor);
        Task<AColorModel> GetColorDetail(ulong Id);
        Task<Color> CreateColor(ForceInfo forceInfo, AColorCreateModel aColorCreateModel);
        Task<Color> UpdateColor(ForceInfo forceInfo, AColorUpdateModel aColorUpdateModel);
        Task<Color> DeleteColor(ForceInfo forceInfo, ulong Id);
    }
}
