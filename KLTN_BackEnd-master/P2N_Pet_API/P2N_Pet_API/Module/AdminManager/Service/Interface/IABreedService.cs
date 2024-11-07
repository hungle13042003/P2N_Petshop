using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ABreed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IABreedService
    {
        Task<List<ABreedListModel>> GetListBreed(AOSearchBreed aOSearchBreed);
        Task<PaginationModel> GetListBreedPagination(AOSearchBreed aOSearchBreed);
        Task<ABreedModel> GetBreedDetail(ulong Id);
        Task<Breed> CreateBreed(ForceInfo forceInfo, ABreedCreateModel aBreedCreateModel);
        Task<Breed> UpdateBreed(ForceInfo forceInfo, ABreedUpdateModel aBreedUpdateModel);
        Task<Breed> DeleteBreed(ForceInfo forceInfo, ulong Id);
    }
}
