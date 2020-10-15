using System.Data;
using System.Data.SQLite;

namespace CardboardBox.Extensions
{
	public class SqliteService : SqlService
	{
		public SqliteService(ISqlConfig config) : base(config) { }

		public override IDbConnection Connection()
		{
			return new SQLiteConnection(Config.ConnectionString);
		}
	}
}
