using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CardboardBox.Extensions.Tests
{
	using static CardboardBox.Extensions.Abuse.AbusiveExtensions;

	[TestClass]
	public class AbusiveTests
	{
		private readonly string[] _names = new[]
		{
			"John",
			"Joe",
			"Julie",
			"Jill",
			"Jane",
			"Johnas",
			"Jeshaiah",
			"James",
			"Janis"
		};

		[TestMethod]
		public void CollectionAddition_Element()
		{
			var abusable = _names.Abuse() + "Jerome";

			Assert.IsTrue(abusable.Contains("Jerome"));
		}

		[TestMethod]
		public void CollectionAddition_Collection()
		{
			var abusable = _names.Abuse() + new[] { "Jerome", "Jeremy" };

			Assert.IsTrue(
				abusable.Contains("Jerome") &&
				abusable.Contains("Jeremy"));
		}

		[TestMethod]
		public void CollectionAddition_Abusable()
		{
			var abusable = _names.Abuse() + new[] { "Jerome", "Jeremy" }.Abuse();

			Assert.IsTrue(
				abusable.Contains("Jerome") &&
				abusable.Contains("Jeremy"));
		}

		[TestMethod]
		public void CollectionAddition_UniaryPlus()
		{
			var abusable = +_names.Abuse();
			Assert.AreEqual("John", abusable);
		}

		[TestMethod]
		public void CollectionAddition_Increment()
		{
			var abusable = _names.Abuse() + "John";

			var distinct = ++abusable;

			Assert.AreEqual(_names.Length, distinct.Count());
		}

		[TestMethod]
		public void CollectionSubtraction_Predicate()
		{
			var abusable = _names.Abuse() - (t => t == "Jill");

			Assert.IsFalse(abusable.Contains("Jill"));
		}

		[TestMethod]
		public void CollectionSubtraction_Element()
		{
			var abusable = _names.Abuse() - "Johnas";

			Assert.IsFalse(abusable.Contains("Johnas"));
		}

		[TestMethod]
		public void CollectionSubtraction_Collection()
		{
			var abusable = _names.Abuse() - new[] { "Johnas", "Janis" };

			Assert.IsTrue(
				!abusable.Contains("Johnas") &&
				!abusable.Contains("Janis"));
		}

		[TestMethod]
		public void CollectionSubtraction_Abusable()
		{
			var abusable = _names.Abuse() - new[] { "Johnas", "Janis" }.Abuse();

			Assert.IsTrue(
				!abusable.Contains("Johnas") &&
				!abusable.Contains("Janis"));
		}

		[TestMethod]
		public void CollectionSubtraction_UniaryMinus()
		{
			var abusable = -_names.Abuse();
			Assert.AreEqual("Janis", abusable);
		}

		[TestMethod]
		public void CollectionSubtraction_Decrement()
		{
			var abusable = _names.Abuse();

			var distinct = --abusable;

			Assert.AreEqual("Janis", distinct.First());
		}

		[TestMethod]
		public void CollectionDivision_Grouping()
		{
			var abusable = (_names.Abuse() / (t => t.Last())).ToArray();

			Assert.IsTrue(abusable.Any(t => t.Key == 's'));
		}

		[TestMethod]
		public void CollectionDivision_Batching()
		{
			var abusable = _names.Abuse() / 4;

			Assert.IsTrue(abusable.Count() == 2);
		}

		[TestMethod]
		public void CollectionDivision_Modulous()
		{
			var abusable = _names.Abuse() % 4;

			Assert.IsTrue(abusable.First() == "Janis");
		}
	}
}
