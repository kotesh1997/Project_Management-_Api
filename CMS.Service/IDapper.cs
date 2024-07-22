using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace CMS.Service
{
    public interface IDapper : IDisposable
    {
        DbConnection GetDbconnection();
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        //Tuple<List<T1>, List<T2>> GetMultipleResult<T1,T2>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Tuple<T, List<T1>, List<T2>, List<T3>, List<T4>> GetMultipleResult<T, T1, T2, T3, T4>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Tuple<List<T1>, List<T2>, List<T3>> GetMultipleResult1<T1, T2, T3>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        string Execute1(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T QuerySingleAsync<T>(string sqlQuery, DynamicParameters dynParams, CommandType cmdType);

        Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>, List<T7>> GetMultipleResultVendor<T1, T2, T3, T4, T5, T6, T7>
            (string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);


        dynamic ExecuteDB(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string v, CommandType commandType);
        List<T> Getall<T>(string v, DynamicParameters dbParam, CommandType commandType);
    }
}
