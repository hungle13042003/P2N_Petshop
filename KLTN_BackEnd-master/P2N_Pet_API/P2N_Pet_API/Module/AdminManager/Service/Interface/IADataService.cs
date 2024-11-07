using P2N_Pet_API.Module.AdminManager.Models.AData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Service.Interface
{
    public interface IADataService
    {
        Task<List<AStatusSelectionModel>> GetNormalStatusSelection();
        Task<List<AAgeSelectionModel>> GetNormalAgeSelection();
        Task<List<AColorSelectionModel>> GetNormalColorSelection();
        Task<List<ASizeSelectionModel>> GetNormalSizeSelection();
        Task<List<ASexSelectionModel>> GetNormalSexSelection();
        Task<List<ABreedDefaultSelectionModel>> GetNormalBreedDefaultSelection();
        Task<List<ABreedSelectionModel>> GetNormalBreedSelection();
        Task<List<ASupplierSelectionModel>> GetNormalSupplierSelection();
        Task<List<ABreedSelectionModel>> GetNormalBreedProductDetailSelection(ulong supplierid);
        Task<List<ASupplierSelectionModel>> GetNormalSupplierProductDetailSelection(ulong breedid);
        Task<List<AStatusDetailSelectionModel>> GetNormalStatusDetailSelection();
        Task<List<AProductSelectionModel>> GetNormalProductDetailSelection();
        Task<List<ABrandSelectionModel>> GetNormalBrandSelection();
        Task<List<ATypeProductSelection>> GetNormalTypeProductSelection();
        Task<List<ACategorySelectionModel>> GetNormalCategoryRootSelection();
        Task<List<ACategorySelectionModel>> GetNormalCategorySelection();
        Task<List<ASupplierSelectionModel>> GetSupplierProductDetailSelection(ulong categoryid);
        Task<List<ACategorySelectionModel>> GetNormalCategoryProductDetailSelection(ulong supplierid);
        Task<List<ATypeNewsSelectionModel>> GetNormalTypeNewsSelection();
    }
}
