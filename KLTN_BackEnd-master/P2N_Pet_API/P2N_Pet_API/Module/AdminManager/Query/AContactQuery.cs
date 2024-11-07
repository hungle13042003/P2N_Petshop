using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AContact;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class AContactQuery : IAContactQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public AContactQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<AContactListModel>> QueryGetListContact(AOSearchContact aOSearchContact)
        {
            aOSearchContact.Limit = string.IsNullOrEmpty(aOSearchContact.Limit) ? "10" : aOSearchContact.Limit;
            aOSearchContact.CurrentPage = string.IsNullOrEmpty(aOSearchContact.CurrentPage) ? "0" : aOSearchContact.CurrentPage;
            aOSearchContact.Status = string.IsNullOrEmpty(aOSearchContact.Status) ? "0" : aOSearchContact.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchContact.Name))
            {
                condition += @" and c.name like @Name ";
            }

            if (!string.IsNullOrEmpty(aOSearchContact.Email))
            {
                condition += @" and c.email like @Email ";
            }

            if (!string.IsNullOrEmpty(aOSearchContact.Phone))
            {
                condition += @" and c.phone like @Phone ";
            }

            if (!string.IsNullOrEmpty(aOSearchContact.Subject))
            {
                condition += @" and c.subject like @Subject ";
            }

            if (Convert.ToInt32(aOSearchContact.Status) > 0)
            {
                condition += @" and c.status = @Status ";
            }

            var query =
                @"select c.Id, ifnull(c.Name, N'') Name, ifnull(c.Email, '') Email, ifnull(c.Phone, '') Phone, 
                        ifnull(c.Subject, N'') Subject, ifnull(c.Content, N'') Content, 
                        case 
                            when(c.status = 10) 
                            then 'Chờ phản hồi' 
                            else 'Đã phản hồi' 
                        end StatusText, 
                        c.CreateDate  
                from contact c 
	                left join status st on st.id = c.status 
                where c.status != @StatusExcep " + condition + @" 
                order by c.status asc, c.id desc, c.name collate utf8_unicode_ci asc  
                limit " + Convert.ToInt32(aOSearchContact.Limit) * Convert.ToInt32(aOSearchContact.CurrentPage) + @", " + aOSearchContact.Limit + @";";

            return await _p2NPetDapper.QueryAsync<AContactListModel>(query, new
            {
                StatusExcep = 190,
                Name = "%" + aOSearchContact.Name + "%",
                Email = "%" + aOSearchContact.Email + "%",
                Phone = "%" + aOSearchContact.Phone + "%",
                Subject = "%" + aOSearchContact.Subject + "%",
                Status = aOSearchContact.Status
            });
        }

        public async Task<int> QueryCountListContact(AOSearchContact aOSearchContact)
        {
            aOSearchContact.Limit = string.IsNullOrEmpty(aOSearchContact.Limit) ? "10" : aOSearchContact.Limit;
            aOSearchContact.CurrentPage = string.IsNullOrEmpty(aOSearchContact.CurrentPage) ? "0" : aOSearchContact.CurrentPage;
            aOSearchContact.Status = string.IsNullOrEmpty(aOSearchContact.Status) ? "0" : aOSearchContact.Status;

            var condition = @"";

            if (!string.IsNullOrEmpty(aOSearchContact.Name))
            {
                condition += @" and c.name like @Name ";
            }

            if (!string.IsNullOrEmpty(aOSearchContact.Email))
            {
                condition += @" and c.email like @Email ";
            }

            if (!string.IsNullOrEmpty(aOSearchContact.Phone))
            {
                condition += @" and c.phone like @Phone ";
            }

            if (!string.IsNullOrEmpty(aOSearchContact.Subject))
            {
                condition += @" and c.subject like @Subject ";
            }

            if (Convert.ToInt32(aOSearchContact.Status) > 0)
            {
                condition += @" and c.status = @Status ";
            }

            var query =
                @"select count(1) 
                from contact c 
	                left join status st on st.id = c.status 
                where c.status != @StatusExcep " + condition + @" ;";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                Name = "%" + aOSearchContact.Name + "%",
                Email = "%" + aOSearchContact.Email + "%",
                Phone = "%" + aOSearchContact.Phone + "%",
                Subject = "%" + aOSearchContact.Subject + "%",
                Status = aOSearchContact.Status
            });
        }

        public async Task<AContactModel> QueryGetContactDetail(ulong Id)
        {
            var query = @"select c.Id, ifnull(c.Name, N'') Name, ifnull(c.Email, '') Email, ifnull(c.Phone, '') Phone, 
                        ifnull(c.Subject, N'') Subject, ifnull(c.Content, N'') Content, c.Status 
                        from contact c 
                        where c.status != @Status and c.id = @Id;";

            return await _p2NPetDapper.QuerySingleAsync<AContactModel>(query, new
            {
                Status = 190,
                Id
            });
        }

        public async Task<int> QueryCountContact()
        {
            var query =
                @"select count(1) 
                from contact
                where status = @Status;";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                Status = 10
            });
        }
    }
}
