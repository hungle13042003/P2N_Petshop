using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ASupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IASupplierAction
    {
        Task<Supplier> Create(ForceInfo forceInfo, ASupplierCreateModel aSupplierCreateModel);
        Task<Supplier> Update(ForceInfo forceInfo, ASupplierUpdateModel aSupplierUpdateModel);
        Task<Supplier> Delete(ForceInfo forceInfo, ulong Id);
    }
}
