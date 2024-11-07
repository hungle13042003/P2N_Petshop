using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class AProductAction : IAProductAction
    {
        private readonly PetShopContext _petShopContext;

        public AProductAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Product> Create(ForceInfo forceInfo, AProductCreateModel aProductCreateModel)
        {
            var product = new Product
            {
                Breedid = aProductCreateModel.BreedId == 0 ? null : aProductCreateModel.BreedId,
                Supplierid = aProductCreateModel.SupplierId,
                Content = aProductCreateModel.Content,
                Status = aProductCreateModel.Status,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow,
                Productname = aProductCreateModel.ProductName ?? "",
                Categoryid = aProductCreateModel.CategoryId == 0 ? null : aProductCreateModel.CategoryId                
            };

            _petShopContext.Products.Add(product);
            await _petShopContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(ForceInfo forceInfo, AProductUpdateModel aProductUpdateModel)
        {
            var product = _petShopContext.Products.Where(a => a.Id == aProductUpdateModel.Id).FirstOrDefault();

            product.Breedid = aProductUpdateModel.BreedId == 0 ? null : aProductUpdateModel.BreedId;
            product.Supplierid = aProductUpdateModel.SupplierId;
            product.Content = aProductUpdateModel.Content;
            product.Status = aProductUpdateModel.Status;
            product.Updateuser = forceInfo.UserId;
            product.Updatedate = forceInfo.DateNow;
            product.Categoryid = aProductUpdateModel.CategoryId == 0 ? null : aProductUpdateModel.CategoryId;
            product.Productname = aProductUpdateModel.ProductName;

            _petShopContext.Products.Update(product);
            await _petShopContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Delete(ForceInfo forceInfo, ulong Id)
        {
            var product = _petShopContext.Products.Where(a => a.Id == Id).FirstOrDefault();

            product.Status = 190;
            product.Updateuser = forceInfo.UserId;
            product.Updatedate = forceInfo.DateNow;

            _petShopContext.Products.Update(product);
            await _petShopContext.SaveChangesAsync();

            return product;
        }
    }
}
