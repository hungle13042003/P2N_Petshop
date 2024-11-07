using P2N_Pet_API.Module.AdminManager.Models.AContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IAContactQuery
    {
        Task<List<AContactListModel>> QueryGetListContact(AOSearchContact aOSearchContact);
        Task<AContactModel> QueryGetContactDetail(ulong Id);
        Task<int> QueryCountListContact(AOSearchContact aOSearchContact);
        Task<int> QueryCountContact();
    }
}
