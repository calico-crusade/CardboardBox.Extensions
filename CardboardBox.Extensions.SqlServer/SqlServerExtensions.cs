using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace CardboardBox.Extensions
{
	public static class SqlServerExtensions
	{
		public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration config, string section = null)
			=> services.AddSql<SqlServerService>(config, section);

		public static IServiceCollection AddSqlServer(this IServiceCollection services, ISqlConfig config)
			=> services.AddSql<SqlServerService>(config);

		public static IServiceCollection AddSqlServer(this IServiceCollection services, string connectionString, CommandType commandType = CommandType.StoredProcedure, int timeout = 60)
			=> services.AddSql<SqlServerService>(connectionString, commandType, timeout);
	}
}
