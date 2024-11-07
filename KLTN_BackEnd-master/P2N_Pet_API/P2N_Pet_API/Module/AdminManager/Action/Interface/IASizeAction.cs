using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ASize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IASizeAction
    {
        Task<Size> Create(ForceInfo forceInfo, ASizeCreateModel aSizeCreateModel);
        Task<Size> Update(ForceInfo forceInfo, ASizeUpdateModel aSizeUpdateModel);
        Task<Size> Delete(ForceInfo forceInfo, ulong id);
    }
}
