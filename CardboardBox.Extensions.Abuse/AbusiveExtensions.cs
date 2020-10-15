using System.Collections.Generic;

namespace CardboardBox.Extensions
{
	public static class AbusiveExtensions
	{
		public static AbusableCollection<T> Abuse<T>(this IEnumerable<T> source)
		{
			return new AbusableCollection<T>(source);
		}

		public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int size)
		{
			var current = new List<T>();
			foreach(var item in source)
			{
				current.Add(item);
				if (current.Count == size)
				{
					yield return current;
					current = new List<T>();
				}
			}
		}

		public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source, int times)
		{
			for(var i = 0; i < times; i++)
			{
				foreach (var item in source)
					yield return item;
			}
		}
	}
}
