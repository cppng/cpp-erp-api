using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Erp.Helper.Configuration;

namespace Erp.Persistence.Dapper
{
    public class DapperService : IDapperService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly AppSettings _appSettings;
        public DapperService(IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
            _connectionString = _configuration.GetConnectionString("ErpDbConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
        public void Dispose()
        {

        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<T>(sp, parms, commandType: commandType, commandTimeout: 120000).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<T>(sp, parms, commandType: commandType, commandTimeout: 120000).ToList();
        }

        public List<T> GetAllSQL<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<T>(sp, parms, commandType: commandType, commandTimeout: 120000).ToList();
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_connectionString);
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            IDbConnection db = new SqlConnection(_connectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                result = db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
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

            return result;
        }

        public T InsertTransaction<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            IDbConnection db = new SqlConnection(_connectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
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

            return result;
        }


        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            IDbConnection db = new SqlConnection(_connectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
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

            return result;
        }

    }
}
