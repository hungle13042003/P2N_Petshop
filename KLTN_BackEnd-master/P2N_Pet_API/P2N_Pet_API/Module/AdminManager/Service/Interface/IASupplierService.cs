using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ASupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IASupplierService
    {
        Task<List<ASupplierListModel>> GetListSupplier(AOSearchSupplier aOSearchSupplier);
        Task<PaginationModel> GetListSupplierPagination(AOSearchSupplier aOSearchSupplier);
        Task<ASupplierModel> GetSupplierDetail(ulong Id);
        Task<Supplier> CreateSupplier(ForceInfo forceInfo, ASupplierCreateModel aSupplierCreateModel);
        Task<Supplier> UpdateSupplier(ForceInfo forceInfo, ASupplierUpdateModel aSupplierUpdateModel);
        Task<Supplier> DeleteSupplier(ForceInfo forceInfo, ulong Id);
    }
}
