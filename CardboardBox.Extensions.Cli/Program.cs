using System;

namespace CardboardBox.Extensions.Cli
{
	public class User
	{
		private static int _id = 0;

		public int Id { get; set; }
		public string Username { get; set; }

		public User() { }

		public User(string username)
		{
			Id = _id++;
			Username = username;
		}

		public override string ToString()
		{
			return $"{Username} ({Id})";
		}
	}

	public class Message
	{
		private static int _id = 0;

		public int Id { get; set; }
		public int UserId { get; set; }
		public string Content { get; set; }

		public Message() { }

		public Message(int userId, string content)
		{
			Id = _id++;
			UserId = userId;
			Content = content;
		}

		public Message(User user, string content) : this(user.Id, content) { }

		public override string ToString()
		{
			return $"{UserId}: {Content} ({Id})";
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			var users = new[] { new User("Josh"), new User("Joe"), new User("John"), new User("Josiah"), new User("Jerome") };

			var messages = new[]
			{
				new Message(users[0], "Hello"), new Message(users[1], "world,"), new Message(users[2], "How"), new Message(users[3], "are"), new Message(users[4], "you?"),
				new Message(users[2], "I'm"), new Message(users[3], "being"), new Message(users[1], "abused!!")
			};

			var usrs = users.Abuse();
			var msgs = messages.Abuse();

			var firstUser = +usrs;
			Console.WriteLine("First User: " + firstUser);
			var lastUser = -usrs;
			Console.WriteLine("Last User: " + lastUser);

			for (var i = 0; i < 5; i++)
			{
				var rndUser = +~usrs;
				Console.WriteLine($"Random User #{i}: {rndUser}");
			}

			var grpdUsrMsgs = msgs / (t => t.UserId);
			foreach(var grp in grpdUsrMsgs)
			{
				var usr = +(usrs - (t => t.Id == grp.Key));
				Console.WriteLine($"User: {usr}");
				foreach(var msg in grp)
				{
					Console.WriteLine($"\t{msg}");
				}
			}


			for (var i = 0; i < 10; i++)
			{
				var cursedAf = -((~(usrs * i + usrs * 3)) >> 2 << 2);
				Console.WriteLine(cursedAf);
			}
		}
	}
}
