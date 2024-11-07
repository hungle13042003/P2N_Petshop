using P2N_Pet_API.Models.Category;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public CategoryQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<BreedListModel>> QueryListBreedChild(ulong breedid)
        {
            var query =
                @"select id, name BreedName
                from breed
                where id != breedid and status = @Status and breedid = @BreedId";

            return await _p2NPetDapper.QueryAsync<BreedListModel>(query, new
            {
                Status = 10,
                BreedId = breedid
            });
        }

        public async Task<List<BreedListModel>> QueryListBreedParent()
        {
            var query =
                @"select Id, name BreedName
                from breed
                where id = breedid and status = 10";

            return await _p2NPetDapper.QueryAsync<BreedListModel>(query);
        }

        public async Task<List<CategoryModel>> QueryListCategory()
        {
            var query =
                @"select c.Id, ifnull(c.title, '') CategoryName, c.TypeProductId, tp.title TypeProductName
                from category c
                left join typeproduct tp on c.typeproductid = tp.id
                where c.status = 10 and c.id = c.categoryrootid and tp.status = 10";

            var cateParrent = await _p2NPetDapper.QueryAsync<CategoryModel>(query);

            if(cateParrent != null && cateParrent.Count > 0)
            {
                foreach(var cate in cateParrent)
                {
                    cate.CategoryChill = await QueryListCategoryChill(cate.Id);
                }
            }

            return cateParrent;
        }

        public async Task<List<CategoryListModel>> QueryListCategoryChill(ulong categoryid)
        {
            var query =
                @"select c.Id, ifnull(c.title, '') CategoryName, c.TypeProductId, tp.title TypeProductName
                from category c
                left join typeproduct tp on c.typeproductid = tp.id
                where c.status = 10 and c.id != c.categoryrootid and tp.status = 10 and c.categoryrootid = @CategoryId";

            return await _p2NPetDapper.QueryAsync<CategoryListModel>(query, new { CategoryId = categoryid });
        }

        public async Task<List<SupplierListModel>> QueryListSupplierChild()
        {
            var query =
                @"select Id, name SupplierName
                from supplier
                where status = @Status ";

            return await _p2NPetDapper.QueryAsync<SupplierListModel>(query, new
            {
                Status = 10
            });
        }
    }
}
