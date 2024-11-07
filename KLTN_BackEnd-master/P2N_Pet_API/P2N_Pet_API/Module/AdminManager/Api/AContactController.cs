using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2N_Pet_API.Manager.FilterAttr;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AContact;
using P2N_Pet_API.Module.AdminManager.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ManagerAccess]

    public class AContactController : ControllerBase
    {
        private readonly IAContactService _aContactService;

        public AContactController(IAContactService aContactService)
        {
            _aContactService = aContactService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AOSearchContact aOSearchContact)
        {
            try
            {
                var contacts = await _aContactService.GetListContact(aOSearchContact);

                var pagination = await _aContactService.GetListContactPagination(aOSearchContact);

                return Ok(new ObjectResponse
                {
                    result = 1,
                    message = "",
                    content = new
                    {
                        Contacts = contacts,
                        Pagination = pagination
                    }
                });
            }
            catch (Exception e)
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Đã có lỗi xảy ra. Vui lòng thử lại.",
                    content = e.Message.ToString()
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailContact(ulong Id)
        {
            var contact = await _aContactService.GetContactDetail(Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Contact = contact
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(AContactCreateModel aContactCreateModel)
        {
            if (string.IsNullOrEmpty(aContactCreateModel.Name))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên liên hệ."
                });
            }

            if (string.IsNullOrEmpty(aContactCreateModel.Email))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền email liên hệ."
                });
            }

            if (string.IsNullOrEmpty(aContactCreateModel.Phone))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền số điện thoại liên hệ."
                });
            }

            if (string.IsNullOrEmpty(aContactCreateModel.Subject))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền chủ đề liên hệ."
                });
            }

            var dateNow = Utils.DateNow();

            var contactEntity = await _aContactService.CreateContact(dateNow, aContactCreateModel);

            var contact = await _aContactService.GetContactDetail(contactEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Contact = contact
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(AContactUpdateModel aContactUpdateModel)
        {
            if (string.IsNullOrEmpty(aContactUpdateModel.Name))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền tên liên hệ."
                });
            }

            if (string.IsNullOrEmpty(aContactUpdateModel.Email))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền email liên hệ."
                });
            }

            if (string.IsNullOrEmpty(aContactUpdateModel.Phone))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền số điện thoại liên hệ."
                });
            }

            if (string.IsNullOrEmpty(aContactUpdateModel.Subject))
            {
                return Ok(new ObjectResponse
                {
                    result = 0,
                    message = "Vui lòng điền chủ đề liên hệ."
                });
            }

            var contactEntity = await _aContactService.UpdateContact(aContactUpdateModel);

            var contact = await _aContactService.GetContactDetail(contactEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Contact = contact
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact(ulong Id)
        {
            var contactEntity = await _aContactService.DeleteContact(Id);

            var contact = await _aContactService.GetContactDetail(contactEntity.Id);

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    Contact = contact
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetCountContact()
        {
            var countContact = await _aContactService.GetCountContact();

            return Ok(new ObjectResponse
            {
                result = 1,
                message = "",
                content = new
                {
                    CountContact = countContact
                }
            });
        }
    }
}
