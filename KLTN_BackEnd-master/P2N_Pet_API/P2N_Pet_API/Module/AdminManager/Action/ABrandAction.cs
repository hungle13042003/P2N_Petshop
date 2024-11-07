using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ABrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class ABrandAction : IABrandAction
    {
        private readonly PetShopContext _petShopContext;

        public ABrandAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Brand> CreateBrandPet(ABrandCreateModel aBrandCreate, ForceInfo forceInfo)
        {
            aBrandCreate.aBrandProducts = aBrandCreate.aBrandProducts.Where(a => a.ProductDetailId > 0 && a.QuantityInBrand > 0).ToList();

            var brand = new Brand
            {
                Phone = aBrandCreate.Phone,
                Email = aBrandCreate.Email,
                Address = aBrandCreate.Address,
                Status = aBrandCreate.Status,
                Createdate = forceInfo.DateNow,
                Updatedate = forceInfo.DateNow,
                Createuser = forceInfo.UserId,
                Updateuser = forceInfo.UserId
            };

            _petShopContext.Brands.Add(brand);
            await _petShopContext.SaveChangesAsync();

            var bandProduct = aBrandCreate.aBrandProducts.Select(b =>
            {
                return new Brandproduct
                {
                    Brandid = brand.Id,
                    Productdetailid = b.ProductDetailId,
                    Quantity = b.QuantityInBrand,
                    Status = 10,
                    Createdate = forceInfo.DateNow,
                    Updatedate = forceInfo.DateNow,
                    Createuser = forceInfo.UserId,
                    Updateuser = forceInfo.UserId
                };
            });

            _petShopContext.Brandproducts.AddRange(bandProduct);
            await _petShopContext.SaveChangesAsync();

            return brand;
        }

        public async Task<Brand> UpdateBrandPet(ABrandUpdateModel aBrandUpdate, ForceInfo forceInfo)
        {
            aBrandUpdate.aBrandProducts = aBrandUpdate.aBrandProducts.Where(a => a.ProductDetailId > 0 && a.QuantityInBrand > 0).ToList();

            var brand = _petShopContext.Brands.Where(b => b.Id == aBrandUpdate.Id).FirstOrDefault();

            brand.Email = string.IsNullOrEmpty(aBrandUpdate.Email) ? brand.Email : aBrandUpdate.Email;
            brand.Phone = string.IsNullOrEmpty(aBrandUpdate.Phone) ? brand.Phone : aBrandUpdate.Phone;
            brand.Address = string.IsNullOrEmpty(aBrandUpdate.Address) ? brand.Address : aBrandUpdate.Address;
            brand.Status = aBrandUpdate.Status;
            brand.Updateuser = forceInfo.UserId;
            brand.Updatedate = forceInfo.DateNow;

            _petShopContext.Brands.Update(brand);
            await _petShopContext.SaveChangesAsync();

            var brandProductEntities = _petShopContext.Brandproducts.Where(a => a.Brandid == brand.Id);

            if(brandProductEntities != null && brandProductEntities.Count() > 0)
            {
                await brandProductEntities.ForEachAsync(a =>
                {
                    var exist = aBrandUpdate.aBrandProducts.Where(x => x.ProductDetailId == a.Productdetailid).FirstOrDefault();

                    if (exist != null)
                    {
                        a.Quantity = exist.QuantityInBrand;
                        a.Status = 10;
                        a.Updatedate = forceInfo.DateNow;
                        a.Updateuser = forceInfo.UserId;
                    }
                    else
                    {
                        a.Status = 190;
                        a.Updatedate = forceInfo.DateNow;
                        a.Updateuser = forceInfo.UserId;
                    }
                });

                await _petShopContext.SaveChangesAsync();
            }

            var brandProducts = aBrandUpdate.aBrandProducts
                .Where(p => brandProductEntities == null || brandProductEntities.Count() == 0 ||
                !brandProductEntities.Select(x => x.Productdetailid).Contains(p.ProductDetailId))
                .Select(p =>
               {
                   return new Brandproduct
                   {
                       Brandid = brand.Id,
                       Productdetailid = p.ProductDetailId,
                       Quantity = p.QuantityInBrand,
                       Status = 10,
                       Createdate = forceInfo.DateNow,
                       Updatedate = forceInfo.DateNow,
                       Createuser = forceInfo.UserId,
                       Updateuser = forceInfo.UserId
                   };
               });

            _petShopContext.Brandproducts.AddRange(brandProducts);
            await _petShopContext.SaveChangesAsync();

            return brand;
        }

        public async Task<Brand> DeleteBrandPet(ulong brandid, ForceInfo forceInfo)
        {
            var brand = _petShopContext.Brands.Where(b => b.Id == brandid && b.Status != 190).FirstOrDefault();

            if(brand != null)
            {
                brand.Status = 190;
                brand.Updateuser = forceInfo.UserId;
                brand.Updatedate = forceInfo.DateNow;

                _petShopContext.Brands.Update(brand);
                await _petShopContext.SaveChangesAsync();
            }

            return brand;
        }
    }
}
