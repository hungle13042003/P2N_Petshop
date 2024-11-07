using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IAProductAction
    {
        Task<Product> Create(ForceInfo forceInfo, AProductCreateModel aProductCreateModel);
        Task<Product> Update(ForceInfo forceInfo, AProductUpdateModel aProductUpdateModel);
        Task<Product> Delete(ForceInfo forceInfo, ulong Id);
    }
}
