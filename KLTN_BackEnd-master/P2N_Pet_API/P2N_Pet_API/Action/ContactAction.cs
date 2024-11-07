using Microsoft.AspNetCore.Hosting;
using P2N_Pet_API.Action.Interface;
using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.Contact;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Action
{
    [Obsolete]
    public class ContactAction : IContactAction
    {
        private readonly PetShopContext _petShopContext;        
        private readonly IHostingEnvironment _env;
        private readonly IEmailService _emailService;

        public ContactAction(PetShopContext petShopContext,
            IHostingEnvironment env,
            IEmailService emailService)
        {
            _petShopContext = petShopContext;
            _env = env;
            _emailService = emailService;
        }

        public async Task<Contact> Create(DateTime dateNow, ContactCreateModel contactCreateModel)
        {
            var contact = new Contact
            {
                Name = contactCreateModel.Name.Trim(),
                Email = contactCreateModel.Email.Trim(),
                Phone = contactCreateModel.Phone.Trim(),
                Subject = contactCreateModel.Subject.Trim(),
                Content = contactCreateModel.Content.Trim(),
                Status = 10,
                Createdate = dateNow
            };

            _petShopContext.Contacts.Add(contact);

            await _petShopContext.SaveChangesAsync();

            return contact;
        }

        public async Task SendEmailContact(ContactModel contact)
        {
            string content = "";
            string subject = "Thư cảm ơn từ P2N Pet";

            var absoPath = Path.Combine("wwwroot", "Assets", "Template", "Email", "ContactForm.html");
            var pathTemp = Path.Combine(_env.ContentRootPath, absoPath);

            content = File.ReadAllText(pathTemp);

            content = content.Replace("{{name}}", contact.Name);
            content = content.Replace("{{phone}}", contact.Phone);
            content = content.Replace("{{email}}", contact.Email);
            content = content.Replace("{{subject}}", contact.Subject);
            content = content.Replace("{{content}}", contact.Content);

            _emailService.Send(contact.Email.Trim(), subject, content);
        }
    }
}
