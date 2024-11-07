using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ABreed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IABreedAction
    {
        Task<Breed> Create(ForceInfo forceInfo, ABreedCreateModel aBreedCreateModel);
        Task<Breed> Update(ForceInfo forceInfo, ABreedUpdateModel aBreedUpdateModel);
        Task<Breed> Delete(ForceInfo forceInfo, ulong Id);
    }
}
