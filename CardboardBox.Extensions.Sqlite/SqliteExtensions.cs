using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace CardboardBox.Extensions
{
	public static class SqliteExtensions
	{
		public static IServiceCollection AddSqlite(this IServiceCollection services, IConfiguration config, string section = null)
			=> services.AddSql<SqliteService>(config, section);

		public static IServiceCollection AddSqlite(this IServiceCollection services, ISqlConfig config)
			=> services.AddSql<SqliteService>(config);

		public static IServiceCollection AddSqlite(this IServiceCollection services, string connectionString, CommandType commandType = CommandType.StoredProcedure, int timeout = 60)
			=> services.AddSql<SqliteService>(connectionString, commandType, timeout);
	}
}
