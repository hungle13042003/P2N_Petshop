using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ABrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IABrandService
    {
        Task<Brand> CreateBrandPet(ABrandCreateModel aBrandCreate, ForceInfo forceInfo);
        Task<Brand> UpdateBrandPet(ABrandUpdateModel aBrandUpdate, ForceInfo forceInfo);
        Task<Brand> DeleteBrandPet(ulong brandid, ForceInfo forceInfo);
        Task<List<ABrandListModel>> GetListBrand(AOSearchBrand aOSearchBrand);
        Task<ABrandModel> GetDetailBrand(ulong brandid);
        Task<PaginationModel> GetListBrandPagination(AOSearchBrand aOSearchBrand);
    }
}
