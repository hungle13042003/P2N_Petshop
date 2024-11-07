using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AAge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class AAgeAction : IAAgeAction
    {
        private readonly PetShopContext _petShopContext;

        public AAgeAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Age> Create(ForceInfo forceInfo, AAgeCreateModel aAgeCreateModel)
        {
            var age = new Age
            {
                Title = aAgeCreateModel.Title.Trim(),
                Orderview = aAgeCreateModel.OrderView,
                Status = aAgeCreateModel.Status,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Ages.Add(age);

            await _petShopContext.SaveChangesAsync();

            return age;
        }

        public async Task<Age> Update(ForceInfo forceInfo, AAgeUpdateModel aAgeUpdateModel)
        {
            var age = _petShopContext.Ages.Where(a => a.Id == aAgeUpdateModel.Id).FirstOrDefault();

            age.Title = aAgeUpdateModel.Title.Trim();
            age.Orderview = aAgeUpdateModel.OrderView;
            age.Status = aAgeUpdateModel.Status;
            age.Updateuser = forceInfo.UserId;
            age.Updatedate = forceInfo.DateNow;

            _petShopContext.Ages.Update(age);
            await _petShopContext.SaveChangesAsync();

            return age;
        }

        public async Task<Age> Delete(ForceInfo forceInfo, ulong Id)
        {
            var age = _petShopContext.Ages.Where(a => a.Id == Id).FirstOrDefault();

            age.Status = 190;
            age.Updateuser = forceInfo.UserId;
            age.Updatedate = forceInfo.DateNow;

            _petShopContext.Ages.Update(age);
            await _petShopContext.SaveChangesAsync();

            return age;
        }
    }
}
