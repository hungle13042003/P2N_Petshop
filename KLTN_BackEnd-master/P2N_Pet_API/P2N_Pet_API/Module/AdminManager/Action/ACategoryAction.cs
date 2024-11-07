using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ACategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class ACategoryAction : IACategoryAction
    {
        private readonly PetShopContext _petShopContext;

        public ACategoryAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Category> CreateCategory(ACategoryCreateModel aCategoryCreate, ForceInfo forceInfo)
        {
            var category = new Category
            {
                Title = aCategoryCreate.Title,
                Status = aCategoryCreate.Status,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow,
                Typeproductid = aCategoryCreate.TypeProductId
            };

            _petShopContext.Categories.Add(category);
            await _petShopContext.SaveChangesAsync();


            if ( aCategoryCreate.CategoryRootId == 0)
            {
                category.Categoryrootid = category.Id;
            }
            else
            {
                category.Categoryrootid = aCategoryCreate.CategoryRootId;
            }

            _petShopContext.Categories.Update(category);
            await _petShopContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> DeleteCategory(int categoryid, ForceInfo forceInfo)
        {
            var category = _petShopContext.Categories.Where(a => a.Id == categoryid).FirstOrDefault();

            if(category != null)
            {
                category.Status = 190;
                category.Updatedate = forceInfo.DateNow;
                category.Updateuser = forceInfo.UserId;

                _petShopContext.Categories.Update(category);
                await _petShopContext.SaveChangesAsync();
            }

            return category;
        }

        public async Task<Category> UpdateCategory(ACategoryUpdateModel aCategoryUpdate, ForceInfo forceInfo)
        {
            var category = _petShopContext.Categories.Where(a => a.Id == aCategoryUpdate.Id).FirstOrDefault();

            if (category != null)
            {
                category.Title = aCategoryUpdate.Title;
                category.Categoryrootid = aCategoryUpdate.CategoryRootId;
                category.Status = aCategoryUpdate.Status;
                category.Updatedate = forceInfo.DateNow;
                category.Updateuser = forceInfo.UserId;
                category.Typeproductid = aCategoryUpdate.TypeProductId;

                _petShopContext.Categories.Update(category);
                await _petShopContext.SaveChangesAsync();
            }

            return category;
        }
    }
}
