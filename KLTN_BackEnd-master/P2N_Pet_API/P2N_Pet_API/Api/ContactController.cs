using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Models.Contact;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactCreateModel contactCreateModel)
        {
            if (string.IsNullOrEmpty(contactCreateModel.Name))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên liên hệ."
                });
            }

            if (string.IsNullOrEmpty(contactCreateModel.Email))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền email liên hệ."
                });
            }

            if (string.IsNullOrEmpty(contactCreateModel.Phone))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền số điện thoại liên hệ."
                });
            }

            if (string.IsNullOrEmpty(contactCreateModel.Subject))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền chủ đề liên hệ."
                });
            }

            var dateNow = Utils.DateNow();

            var contactEntity = await _contactService.CreateContact(dateNow, contactCreateModel);

            var contact = new ContactModel
            {
                Name = contactEntity.Name,
                Email = contactEntity.Email,
                Phone = contactEntity.Phone,
                Subject = contactEntity.Subject,
                Content = contactEntity.Content
            };

            await _contactService.SendEmailContact(contact);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Contact = contactEntity
                }
            });
        }
    }
}
