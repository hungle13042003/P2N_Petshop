using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ABreed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class ABreedAction : IABreedAction
    {
        private readonly PetShopContext _petShopContext;

        public ABreedAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Breed> Create(ForceInfo forceInfo, ABreedCreateModel aBreedCreateModel)
        {
            var breed = new Breed
            {
                Name = aBreedCreateModel.Name.Trim(),
                Breedid = aBreedCreateModel.BreedId,
                Status = aBreedCreateModel.Status,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Breeds.Add(breed);

            await _petShopContext.SaveChangesAsync();

            return breed;
        }

        public async Task<Breed> Update(ForceInfo forceInfo, ABreedUpdateModel aBreedUpdateModel)
        {
            var breed = _petShopContext.Breeds.Where(a => a.Id == aBreedUpdateModel.Id).FirstOrDefault();

            breed.Name = aBreedUpdateModel.Name.Trim();
            breed.Breedid = aBreedUpdateModel.BreedId;
            breed.Status = aBreedUpdateModel.Status;
            breed.Updateuser = forceInfo.UserId;
            breed.Updatedate = forceInfo.DateNow;

            _petShopContext.Breeds.Update(breed);
            await _petShopContext.SaveChangesAsync();

            return breed;
        }

        public async Task<Breed> Delete(ForceInfo forceInfo, ulong Id)
        {
            var breed = _petShopContext.Breeds.Where(a => a.Id == Id).FirstOrDefault();

            breed.Status = 190;
            breed.Updateuser = forceInfo.UserId;
            breed.Updatedate = forceInfo.DateNow;

            _petShopContext.Breeds.Update(breed);
            await _petShopContext.SaveChangesAsync();

            return breed;
        }
    }
}
