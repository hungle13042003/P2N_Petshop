using P2N_Pet_API.Module.AdminManager.Models.AData;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service
{
    public class ADataService : IADataService
    {
        private readonly IADataQuery _aDataQuery;

        public ADataService(IADataQuery aDataQuery)
        {
            _aDataQuery = aDataQuery;
        }

        public async Task<List<AStatusSelectionModel>> GetNormalStatusSelection()
        {
            return await _aDataQuery.QueryNormalStatusSelection();
        }

        public async Task<List<AAgeSelectionModel>> GetNormalAgeSelection()
        {
            return await _aDataQuery.QueryNormalAgeSelection();
        }

        public async Task<List<AColorSelectionModel>> GetNormalColorSelection()
        {
            return await _aDataQuery.QueryNormalColorSelection();
        }

        public async Task<List<ASizeSelectionModel>> GetNormalSizeSelection()
        {
            return await _aDataQuery.QueryNormalSizeSelection();
        }
        public async Task<List<ASexSelectionModel>> GetNormalSexSelection()
        {
            return await _aDataQuery.QueryNormalSexSelection();
        }

        public async Task<List<ABreedDefaultSelectionModel>> GetNormalBreedDefaultSelection()
        {
            return await _aDataQuery.QueryNormalBreedDefaultSelection();
        }

        public async Task<List<ABreedSelectionModel>> GetNormalBreedSelection()
        {
            return await _aDataQuery.QueryNormalBreedSelection();
        }

        public async Task<List<ASupplierSelectionModel>> GetNormalSupplierSelection()
        {
            return await _aDataQuery.QueryNormalSupplierSelection();
        }

        public async Task<List<ABreedSelectionModel>> GetNormalBreedProductDetailSelection(ulong supplierid)
        {
            return await _aDataQuery.QueryNormalBreedProductDetailSelection(supplierid);
        }

        public async Task<List<ASupplierSelectionModel>> GetNormalSupplierProductDetailSelection(ulong breedid)
        {
            return await _aDataQuery.QueryNormalSupplierProductDetailSelection(breedid);
        }

        public async Task<List<AStatusDetailSelectionModel>> GetNormalStatusDetailSelection()
        {
            return await _aDataQuery.QueryNormalStatusDetailSelection();
        }

        public async Task<List<AProductSelectionModel>> GetNormalProductDetailSelection()
        {
            return await _aDataQuery.QueryNormalProductDetailSelection();
        }

        public async Task<List<ABrandSelectionModel>> GetNormalBrandSelection()
        {
            return await _aDataQuery.QueryNormalBrandSelection();
        }

        public async Task<List<ATypeProductSelection>> GetNormalTypeProductSelection()
        {
            return await _aDataQuery.QueryNormalTypeProduct();
        }

        public async Task<List<ACategorySelectionModel>> GetNormalCategoryRootSelection()
        {
            return await _aDataQuery.QueryNormalCategoryRootSelection();
        }

        public async Task<List<ACategorySelectionModel>> GetNormalCategorySelection()
        {
            return await _aDataQuery.QueryNormalCategorySelection();
        }

        public async Task<List<ASupplierSelectionModel>> GetSupplierProductDetailSelection(ulong categoryid)
        {
            return await _aDataQuery.QuerySupplierProductDetailSelection(categoryid);
        }

        public async Task<List<ACategorySelectionModel>> GetNormalCategoryProductDetailSelection(ulong supplierid)
        {
            return await _aDataQuery.QueryCategorySelectionSupplier(supplierid);
        }

        public async Task<List<ATypeNewsSelectionModel>> GetNormalTypeNewsSelection()
        {
            return await _aDataQuery.QueryTypeNewsSelection();
        }
    }
}
