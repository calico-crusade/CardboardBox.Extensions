using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace CardboardBox.Extensions
{
	public static class MySqlExtensions
	{
		public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration config, string section = null)
			=> services.AddSql<MySqlService>(config, section);

		public static IServiceCollection AddMySql(this IServiceCollection services, ISqlConfig config)
			=> services.AddSql<MySqlService>(config);

		public static IServiceCollection AddMySql(this IServiceCollection services, string connectionString, CommandType commandType = CommandType.StoredProcedure, int timeout = 60)
			=> services.AddSql<MySqlService>(connectionString, commandType, timeout);
	}
}
