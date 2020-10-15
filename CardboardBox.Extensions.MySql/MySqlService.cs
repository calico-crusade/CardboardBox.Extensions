using MySql.Data.MySqlClient;
using System.Data;

namespace CardboardBox.Extensions
{
	public class MySqlService : SqlService
	{
		public MySqlService(ISqlConfig config) : base(config) { }

		public override IDbConnection Connection()
		{
			return new MySqlConnection(Config.ConnectionString);
		}
	}
}
