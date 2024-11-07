using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AContact;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class AContactService : IAContactService
    {
        private readonly IAContactQuery _aContactQuery;
        private readonly IAContactAction _aContactAction;
        private readonly IPaginationService _paginationService;

        public AContactService(IAContactQuery aContactQuery,
            IAContactAction aContactAction,
            IPaginationService paginationService)
        {
            _aContactQuery = aContactQuery;
            _aContactAction = aContactAction;
            _paginationService = paginationService;
        }

        public async Task<List<AContactListModel>> GetListContact(AOSearchContact aOSearchContact)
        {
            return await _aContactQuery.QueryGetListContact(aOSearchContact);
        }

        public async Task<PaginationModel> GetListContactPagination(AOSearchContact aOSearchContact)
        {
            var count = await _aContactQuery.QueryCountListContact(aOSearchContact);
            var dateNow = Utils.DateNow();

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchContact.CurrentPage),
                dateNow.ToString(), Convert.ToInt32(aOSearchContact.Limit));

            return pagination;
        }

        public async Task<AContactModel> GetContactDetail(ulong Id)
        {
            return await _aContactQuery.QueryGetContactDetail(Id);
        }

        public async Task<Contact> CreateContact(DateTime dateNow, AContactCreateModel aContactCreateModel)
        {
            return await _aContactAction.Create(dateNow, aContactCreateModel);
        }

        public async Task<Contact> UpdateContact(AContactUpdateModel aContactUpdateModel)
        {
            return await _aContactAction.Update(aContactUpdateModel);
        }

        public async Task<Contact> DeleteContact(ulong Id)
        {
            return await _aContactAction.Delete(Id);
        }

        public async Task<int> GetCountContact()
        {
            return await _aContactQuery.QueryCountContact();
        }
    }
}
