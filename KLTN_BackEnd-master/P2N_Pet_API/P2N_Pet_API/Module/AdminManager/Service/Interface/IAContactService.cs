using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IAContactService
    {
        Task<List<AContactListModel>> GetListContact(AOSearchContact aOSearchContact);
        Task<PaginationModel> GetListContactPagination(AOSearchContact aOSearchContact);
        Task<AContactModel> GetContactDetail(ulong Id);
        Task<Contact> CreateContact(DateTime dateNow, AContactCreateModel aContactCreateModel);
        Task<Contact> UpdateContact(AContactUpdateModel aContactUpdateModel);
        Task<Contact> DeleteContact(ulong Id);

        Task<int> GetCountContact();
    }
}
