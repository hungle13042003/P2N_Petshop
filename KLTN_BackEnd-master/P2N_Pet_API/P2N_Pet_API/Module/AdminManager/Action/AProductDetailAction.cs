using Microsoft.EntityFrameworkCore;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AProductDetail;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class AProductDetailAction : IAProductDetailAction
    {
        private readonly PetShopContext _petShopContext;
        private readonly ICloudMediaService _cloudMediaService;

        public AProductDetailAction(PetShopContext petShopContext,
            ICloudMediaService cloudMediaService)
        {
            _petShopContext = petShopContext;
            _cloudMediaService = cloudMediaService;
        }

        public async Task<Productdetail> Create(ForceInfo forceInfo, AProductDetailCreateModel aProductDetailCreateModel)
        {
            // parse json to object
            var brandsModel = JsonSerializer.Deserialize<List<AProductDetailBrandModel>>(aProductDetailCreateModel.brands);

            brandsModel = brandsModel.Where(x => x.BrandId > 0 && Convert.ToInt32(x.QuantityInBrand) > 0).ToList();

            var productDetail = new Productdetail
            {
                Productid = aProductDetailCreateModel.ProductId,
                Colorid = aProductDetailCreateModel.ColorId == 0 ? null : aProductDetailCreateModel.ColorId,
                Sizeid = aProductDetailCreateModel.SizeId == 0 ? null : aProductDetailCreateModel.SizeId,
                Ageid = aProductDetailCreateModel.AgeId == 0 ? null : aProductDetailCreateModel.AgeId,
                Sexid = aProductDetailCreateModel.SexId == 0 ? null : aProductDetailCreateModel.SexId,
                Statusdetailid = aProductDetailCreateModel.StatusDetailId,
                Price = aProductDetailCreateModel.Price,
                Discount = aProductDetailCreateModel.Discount,
                Quantity = aProductDetailCreateModel.Quantity,
                Status = aProductDetailCreateModel.Status,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Productdetails.Add(productDetail);
            await _petShopContext.SaveChangesAsync();

            var brands = brandsModel.Select(a => new Brandproduct
            {
                Brandid = a.BrandId,
                Productdetailid = productDetail.Id,
                Quantity = Convert.ToInt32(a.QuantityInBrand),
                Status = 10,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            });

            _petShopContext.Brandproducts.AddRange(brands);
            await _petShopContext.SaveChangesAsync();

            return productDetail;
        }

        public async Task<Productdetail> Update(ForceInfo forceInfo, AProductDetailUpdateModel aProductDetailUpdateModel)
        {
            var brandsModel = JsonSerializer.Deserialize<List<AProductDetailBrandV2Model>>(aProductDetailUpdateModel.ProductBrands);
            brandsModel = brandsModel.Where(x => x.BrandId > 0 && Convert.ToInt32(x.QuantityInBrand) > 0).ToList();

            var productDetail = _petShopContext.Productdetails.Where(a => a.Id == aProductDetailUpdateModel.Id).FirstOrDefault();

            productDetail.Productid = aProductDetailUpdateModel.ProductId;
            productDetail.Colorid = aProductDetailUpdateModel.ColorId == 0 ? null : aProductDetailUpdateModel.ColorId;
            productDetail.Sizeid = aProductDetailUpdateModel.SizeId == 0 ? null : aProductDetailUpdateModel.SizeId;
            productDetail.Ageid = aProductDetailUpdateModel.AgeId == 0 ? null : aProductDetailUpdateModel.AgeId;
            productDetail.Sexid = aProductDetailUpdateModel.SexId == 0 ? null : aProductDetailUpdateModel.SexId;
            productDetail.Statusdetailid = aProductDetailUpdateModel.StatusDetailId;
            productDetail.Price = aProductDetailUpdateModel.Price;
            productDetail.Discount = aProductDetailUpdateModel.Discount;
            productDetail.Quantity = aProductDetailUpdateModel.Quantity;
            productDetail.Status = aProductDetailUpdateModel.Status;
            productDetail.Updateuser = forceInfo.UserId;
            productDetail.Updatedate = forceInfo.DateNow;

            _petShopContext.Productdetails.Update(productDetail);
            await _petShopContext.SaveChangesAsync();


            var brandProductEntities = _petShopContext.Brandproducts.Where(a => a.Productdetailid == aProductDetailUpdateModel.Id);

            if( brandProductEntities != null && brandProductEntities.Count() > 0)
            {
                await brandProductEntities.ForEachAsync(a =>
               {
                   var exists = brandsModel.Where(x => x.BrandId == a.Brandid).FirstOrDefault();

                   if (exists != null)
                   {
                       a.Status = 10;
                       a.Quantity = Convert.ToInt32(exists.QuantityInBrand);
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

            var brands = brandsModel
                .Where(x => brandProductEntities == null || brandProductEntities.Count() == 0
                           || !brandProductEntities.Select(p => p.Brandid).Contains(x.BrandId))
                .Select(x => new Brandproduct
                {
                    Brandid = x.BrandId,
                    Productdetailid = aProductDetailUpdateModel.Id,
                    Quantity =  Convert.ToInt32(x.QuantityInBrand),
                    Status = 10,
                    Createdate = forceInfo.DateNow,
                    Createuser = forceInfo.UserId,
                    Updatedate = forceInfo.DateNow,
                    Updateuser = forceInfo.UserId
                });

            await _petShopContext.Brandproducts.AddRangeAsync(brands);
            await _petShopContext.SaveChangesAsync();

            return productDetail;
        }

        public async Task<Productdetail> Delete(ForceInfo forceInfo, ulong Id)
        {
            var productDetail = _petShopContext.Productdetails.Where(a => a.Id == Id).FirstOrDefault();

            productDetail.Status = 190;
            productDetail.Updateuser = forceInfo.UserId;
            productDetail.Updatedate = forceInfo.DateNow;

            _petShopContext.Productdetails.Update(productDetail);
            await _petShopContext.SaveChangesAsync();

            return productDetail;
        }

        public async Task UpdateProductDetailImageOld(ForceInfo forceInfo, ulong productDetailId,List<ulong> imageOldIds)
        {
            var productImageFors = imageOldIds.Select(id => new Productimagefor
            {
                Productdetailid = productDetailId,
                Productimageid = id,
                Status = 10,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            });

            _petShopContext.Productimagefors.AddRange(productImageFors);
            await _petShopContext.SaveChangesAsync();
        }

        public async Task UpdateProductDetailImage(ForceInfo forceInfo, 
            AProductDetailUpdateModel aProductDetailUpdateModel, 
            List<CloudMediaModel> CloudMedias,
            List<ulong> idProductDetailDuplicates)
        {
            if (CloudMedias != null && CloudMedias.Count() > 0)
            {
                var productDetailImages = new List<Productimage>();

                foreach ( var CloudMedia in CloudMedias)
                {
                    var productDetailImage = new Productimage
                    {
                        Image = CloudMedia.FileName,
                        Status = 10,
                        Createdate = forceInfo.DateNow,
                        Createuser = forceInfo.UserId,
                        Updatedate = forceInfo.DateNow,
                        Updateuser = forceInfo.UserId
                    };

                    _petShopContext.Productimages.Add(productDetailImage);
                    await _petShopContext.SaveChangesAsync();

                    productDetailImages.Add(productDetailImage);
                }

                foreach (var id in idProductDetailDuplicates)
                {
                    var productImageFors = productDetailImages.Select(image => new Productimagefor
                    {
                        Productdetailid = id,
                        Productimageid = image.Id,
                        Status = 10,
                        Createdate = forceInfo.DateNow,
                        Createuser = forceInfo.UserId,
                        Updatedate = forceInfo.DateNow,
                        Updateuser = forceInfo.UserId
                    });

                    _petShopContext.Productimagefors.AddRange(productImageFors);
                    await _petShopContext.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteProductDetailImage(ForceInfo forceInfo, ulong productImageId, List<ulong> idProductImageForDuplicates)
        {
            var productImage = _petShopContext.Productimages.Where(p => p.Id == productImageId).FirstOrDefault();

            if (productImage != null)
            {
                productImage.Status = 190;
                productImage.Updateuser = forceInfo.UserId;
                productImage.Updatedate = forceInfo.DateNow;
            }

            _petShopContext.Productimages.Update(productImage);
            await _petShopContext.SaveChangesAsync();

            foreach(var id in idProductImageForDuplicates)
            {
                var productImageFor = _petShopContext.Productimagefors.Where(p => p.Id == id).FirstOrDefault();

                if(productImageFor != null)
                {
                    productImageFor.Status = 190;
                    productImageFor.Updateuser = forceInfo.UserId;
                    productImageFor.Updatedate = forceInfo.DateNow;

                    _petShopContext.Productimagefors.Update(productImageFor);
                    await _petShopContext.SaveChangesAsync();
                }
            }
        }

        public async Task<List<CloudMediaModel>> SaveMediaData(AProductDetailUpdateModel aPetDetailUpdateModel)
        {
            var cloudMediaConfig = new CloudMediaConfig
            {
                Folder = "Upload/PetDetail/PetDetail_Image",
                FileName = "Image_PetDetail",
                CloudFiles = aPetDetailUpdateModel.FileData.Select((a, index) => new CloudFileConfig
                {
                    Index = index,
                    FormFile = a,
                }).ToList(),
            };

            return await _cloudMediaService.SaveFileData(cloudMediaConfig);
        }
    }
}
