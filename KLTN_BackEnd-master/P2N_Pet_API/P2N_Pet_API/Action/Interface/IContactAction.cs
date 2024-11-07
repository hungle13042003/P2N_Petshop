using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action.Interface
{
    public interface IContactAction
    {
        Task<Contact> Create(DateTime dateNow, ContactCreateModel contactCreateModel);
        Task SendEmailContact(ContactModel contact);
    }
}
