using System.Data;

namespace CardboardBox.Extensions
{
	public interface ISqlConfig
	{
		string ConnectionString { get; }
		int Timeout { get; }
		CommandType SqlCommandType { get; }
	}

	public class SqlConfig : ISqlConfig
	{
		public string ConnectionString { get; set; }

		public int Timeout { get; set; }

		public CommandType SqlCommandType { get; set; }
	}
}
