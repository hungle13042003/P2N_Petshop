using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.AContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class AContactAction : IAContactAction
    {
        private readonly PetShopContext _petShopContext;

        public AContactAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Contact> Create(DateTime dateNow, AContactCreateModel aContactCreateModel)
        {
            var contact = new Contact
            {
                Name = aContactCreateModel.Name.Trim(),
                Email = aContactCreateModel.Email.Trim(),
                Phone = aContactCreateModel.Phone.Trim(),
                Subject = aContactCreateModel.Subject.Trim(),
                Content = aContactCreateModel.Content.Trim(),
                Status = aContactCreateModel.Status,
                Createdate = dateNow
            };

            _petShopContext.Contacts.Add(contact);

            await _petShopContext.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> Update(AContactUpdateModel aContactUpdateModel)
        {
            var contact = _petShopContext.Contacts.Where(a => a.Id == aContactUpdateModel.Id).FirstOrDefault();

            contact.Name = aContactUpdateModel.Name.Trim();
            contact.Email = aContactUpdateModel.Email.Trim();
            contact.Phone = aContactUpdateModel.Phone.Trim();
            contact.Subject = aContactUpdateModel.Subject.Trim();
            contact.Content = aContactUpdateModel.Content.Trim();
            contact.Status = aContactUpdateModel.Status;

            _petShopContext.Contacts.Update(contact);
            await _petShopContext.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> Delete(ulong Id)
        {
            var contact = _petShopContext.Contacts.Where(a => a.Id == Id).FirstOrDefault();

            contact.Status = 190;

            _petShopContext.Contacts.Update(contact);
            await _petShopContext.SaveChangesAsync();

            return contact;
        }
    }
}
