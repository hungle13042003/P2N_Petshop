using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Contact;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactAction _contactAction;

        public ContactService(IContactAction contactAction)
        {
            _contactAction = contactAction;
        }

        public async Task<Contact> CreateContact(DateTime dateNow, ContactCreateModel contactCreateModel)
        {
            return await _contactAction.Create(dateNow, contactCreateModel);
        }

        public async Task SendEmailContact(ContactModel contact)
        {
            await _contactAction.SendEmailContact(contact);
        }
    }
}
