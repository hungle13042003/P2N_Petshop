using P2N_Pet_API.Module.AdminManager.Models.AData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query.Interface
{
    public interface IADataQuery
    {
        Task<List<AStatusSelectionModel>> QueryNormalStatusSelection();
        Task<List<AAgeSelectionModel>> QueryNormalAgeSelection();
        Task<List<AColorSelectionModel>> QueryNormalColorSelection();
        Task<List<ASizeSelectionModel>> QueryNormalSizeSelection();
        Task<List<ASexSelectionModel>> QueryNormalSexSelection();
        Task<List<ABreedDefaultSelectionModel>> QueryNormalBreedDefaultSelection();
        Task<List<ABreedSelectionModel>> QueryNormalBreedSelection();
        Task<List<ASupplierSelectionModel>> QueryNormalSupplierSelection();
        Task<List<ABreedSelectionModel>> QueryNormalBreedProductDetailSelection(ulong supplierid);
        Task<List<ASupplierSelectionModel>> QueryNormalSupplierProductDetailSelection(ulong breedid);
        Task<List<AStatusDetailSelectionModel>> QueryNormalStatusDetailSelection();
        Task<List<AProductSelectionModel>> QueryNormalProductDetailSelection();
        Task<List<ABrandSelectionModel>> QueryNormalBrandSelection();
        Task<List<ATypeProductSelection>> QueryNormalTypeProduct();
        Task<List<ACategorySelectionModel>> QueryNormalCategoryRootSelection();
        Task<List<ACategorySelectionModel>> QueryNormalCategorySelection();
        Task<List<ACategorySelectionModel>> QueryCategorySelectionSupplier(ulong supplierid);
        Task<List<ASupplierSelectionModel>> QuerySupplierProductDetailSelection(ulong categoryid);
        Task<List<ATypeNewsSelectionModel>> QueryTypeNewsSelection();
    }
}
