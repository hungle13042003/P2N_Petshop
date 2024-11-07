using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AAge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IAAgeAction
    {
        Task<Age> Create(ForceInfo forceInfo, AAgeCreateModel aAgeCreateModel);
        Task<Age> Update(ForceInfo forceInfo, AAgeUpdateModel aAgeUpdateModel);
        Task<Age> Delete(ForceInfo forceInfo, ulong id);

    }
}
