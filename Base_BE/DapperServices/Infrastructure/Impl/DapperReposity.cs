#pragma warning disable

using Dapper;
using System.Data;

namespace DapperServices.DataProcess
{
    public class DapperReposity : IDapperReposity
    {
        private readonly IDbConnection _connection;
        public DapperReposity(IDbConnection connection)
        {
            _connection = connection;
        }

        public IDbConnection GetDbConnection()
        {
            return _connection;
        }

        public int Execute(string sql, object? param = null, IDbTransaction? trans = null, CommandType? commandType = null)
        {
            return _connection.Execute(sql, param, trans, commandType: commandType);
        }

        public async Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? trans = null, CommandType? commandType = null)
        {
            return await _connection.ExecuteAsync(sql, param, trans, commandType: commandType);
        }

        public T ExecuteScalar<T>(string sql, object? param = null, IDbTransaction? trans = null, CommandType? commandType = null)
        {
            return _connection.ExecuteScalar<T>(sql, param, trans, commandType: commandType);
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object? param = null, IDbTransaction? trans = null, CommandType? commandType = null)
        {
            return await _connection.ExecuteScalarAsync<T>(sql, param, trans, commandType: commandType);
        }

        public IEnumerable<T> Query<T>(string sql, object? param = null, IDbTransaction? trans = null, CommandType? commandType = null)
        {
            return _connection.Query<T>(sql, param, trans, commandType: commandType);
        }

        public List<object> QueryMultiple(string? sql, object? parameters, IDbTransaction? trans = null, CommandType? commandType = null, params Func<SqlMapper.GridReader, object>[] readerFuncs)
        {
            var returnResults = new List<object>();
            var gridReader = _connection.QueryMultiple(sql, parameters, trans, commandTimeout: 10000, commandType: commandType);
            foreach (var readerFunc in readerFuncs)
            {
                var obj = readerFunc(gridReader);
                returnResults.Add(obj);
            }
            return returnResults;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? trans = null, CommandType? commandType = null)
        {
            return await _connection.QueryAsync<T>(sql, param, trans, commandType: commandType);
        }

        public T QuerySingleOrDefault<T>(string sql, object? param = null, IDbTransaction? trans = null, CommandType? commandType = null)
        {
            return _connection.QuerySingleOrDefault<T>(sql, param, trans, commandType: commandType);
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? trans = null, CommandType? commandType = null)
        {
            return await _connection.QuerySingleOrDefaultAsync<T>(sql, param, trans, commandType: commandType);
        }

        public int ExecuteScalarTransactionSPMulti(List<string> listSpName, List<object> listparam)
        {
            int queryResult = 0;

            using (var trans = _connection.BeginTransaction())
            {
                for (int i = 0; i < listSpName.Count; i++)
                {
                    string spName = listSpName[i];
                    object? param = listparam.Count > i ? listparam[i] : null;
                    queryResult = (int)_connection.ExecuteScalar(
                        spName,
                        param,
                        trans,
                        null,
                        CommandType.StoredProcedure
                        );
                    if (queryResult < 1)
                    {
                        break;
                    }
                }

                if (queryResult > 0)
                    trans.Commit();
                else
                    trans.Rollback();
            }

            return queryResult;
        }

        public int ExecuteScalarTransactionQueryMulti(List<string> listQuery, List<object> listparam)
        {
            int queryResult = 0;

            using (var trans = _connection.BeginTransaction())
            {
                for (int i = 0; i < listQuery.Count; i++)
                {
                    string query = listQuery[i];
                    object? param = listparam.Count > i ? listparam[i] : null;
                    queryResult = (int)_connection.ExecuteScalar(
                        query,
                        param,
                        trans,
                        null,
                        CommandType.Text
                        );
                    if (queryResult < 1)
                    {
                        break;
                    }
                }

                if (queryResult > 0)
                    trans.Commit();
                else
                    trans.Rollback();
            }

            return queryResult;
        }

        public async Task<int> ExecuteScalarTransactionSPMultiAsync(List<string> listSpName, List<object> listparam)
        {
            int queryResult = 0;

            using (var trans = _connection.BeginTransaction())
            {
                for (int i = 0; i < listSpName.Count; i++)
                {
                    string spName = listSpName[i];
                    object? param = listparam.Count > i ? listparam[i] : null;
                    queryResult = await _connection.ExecuteScalarAsync<int>(
                        spName,
                        param,
                        null,
                        null,
                        CommandType.StoredProcedure
                        );
                    if (queryResult < 1)
                    {
                        break;
                    }
                }

                if (queryResult > 0)
                    trans.Commit();
                else
                    trans.Rollback();
            }

            return queryResult;
        }

        public async Task<int> ExecuteScalarTransactionQueryMultiAsync(List<string> listQuery, List<object> listparam)
        {
            int queryResult = 0;

            using (var trans = _connection.BeginTransaction())
            {
                for (int i = 0; i < listQuery.Count; i++)
                {
                    string query = listQuery[i];
                    object? param = listparam.Count > i ? listparam[i] : null;
                    queryResult = await _connection.ExecuteScalarAsync<int>(
                        query,
                        param,
                        null,
                        null,
                        CommandType.Text
                        );
                    if (queryResult < 1)
                    {
                        break;
                    }
                }

                if (queryResult > 0)
                    trans.Commit();
                else
                    trans.Rollback();
            }

            return queryResult;
        }

        public async Task<IEnumerable<T>> ExecuteData<T>(string storeName , object param  , CommandType? commandType = null)
        {
            var res = await _connection.QueryAsync<T>(
                storeName,
                param,
                commandType: CommandType.StoredProcedure
            );
            return res; 
        }
        public async Task<DataTable> ExecuteToDataTable(string sql, object? param = null)
        {
            var dataReader = _connection.ExecuteReaderAsync(sql, param, null,null,commandType:CommandType.StoredProcedure);
            var dataTable = new DataTable();
            dataTable.Load((IDataReader)dataReader.Result);
            return dataTable;

        }
    }
}
