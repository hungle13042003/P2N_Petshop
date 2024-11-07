using P2N_Pet_API.Database;
using P2N_Pet_API.Database.PetShopModels;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Action.Interface;
using P2N_Pet_API.Module.AdminManager.Models.ACustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Action
{
    public class ACustomerAction : IACustomerAction
    {
        private readonly PetShopContext _petShopContext;

        public ACustomerAction(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

        public async Task<Customer> Create(ForceInfo forceInfo, ACustomerCreateModel aCustomerCreateModel)
        {
            var customer = new Customer
            {
                Userid = forceInfo.UserId,
                Name = aCustomerCreateModel.Name.Trim(),
                Birthday = aCustomerCreateModel.Birthday,
                Address = aCustomerCreateModel.Address,
                Phone = aCustomerCreateModel.Phone,
                Email = aCustomerCreateModel.Email,
                Status = aCustomerCreateModel.Status,
                Createuser = forceInfo.UserId,
                Createdate = forceInfo.DateNow,
                Updateuser = forceInfo.UserId,
                Updatedate = forceInfo.DateNow
            };

            _petShopContext.Customers.Add(customer);

            await _petShopContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> Update(ForceInfo forceInfo, ACustomerUpdateModel aCustomerUpdateModel)
        {
            var customer = _petShopContext.Customers.Where(a => a.Id == aCustomerUpdateModel.Id).FirstOrDefault();

            customer.Name = aCustomerUpdateModel.Name.Trim();
            customer.Birthday = aCustomerUpdateModel.Birthday;
            customer.Address = aCustomerUpdateModel.Address;
            customer.Phone = aCustomerUpdateModel.Phone;
            customer.Email = aCustomerUpdateModel.Email;
            customer.Status = aCustomerUpdateModel.Status;
            customer.Updateuser = forceInfo.UserId;
            customer.Updatedate = forceInfo.DateNow;

            _petShopContext.Customers.Update(customer);
            await _petShopContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> Delete(ForceInfo forceInfo, ulong Id)
        {
            var customer = _petShopContext.Customers.Where(a => a.Id == Id).FirstOrDefault();

            customer.Status = 190;
            customer.Updateuser = forceInfo.UserId;
            customer.Updatedate = forceInfo.DateNow;

            _petShopContext.Customers.Update(customer);
            await _petShopContext.SaveChangesAsync();

            return customer;
        }
    }
}
