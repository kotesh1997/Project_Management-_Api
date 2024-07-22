using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;


namespace CMS.Service
{
    [EnableCors("CorsPolicy")]
    public class Dapperr : IDapper
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "DefaultConnection";

        public Dapperr(IConfiguration config)
        {
            _config = config;
        }
        public void Dispose()
        {

        }
        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
            };
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                return db.Query<T>(sp, parms, commandType: commandType).ToList();
            };
        }
        //public Tuple<List<T1>, List<T2>> GetMultipleResult<T1,T2>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        //{
        //    using (IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring)))
        //    {
        //        var reader = db.QueryMultiple(sp, parms, commandType: commandType);
        //        var list1 = reader.Read<T1>().ToList();
        //        var list2 = reader.Read<T2>().ToList();
        //        return Tuple.Create(list1, list2);
        //    };

        //}
        public Tuple<T, List<T1>, List<T2>, List<T3>, List<T4>> GetMultipleResult<T, T1, T2, T3, T4>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var reader = db.QueryMultiple(sp, parms, commandType: commandType);
                var data = db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
                var list1 = reader.Read<T1>().ToList();
                var list2 = reader.Read<T2>().ToList();
                var list3 = reader.Read<T3>().ToList();
                var list4 = reader.Read<T4>().ToList();

                return Tuple.Create(data, list1, list2, list3, list4);
            };

        }

        public Tuple<List<T1>, List<T2>, List<T3>> GetMultipleResult1<T1, T2, T3>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var reader = db.QueryMultiple(sp, parms, commandType: commandType);
                var list1 = reader.Read<T1>().ToList();
                var list2 = reader.Read<T2>().ToList();
                var list3 = reader.Read<T3>().ToList();

                return Tuple.Create(list1, list2, list3);
            };

        }
        public string Execute1(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            string returnValue = string.Empty; // Initialize as an empty string
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    var tran = db.BeginTransaction();
                    try
                    {
                        db.Execute(sp, parms, commandType: commandType, transaction: tran);

                        // Retrieve the output parameter
                        returnValue = parms.Get<string>("result");
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw; // Re-throw the original exception
                    }
                }
                catch (Exception ex)
                {
                    throw; // Re-throw the original exception
                }
            }

            return returnValue;
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int returnValue;
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var tran = db.BeginTransaction();
                try
                {
                    db.Query(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    returnValue = parms.Get<int>("result");
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return returnValue;
        }
        public T QuerySingleAsync<T>(string query, DynamicParameters parameters = null, CommandType cmdType = CommandType.Text)
        {
            try
            {
                IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                if (db.State == ConnectionState.Closed)
                    db.Open();

                return db.QuerySingleAsync<T>(query, parameters, commandType: cmdType).Result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Tuple<List<T1>, List<T2>, List<T3>, List<T4>, List<T5>, List<T6>, List<T7>> GetMultipleResultVendor<T1, T2, T3, T4, T5, T6, T7>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                var reader = db.QueryMultiple(sp, parms, commandType: commandType);
                //var data = db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
                var list1 = reader.Read<T1>().ToList();
                var list2 = reader.Read<T2>().ToList();
                var list3 = reader.Read<T3>().ToList();
                var list4 = reader.Read<T4>().ToList();
                var list5 = reader.Read<T5>().ToList();
                var list6 = reader.Read<T6>().ToList();
                var list7 = reader.Read<T7>().ToList();


                return Tuple.Create(list1, list2, list3, list4, list5, list6, list7); //data,
            };



        }
        public dynamic ExecuteDB(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            var returnValue="";
            IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var tran = db.BeginTransaction();
                try
                {
                    db.Query(sp, parms, commandType: commandType, transaction: tran).ToString();
                    returnValue = parms.Get<string>("result");
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return returnValue;
        }
        public List<T> Getall<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                return db.Query<T>(sp, parms, commandType: commandType).ToList();
            }
        }

        public List<T> GetAll<T>(string v, CommandType commandType)
        {
            throw new NotImplementedException();
        }
    }
}

