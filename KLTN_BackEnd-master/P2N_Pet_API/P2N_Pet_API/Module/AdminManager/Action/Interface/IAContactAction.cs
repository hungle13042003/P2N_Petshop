using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Module.AdminManager.Models.AContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IAContactAction
    {
        Task<Contact> Create(DateTime dateNow, AContactCreateModel aContactCreateModel);
        Task<Contact> Update(AContactUpdateModel aContactUpdateModel);
        Task<Contact> Delete(ulong Id);
    }
}
