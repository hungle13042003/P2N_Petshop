using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.UtilsService.Interface
{
    public interface IP2NPetDapper
    {
        DbConnection GetDbconnection();

        T QuerySingle<T>(string sp, object parms = null);

        List<T> Query<T>(string sp, object parms = null);

        Task<T> QuerySingleAsync<T>(string sp, object parms = null);

        Task<List<T>> QueryAsync<T>(string sp, object parms = null);

        int Execute(string sp, object parms = null);

        T Insert<T>(string sp, object parms = null);

        T Update<T>(string sp, object parms = null);
    }
}
