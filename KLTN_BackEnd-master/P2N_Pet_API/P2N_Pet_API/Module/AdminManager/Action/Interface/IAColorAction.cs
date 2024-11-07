using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IAColorAction
    {
        Task<Color> Create(ForceInfo forceInfo, AColorCreateModel aColorCreateModel);
        Task<Color> Update(ForceInfo forceInfo, AColorUpdateModel aColorUpdateModel);
        Task<Color> Delete(ForceInfo forceInfo, ulong Id);
    }
}
