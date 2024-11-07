using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.CloudMedia;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AProductDetail;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class AProductDetailService : IAProductDetailService
    {
        private readonly PetShopContext _petShopContext;
        private readonly IAProductDetailQuery _aProductDetailQuery;
        private readonly IAProductDetailAction _aProductDetailAction;
        private readonly IPaginationService _paginationService;

        public AProductDetailService(IAProductDetailQuery aProductDetailQuery,
            IAProductDetailAction aProductDetailAction,
            PetShopContext petShopContext,
            IPaginationService paginationService)
        {
            _petShopContext = petShopContext;
            _aProductDetailQuery = aProductDetailQuery;
            _aProductDetailAction = aProductDetailAction;
            _paginationService = paginationService;
        }

        public async Task<List<AProductDetailListModel>> GetListProductDetail(AOSearchProductDetail aOSearchProductDetail)
        {
            return await _aProductDetailQuery.QueryGetListProductDetail(aOSearchProductDetail);
        }

        public async Task<PaginationModel> GetListProductDetailPagination(AOSearchProductDetail aOSearchProductDetail)
        {
            var count = await _aProductDetailQuery.QueryCountListProductDetail(aOSearchProductDetail);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchProductDetail.CurrentPage),
                aOSearchProductDetail.CurrentDate, Convert.ToInt32(aOSearchProductDetail.Limit));

            return pagination;
        }

        public async Task<AProductDetailModel> GetInProductDetail(ulong Id)
        {
            return await _aProductDetailQuery.QueryGetInProductDetail(Id);
        }

        public async Task<Productdetail> CreateProductDetail(ForceInfo forceInfo, AProductDetailCreateModel aProductDetailCreateModel)
        {
            if(aProductDetailCreateModel != null && aProductDetailCreateModel.BreedId != 0 && aProductDetailCreateModel.CategoryId == 0 && aProductDetailCreateModel.SupplierId != 0)
            {
                aProductDetailCreateModel.ProductId = await _aProductDetailQuery.GetProductId(Convert.ToUInt64(aProductDetailCreateModel.BreedId), aProductDetailCreateModel.SupplierId);
            }
            
            if(aProductDetailCreateModel != null && aProductDetailCreateModel.CategoryId != 0 && aProductDetailCreateModel.BreedId == 0)
            {
                aProductDetailCreateModel.ProductId = await _aProductDetailQuery.GetProductIdByCategory(aProductDetailCreateModel.CategoryId, aProductDetailCreateModel.SupplierId);
            }

            if(aProductDetailCreateModel.ProductId == 0)
            {
                return null;
            }

            var productDetail = await _aProductDetailAction.Create(forceInfo, aProductDetailCreateModel);

            if (productDetail != null && aProductDetailCreateModel.FileData != null
                && aProductDetailCreateModel.FileData.Count > 0)
            {
                var productDetailUpdate = new AProductDetailUpdateModel
                {
                    Id = productDetail.Id,
                    ProductId = aProductDetailCreateModel.ProductId,
                    ColorId = aProductDetailCreateModel.ColorId,
                    SizeId = aProductDetailCreateModel.SizeId,
                    AgeId = aProductDetailCreateModel.AgeId,
                    SexId = aProductDetailCreateModel.SexId,
                    StatusDetailId = aProductDetailCreateModel.StatusDetailId,
                    Price = aProductDetailCreateModel.Price,
                    Discount = aProductDetailCreateModel.Discount,
                    Quantity = aProductDetailCreateModel.Quantity,
                    Status = aProductDetailCreateModel.Status,
                    FileData = aProductDetailCreateModel.FileData,
                    ProductBrands = aProductDetailCreateModel.brands,
                    SupplierId = aProductDetailCreateModel.SupplierId,
                    CategoryId = aProductDetailCreateModel.CategoryId
                };

                if (productDetailUpdate.BreedId != 0 && productDetailUpdate.CategoryId == 0)
                {
                    var imageOldIds = await _aProductDetailQuery.QueryListImageOldCreate(productDetailUpdate);

                    if (imageOldIds != null && imageOldIds.Count > 0)
                    {
                        await _aProductDetailAction.UpdateProductDetailImageOld(forceInfo, productDetailUpdate.Id, imageOldIds);
                    }

                    await UpdateProductDetailImage(forceInfo, productDetailUpdate);
                }

                else if( productDetailUpdate.CategoryId != 0 && (productDetailUpdate.BreedId == 0 || productDetailUpdate.BreedId == null))
                {
                    var imageOldIds = await _aProductDetailQuery.QueryListImageOldCategoryCreate(productDetailUpdate);

                    if (imageOldIds != null && imageOldIds.Count > 0)
                    {
                        await _aProductDetailAction.UpdateProductDetailImageOld(forceInfo, productDetailUpdate.Id, imageOldIds);
                    }

                    await UpdateProductDetailCategoryImage(forceInfo, productDetailUpdate);
                }                
            }

            return productDetail;
        }

        public async Task<Productdetail> UpdateProductDetail(ForceInfo forceInfo, AProductDetailUpdateModel aProductDetailUpdateModel)
        {
            if (aProductDetailUpdateModel != null && aProductDetailUpdateModel.BreedId != 0
                && aProductDetailUpdateModel.CategoryId == 0 && aProductDetailUpdateModel.SupplierId != 0)
            {
                aProductDetailUpdateModel.ProductId = await _aProductDetailQuery.GetProductId(Convert.ToUInt64(aProductDetailUpdateModel.BreedId), aProductDetailUpdateModel.SupplierId);
            }

            if( aProductDetailUpdateModel != null && aProductDetailUpdateModel.CategoryId != 0 && (aProductDetailUpdateModel.BreedId == 0 || aProductDetailUpdateModel.BreedId == null))
            {
                aProductDetailUpdateModel.ProductId = await _aProductDetailQuery.GetProductIdByCategory(aProductDetailUpdateModel.CategoryId, aProductDetailUpdateModel.SupplierId);
            }

            if(aProductDetailUpdateModel.ProductId == 0)
            {
                return null;
            }

            var productDetail = await _aProductDetailAction.Update(forceInfo, aProductDetailUpdateModel);

            if (productDetail != null && aProductDetailUpdateModel.FileData != null
                && aProductDetailUpdateModel.FileData.Count > 0)
            {

                if(aProductDetailUpdateModel.BreedId != 0 && aProductDetailUpdateModel.CategoryId == 0)
                {
                    await UpdateProductDetailImage(forceInfo, aProductDetailUpdateModel);
                }
                else if( aProductDetailUpdateModel.CategoryId != 0 && (aProductDetailUpdateModel.BreedId == 0 || aProductDetailUpdateModel.BreedId == null) )
                {
                    await UpdateProductDetailCategoryImage(forceInfo, aProductDetailUpdateModel);
                }                
            }

            return productDetail;
        }

        public async Task<Productdetail> DeleteProductDetail(ForceInfo forceInfo, ulong Id)
        {
            return await _aProductDetailAction.Delete(forceInfo, Id);
        }

        public async Task UpdateProductDetailImage(ForceInfo forceInfo, AProductDetailUpdateModel aProductDetailUpdateModel)
        {
            var idProductDetailDuplicates = await _aProductDetailQuery.QueryListProductDetailDuplicateImage(aProductDetailUpdateModel.ProductId, 
                                                                                            Convert.ToUInt64(aProductDetailUpdateModel.ColorId), 
                                                                                            Convert.ToUInt64(aProductDetailUpdateModel.AgeId));

            if (idProductDetailDuplicates.Count > 0)
            {
                var cloudMedias = await _aProductDetailAction.SaveMediaData(aProductDetailUpdateModel);
                await _aProductDetailAction.UpdateProductDetailImage(forceInfo, aProductDetailUpdateModel, cloudMedias, idProductDetailDuplicates);
            }
        }

        public async Task DeleteProductDetailImage(ForceInfo forceInfo, ulong productImageId)
        {
            var idProductImageForDuplicates = await _aProductDetailQuery.QueryListProductImageForDuplicateImage(productImageId);

            if(idProductImageForDuplicates.Count > 0)
            {
                await _aProductDetailAction.DeleteProductDetailImage(forceInfo, productImageId, idProductImageForDuplicates);
            }
        }

        public async Task UpdateProductDetailCategoryImage(ForceInfo forceInfo, AProductDetailUpdateModel aProductDetailUpdateModel)
        {
            //product trùng nhưng khác size
            var idProductDetailDuplicates = await _aProductDetailQuery.QueryListProductDetailCategoryDuplicateImage(aProductDetailUpdateModel.ProductId);

            if (idProductDetailDuplicates.Count > 0)
            {
                var cloudMedias = await _aProductDetailAction.SaveMediaData(aProductDetailUpdateModel);
                await _aProductDetailAction.UpdateProductDetailImage(forceInfo, aProductDetailUpdateModel, cloudMedias, idProductDetailDuplicates);
            }
        }
    }
}
