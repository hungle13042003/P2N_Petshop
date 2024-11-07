using P2N_Pet_API.Models.Category;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryQuery _categoryQuery;

        public CategoryService(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }

        public async Task<List<BreedModel>> GetListBreedAll()
        {
            var breedParent = await _categoryQuery.QueryListBreedParent();

            List<BreedModel> breedList = new List<BreedModel>();
            
            foreach( var item in breedParent)
            {
                var breedChild = await GetListBreedChild(item.Id);

                var model = new BreedModel()
                {
                    Id = item.Id,
                    BreedName = item.BreedName,
                    BreedChild = breedChild
                };

                breedList.Add(model);
            }

            return breedList;
        }

        public async Task<List<BreedListModel>> GetListBreedChild(ulong breedid)
        {
            return await _categoryQuery.QueryListBreedChild(breedid);
        }

        public async Task<List<BreedListModel>> GetListBreedParrent()
        {
            return await _categoryQuery.QueryListBreedParent();
        }

        public async Task<List<CategoryModel>> GetListCategoryAll()
        {
            return await _categoryQuery.QueryListCategory();
        }

        public async Task<List<SupplierListModel>> GetListSupplierChild()
        {
            return await _categoryQuery.QueryListSupplierChild();
        }
    }
}
