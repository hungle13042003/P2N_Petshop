using P2N_Pet_API.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service.Interface
{
    public interface ICategoryService
    {
        Task<List<BreedListModel>> GetListBreedParrent();
        Task<List<BreedListModel>> GetListBreedChild(ulong breedid);
        Task<List<SupplierListModel>> GetListSupplierChild();

        Task<List<BreedModel>> GetListBreedAll();
        Task<List<CategoryModel>> GetListCategoryAll();
    }
}
