using System.Data;
using System.Data.SqlClient;

namespace CardboardBox.Extensions
{
	public class SqlServerService : SqlService
	{
		public SqlServerService(ISqlConfig config) : base(config) { }

		public override IDbConnection Connection()
		{
			return new SqlConnection(Config.ConnectionString);
		}
	}
}
