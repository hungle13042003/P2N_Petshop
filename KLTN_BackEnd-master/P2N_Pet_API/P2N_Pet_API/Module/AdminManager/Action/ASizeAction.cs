using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ASize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class ASizeAction : IASizeAction
    {
        private readonly PetShopContext _petShopContext;

        public ASizeAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Size> Create(ForceInfo forceInfo, ASizeCreateModel aSizeCreateModel)
        {
            var size = new Size
            {
                Title = aSizeCreateModel.Title.Trim(),
                Orderview = aSizeCreateModel.OrderView,
                Status = aSizeCreateModel.Status,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Sizes.Add(size);

            await _petShopContext.SaveChangesAsync();

            return size;
        }

        public async Task<Size> Update(ForceInfo forceInfo, ASizeUpdateModel aSizeUpdateModel)
        {
            var size = _petShopContext.Sizes.Where(a => a.Id == aSizeUpdateModel.Id).FirstOrDefault();

            size.Title = aSizeUpdateModel.Title.Trim();
            size.Orderview = aSizeUpdateModel.OrderView;
            size.Status = aSizeUpdateModel.Status;
            size.Updateuser = forceInfo.UserId;
            size.Updatedate = forceInfo.DateNow;

            _petShopContext.Sizes.Update(size);
            await _petShopContext.SaveChangesAsync();

            return size;
        }

        public async Task<Size> Delete(ForceInfo forceInfo, ulong Id)
        {
            var size = _petShopContext.Sizes.Where(a => a.Id == Id).FirstOrDefault();

            size.Status = 190;
            size.Updateuser = forceInfo.UserId;
            size.Updatedate = forceInfo.DateNow;

            _petShopContext.Sizes.Update(size);
            await _petShopContext.SaveChangesAsync();

            return size;
        }
    }
}
