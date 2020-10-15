using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;

namespace CardboardBox.Extensions
{
	public static class Extensions
	{
		public static IServiceCollection AddSql(this IServiceCollection services, SqlEngineType type, IConfiguration config, string section = null)
		{
			switch (type)
			{
				case SqlEngineType.MySql:
					return services.AddMySql(config, section);
				case SqlEngineType.Sqlite:
					return services.AddSqlite(config, section);
				case SqlEngineType.SqlServer:
					return services.AddSqlServer(config, section);
			}

			throw new NotSupportedException($"{type} is not a supported type.");
		}

		public static IServiceCollection AddSql(this IServiceCollection services, SqlEngineType type, ISqlConfig config)
		{
			switch (type)
			{
				case SqlEngineType.MySql:
					return services.AddMySql(config);
				case SqlEngineType.Sqlite:
					return services.AddSqlite(config);
				case SqlEngineType.SqlServer:
					return services.AddSqlServer(config);
			}

			throw new NotSupportedException($"{type} is not a supported type.");
		}

		public static IServiceCollection AddSql(this IServiceCollection services, SqlEngineType type, string connectionString, CommandType commandType = CommandType.StoredProcedure, int timeout = 60)
		{
			switch (type)
			{
				case SqlEngineType.MySql:
					return services.AddMySql(connectionString, commandType, timeout);
				case SqlEngineType.Sqlite:
					return services.AddSqlite(connectionString, commandType, timeout);
				case SqlEngineType.SqlServer:
					return services.AddSqlServer(connectionString, commandType, timeout);
			}

			throw new NotSupportedException($"{type} is not a supported type.");
		}
	}
}
