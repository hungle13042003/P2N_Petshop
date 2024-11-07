using P2N_Pet_API.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query.Interface
{
    public interface ICategoryQuery
    {
        Task<List<BreedListModel>> QueryListBreedParent();
        Task<List<BreedListModel>> QueryListBreedChild(ulong breedid);
        Task<List<SupplierListModel>> QueryListSupplierChild();
        Task<List<CategoryModel>> QueryListCategory();
        Task<List<CategoryListModel>> QueryListCategoryChill(ulong categoryid);
    }
}
