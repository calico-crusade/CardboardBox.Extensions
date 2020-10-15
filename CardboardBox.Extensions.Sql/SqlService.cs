using Dapper;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CardboardBox.Extensions
{
    public interface ISqlService
	{
        Task<T[]> Get<T>(string query, object parameter = null, CommandType? type = null, IDbTransaction transaction = null);
        Task<T> Fetch<T>(string query, object parameter = null, CommandType? type = null, IDbTransaction transaction = null);
        Task<bool> Execute(string query, object parameter = null, CommandType? type = null, IDbTransaction transaction = null);
        Task<int> ExecuteWithReturnValue(string query, object parameter = null, CommandType? type = null, IDbTransaction transaction = null);
    }

    public abstract class SqlService : ISqlService
    {
        public readonly ISqlConfig Config;

        public SqlService(ISqlConfig config)
        {
            Config = config;
        }

        public abstract IDbConnection Connection();

        public virtual async Task<T[]> Get<T>(string query, object parameter = null, CommandType? type = null, IDbTransaction transaction = null)
        {
            if (type == null)
                type = Config.SqlCommandType;

            using (var con = Connection())
            {
                con.Open();

                return (await con.QueryAsync<T>
                (
                    sql: query,
                    param: parameter,
                    commandTimeout: Config.Timeout,
                    commandType: type,
                    transaction: transaction
                )).ToArray();
            }
        }

        public virtual async Task<T> Fetch<T>(string query, object parameter = null, CommandType? type = null, IDbTransaction transaction = null)
        {
            if (type == null)
                type = Config.SqlCommandType;

            using (var con = Connection())
            {
                con.Open();

                return await con.QueryFirstAsync<T>
                (
                    sql: query,
                    param: parameter,
                    commandTimeout: Config.Timeout,
                    commandType: type,
                    transaction: transaction
                );
            }
        }

        public virtual async Task<bool> Execute(string query, object parameter = null, CommandType? type = null, IDbTransaction transaction = null)
        {
            if (type == null)
                type = Config.SqlCommandType;

            using (var con = Connection())
            {
                con.Open();

                var results = await con.ExecuteAsync
                (
                    sql: query,
                    param: parameter,
                    commandTimeout: Config.Timeout,
                    commandType: type,
                    transaction: transaction
                );
                return results > 0;
            }
        }

        public virtual async Task<int> ExecuteWithReturnValue(string query, object parameter = null, CommandType? type = null, IDbTransaction transaction = null)
        {
            if (type == null)
                type = Config.SqlCommandType;

            var dyn = new DynamicParameters(parameter);
            dyn.Add
            (
                name: "@RetValue",
                dbType: DbType.Int32,
                direction: ParameterDirection.ReturnValue
            );

            using (var con = Connection())
            {
                con.Open();

                await con.ExecuteAsync
                (
                    sql: query,
                    param: dyn,
                    commandTimeout: Config.Timeout,
                    commandType: type,
                    transaction: transaction
                );

                return dyn.Get<int>("@RetValue");
            }
        }
    }
}
