using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Persistence.Dapper;

public interface IDapperService
{
    IDbConnection CreateConnection();
    void Dispose();
    int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
    List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    List<T> GetAllSQL<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
    DbConnection GetDbconnection();
    T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    T InsertTransaction<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
}
