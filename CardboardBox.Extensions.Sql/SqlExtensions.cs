using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace CardboardBox.Extensions
{
	public static class SqlExtensions
	{
		public static IServiceCollection AddSql<T>(this IServiceCollection services, ISqlConfig config) where T: class, ISqlService
		{
			return services
				.AddSingleton(config)
				.AddTransient<ISqlService, T>();
		}

		public static IServiceCollection AddSql<T>(this IServiceCollection services, IConfiguration config, string section = null) where T : class, ISqlService
		{
			var sqlConfig = config.Get<SqlConfig>(section);
			return services
				.AddSql<T>(sqlConfig);
		}

		public static IServiceCollection AddSql<T>(this IServiceCollection services, string connectionString, CommandType commandType = CommandType.StoredProcedure, int timeout = 60) where T : class, ISqlService
		{
			return services.AddSql<T>(new SqlConfig
			{
				ConnectionString = connectionString,
				SqlCommandType = commandType,
				Timeout = timeout
			});
		}
	}
}
