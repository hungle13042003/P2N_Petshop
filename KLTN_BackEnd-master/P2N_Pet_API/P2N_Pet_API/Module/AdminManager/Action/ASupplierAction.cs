using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ASupplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class ASupplierAction : IASupplierAction 
    {
        private readonly PetShopContext _petShopContext;

        public ASupplierAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Supplier> Create(ForceInfo forceInfo, ASupplierCreateModel aSupplierCreateModel)
        {
            var supplier = new Supplier
            {
                Name = aSupplierCreateModel.Name.Trim(),
                Address = aSupplierCreateModel.Address.Trim(),
                Phone = aSupplierCreateModel.Phone.Trim(),
                Email = aSupplierCreateModel.Email.Trim(),
                Status = aSupplierCreateModel.Status,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Suppliers.Add(supplier);

            await _petShopContext.SaveChangesAsync();

            return supplier;
        }

        public async Task<Supplier> Update(ForceInfo forceInfo, ASupplierUpdateModel aSupplierUpdateModel)
        {
            var supplier = _petShopContext.Suppliers.Where(a => a.Id == aSupplierUpdateModel.Id).FirstOrDefault();

            supplier.Name = aSupplierUpdateModel.Name.Trim();
            supplier.Address = aSupplierUpdateModel.Address.Trim();
            supplier.Phone = aSupplierUpdateModel.Phone.Trim();
            supplier.Email = aSupplierUpdateModel.Email.Trim();
            supplier.Status = aSupplierUpdateModel.Status;
            supplier.Updateuser = forceInfo.UserId;
            supplier.Updatedate = forceInfo.DateNow;

            _petShopContext.Suppliers.Update(supplier);
            await _petShopContext.SaveChangesAsync();

            return supplier;
        }

        public async Task<Supplier> Delete(ForceInfo forceInfo, ulong Id)
        {
            var supplier = _petShopContext.Suppliers.Where(a => a.Id == Id).FirstOrDefault();

            supplier.Status = 190;
            supplier.Updateuser = forceInfo.UserId;
            supplier.Updatedate = forceInfo.DateNow;

            _petShopContext.Suppliers.Update(supplier);
            await _petShopContext.SaveChangesAsync();

            return supplier;
        }
    }
}
