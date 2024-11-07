using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.ACustomer;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class ACustomerQuery : IACustomerQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public ACustomerQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<ACustomerListModel>> QueryGetListCustomer(AOSearchCustomer aOSearchCustomer)
        {
            aOSearchCustomer.Limit = string.IsNullOrEmpty(aOSearchCustomer.Limit) ? "10" : aOSearchCustomer.Limit;
            aOSearchCustomer.CurrentDate = string.IsNullOrEmpty(aOSearchCustomer.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchCustomer.CurrentDate;
            aOSearchCustomer.CurrentPage = string.IsNullOrEmpty(aOSearchCustomer.CurrentPage) ? "0" : aOSearchCustomer.CurrentPage;
            aOSearchCustomer.Status = string.IsNullOrEmpty(aOSearchCustomer.Status) ? "0" : aOSearchCustomer.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchCustomer.Name))
            {
                condition += @" and c.Name like @Name ";
            }

            if (!string.IsNullOrEmpty(aOSearchCustomer.Phone))
            {
                condition += @" and c.Phone like @Phone ";
            }

            if (!string.IsNullOrEmpty(aOSearchCustomer.Email))
            {
                condition += @" and c.Email like @Email ";
            }

            if (Convert.ToInt32(aOSearchCustomer.Status) > 0)
            {
                condition += @" and c.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchCustomer.CurrentDate))
            {
                condition += @" and c.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select c.Id, o.Id OrderId, ifnull(u.Name, N'') UserName, ifnull(c.Name, N'') Name, c.Birthday, ifnull(c.Address, N'') Address, 
                    ifnull(c.Phone, '') Phone, ifnull(c.Email, '') Email, ifnull(st.Title, N'') StatusText, 
	                ifnull(uc.Name, N'') CreateUserName, c.CreateDate, ifnull(up.Name, N'') UpdateUserName, c.UpdateDate
                from customer c 
                    left join users u on u.id = c.userid 
                    left join `order` o on o.customerid = c.id 
	                left join status st on st.id = c.status
                    left join users uc on uc.id = c.createuser
                    left join users up on up.id = c.updateuser
                where c.status != @StatusExcep " + condition + @" 
                order by c.status asc, c.id desc, c.name collate utf8_unicode_ci asc  
                limit " + Convert.ToInt32(aOSearchCustomer.Limit) * Convert.ToInt32(aOSearchCustomer.CurrentPage) + @", " + aOSearchCustomer.Limit + @";";

            return await _p2NPetDapper.QueryAsync<ACustomerListModel>(query, new
            {
                StatusExcep = 190,
                Name = "%" + aOSearchCustomer.Name + "%",
                Phone = "%" + aOSearchCustomer.Phone + "%",
                Email = "%" + aOSearchCustomer.Email + "%",
                Status = aOSearchCustomer.Status,
                CurrentDate = aOSearchCustomer.CurrentDate
            });
        }

        public async Task<int> QueryCountListCustomer(AOSearchCustomer aOSearchCustomer)
        {
            aOSearchCustomer.Limit = string.IsNullOrEmpty(aOSearchCustomer.Limit) ? "10" : aOSearchCustomer.Limit;
            aOSearchCustomer.CurrentDate = string.IsNullOrEmpty(aOSearchCustomer.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchCustomer.CurrentDate;
            aOSearchCustomer.CurrentPage = string.IsNullOrEmpty(aOSearchCustomer.CurrentPage) ? "0" : aOSearchCustomer.CurrentPage;
            aOSearchCustomer.Status = string.IsNullOrEmpty(aOSearchCustomer.Status) ? "0" : aOSearchCustomer.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchCustomer.Name))
            {
                condition += @" and c.Name like @Name ";
            }

            if (!string.IsNullOrEmpty(aOSearchCustomer.Phone))
            {
                condition += @" and c.Phone like @Phone ";
            }

            if (!string.IsNullOrEmpty(aOSearchCustomer.Email))
            {
                condition += @" and c.Email like @Email ";
            }

            if (Convert.ToInt32(aOSearchCustomer.Status) > 0)
            {
                condition += @" and c.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchCustomer.CurrentDate))
            {
                condition += @" and c.createdate <= cast(@CurrentDate as DateTime) ";
            }

            var query =
                @"select count(1) 
                from customer c 
                    left join users u on u.id = c.userid 
                    left join `order` o on o.customerid = c.id 
	                left join status st on st.id = c.status
                    left join users uc on uc.id = c.createuser
                    left join users up on up.id = c.updateuser
                where c.status != @StatusExcep " + condition + @" ;";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                Name = "%" + aOSearchCustomer.Name + "%",
                Phone = "%" + aOSearchCustomer.Phone + "%",
                Email = "%" + aOSearchCustomer.Email + "%",
                Status = aOSearchCustomer.Status,
                CurrentDate = aOSearchCustomer.CurrentDate
            });
        }

        public async Task<ACustomerModel> QueryGetCustomerDetail(ulong Id)
        {
            var query = @"select c.Id, c.UserId, ifnull(c.Name, N'') Name, c.Birthday, ifnull(c.Address, N'') Address, 
                    ifnull(c.Phone, '') Phone, ifnull(c.Email, '') Email, c.Status 
                        from customer c 
                        where c.status != @Status and c.id = @Id;";

            return await _p2NPetDapper.QuerySingleAsync<ACustomerModel>(query, new
            {
                Status = 190,
                Id
            });
        }
    }
}
