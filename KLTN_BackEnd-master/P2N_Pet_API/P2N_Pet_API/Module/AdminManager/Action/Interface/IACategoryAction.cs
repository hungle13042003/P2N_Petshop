using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ACategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action.Interface
{
    public interface IACategoryAction
    {
        Task<Category> CreateCategory(ACategoryCreateModel aCategoryCreate, ForceInfo forceInfo);
        Task<Category> UpdateCategory(ACategoryUpdateModel aCategoryUpdate, ForceInfo forceInfo);
        Task<Category> DeleteCategory( int categoryid, ForceInfo forceInfo);
    }
}
