using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class AColorAction : IAColorAction
    {
        private readonly PetShopContext _petShopContext;

        public AColorAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Color> Create(ForceInfo forceInfo, AColorCreateModel aColorCreateModel)
        {
            var color = new Color
            {
                Title = aColorCreateModel.Title.Trim(),
                Status = aColorCreateModel.Status,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Colors.Add(color);

            await _petShopContext.SaveChangesAsync();

            return color;
        }

        public async Task<Color> Update(ForceInfo forceInfo, AColorUpdateModel aColorUpdateModel)
        {
            var color = _petShopContext.Colors.Where(a => a.Id == aColorUpdateModel.Id).FirstOrDefault();

            color.Title = aColorUpdateModel.Title.Trim();
            color.Status = aColorUpdateModel.Status;
            color.Updateuser = forceInfo.UserId;
            color.Updatedate = forceInfo.DateNow;

            _petShopContext.Colors.Update(color);
            await _petShopContext.SaveChangesAsync();

            return color;
        }

        public async Task<Color> Delete(ForceInfo forceInfo, ulong Id)
        {
            var color = _petShopContext.Colors.Where(a => a.Id == Id).FirstOrDefault();

            color.Status = 190;
            color.Updateuser = forceInfo.UserId;
            color.Updatedate = forceInfo.DateNow;

            _petShopContext.Colors.Update(color);
            await _petShopContext.SaveChangesAsync();

            return color;
        }
    }
}
