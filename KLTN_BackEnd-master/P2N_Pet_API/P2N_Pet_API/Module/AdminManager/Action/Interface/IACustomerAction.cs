using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ACustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IACustomerAction
    {
        Task<Customer> Create(ForceInfo forceInfo, ACustomerCreateModel aCustomerCreateModel);
        Task<Customer> Update(ForceInfo forceInfo, ACustomerUpdateModel aCustomerUpdateModel);
        Task<Customer> Delete(ForceInfo forceInfo, ulong Id);
    }
}
