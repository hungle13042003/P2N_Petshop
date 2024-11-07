using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ABrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IABrandAction
    {
        Task<Brand> CreateBrandPet(ABrandCreateModel aBrandCreate, ForceInfo forceInfo);
        Task<Brand> UpdateBrandPet(ABrandUpdateModel aBrandUpdate, ForceInfo forceInfo);
        Task<Brand> DeleteBrandPet(ulong brandid, ForceInfo forceInfo);
    }
}
