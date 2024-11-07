using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AProduct;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class AProductService : IAProductService
    {
        private readonly IAProductQuery _aProductQuery;
        private readonly IAProductAction _aProductAction;
        private readonly IPaginationService _paginationService;

        public AProductService(IAProductQuery aProductQuery,
            IAProductAction aProductAction,
            IPaginationService paginationService)
        {
            _aProductQuery = aProductQuery;
            _aProductAction = aProductAction;
            _paginationService = paginationService;
        }

        public async Task<List<AProductListModel>> GetListProduct(AOSearchProduct aOSearchProduct)
        {
            return await _aProductQuery.QueryGetListProduct(aOSearchProduct);
        }

        public async Task<PaginationModel> GetListProductPagination(AOSearchProduct aOSearchProduct)
        {
            var count = await _aProductQuery.QueryCountListProduct(aOSearchProduct);

            var pagination = await _paginationService.BuildPagination(count, Convert.ToInt32(aOSearchProduct.CurrentPage),
                aOSearchProduct.CurrentDate, Convert.ToInt32(aOSearchProduct.Limit));

            return pagination;
        }

        public async Task<AProductModel> GetProductDetail(ulong Id)
        {
            return await _aProductQuery.QueryGetProductDetail(Id);
        }

        public async Task<Product> CreateProduct(ForceInfo forceInfo, AProductCreateModel aProductCreateModel)
        {
            return await _aProductAction.Create(forceInfo, aProductCreateModel);
        }

        public async Task<Product> UpdateProduct(ForceInfo forceInfo, AProductUpdateModel aProductUpdateModel)
        {
            return await _aProductAction.Update(forceInfo, aProductUpdateModel);
        }

        public async Task<Product> DeleteProduct(ForceInfo forceInfo, ulong Id)
        {
            return await _aProductAction.Delete(forceInfo, Id);
        }
    }
}
