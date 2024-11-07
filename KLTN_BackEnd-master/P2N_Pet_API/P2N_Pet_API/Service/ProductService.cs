using P2N_Pet_API.Models.Product;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductQuery _productQuery;
        private readonly IPaginationService _paginationService;

        public ProductService(IProductQuery productQuery,
            IPaginationService paginationService)
        {
            _productQuery = productQuery;
            _paginationService = paginationService;
        }
        public async Task<ProductDetailModel> GetDetailProduct(ulong productDetailId, ulong brandId)
        {
            var productDetail = await _productQuery.QueryDetailProduct(productDetailId, brandId);

            if (productDetail != null)
            {
                var productId = productDetail.ProductId;

                ProductDetailConditionModel productDetailCondition = new ProductDetailConditionModel();

                productDetailCondition.ProductId = productId;
                productDetailCondition.ColorId = productDetail.ColorId;
                productDetailCondition.AgeId = productDetail.AgeId;
                productDetailCondition.SizeId = productDetail.SizeId;
                productDetailCondition.ProductDetailId = productDetail.ProductDetailId;

                var productImages = _productQuery.QueryProductImages(productDetailId);

                var taskSize = _productQuery.QueryListSizeOfProduct(productDetailCondition);
                var taskColor = _productQuery.QueryListColorOfProduct(productDetailCondition);
                var taskAge = _productQuery.QueryListAgeOfProduct(productDetailCondition);
                var taskSex = _productQuery.QueryListSexOfProduct(productDetailCondition);
                var taskBrand = _productQuery.QueryListBrandOfProduct(productDetailCondition);

                await Task.WhenAll(productImages, taskSize, taskColor, taskAge, taskSex, taskBrand);

                productDetail.productImages = productImages.Result;

                productDetail.productSizes = taskSize.Result;
                productDetail.productColors = taskColor.Result;
                productDetail.productAges = taskAge.Result;
                productDetail.productSexes = taskSex.Result;
                productDetail.productBrands = taskBrand.Result;

                productDetail.NumBrand = productDetail.productBrands.Count();
            }

            return productDetail;
        }

        public async Task<List<ProductListModel>> GetListProduct(OSearchProductModel oSearch)
        {
            return await _productQuery.QueryListProduct(oSearch); 
        }

        public async Task<PaginationModel> GetListProductPagination(OSearchProductModel oSearch)
        {
            var count = await _productQuery.QueryCountListProduct(oSearch);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(oSearch.CurrentPage),
                oSearch.CurrentDate, Convert.ToInt32(oSearch.Limit));

            return pagination;
        }

        public async Task<ProductDetailModel> GetMultiProductDetail(ProductDetailConditionModel productDetailCondition)
        {
            var productDetail = await _productQuery.QueryMultiProductDetail(productDetailCondition);

            if (productDetail != null)
            {
                //var productId = productDetail.ProductId;
                productDetailCondition.ProductDetailId = productDetail.ProductDetailId;

                var productImages = _productQuery.QueryProductImages(productDetail.ProductDetailId);

                var taskColor = _productQuery.QueryListColorOfProduct(productDetailCondition);
                var taskAge = _productQuery.QueryListAgeOfProduct(productDetailCondition);
                var taskSize = _productQuery.QueryListSizeOfProduct(productDetailCondition);
                var taskSex = _productQuery.QueryListSexOfProduct(productDetailCondition);
                var taskBrand = _productQuery.QueryListBrandOfProduct(productDetailCondition);

                await Task.WhenAll(productImages, taskSize, taskColor, taskAge, taskSex, taskBrand);

                productDetail.productImages = productImages.Result;

                productDetail.productColors = taskColor.Result;
                productDetail.productAges = taskAge.Result;
                productDetail.productSizes = taskSize.Result;
                productDetail.productSexes = taskSex.Result;
                productDetail.productBrands = taskBrand.Result;

                productDetail.NumBrand = productDetail.productBrands.Count();
            }

            return productDetail;
        }
    }
}
