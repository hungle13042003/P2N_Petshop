using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AAge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IAAgeService
    {
        Task<List<AAgeListModel>> GetListAge(AOSearchAge aOSearchAge);
        Task<PaginationModel> GetListAgePagination(AOSearchAge aOSearchAge);
        Task<AAgeModel> GetAgeDetail(ulong Id);
        Task<Age> CreateAge(ForceInfo forceInfo, AAgeCreateModel aAgeCreateModel);
        Task<Age> UpdateAge(ForceInfo forceInfo, AAgeUpdateModel aAgeUpdateModel);
        Task<Age> DeleteAge(ForceInfo forceInfo, ulong Id);
    }
}
