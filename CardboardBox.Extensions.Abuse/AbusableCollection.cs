/*
 
	This extension to the IEnumerable interface is heavily inspired by https://github.com/jskeet/DemoCode
	What jskeets talks about abusing C#! They're very good!
 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CardboardBox.Extensions
{
	public class AbusableCollection<T> : IEnumerable<T>
	{
		public readonly IEnumerable<T> Source;

		public AbusableCollection(IEnumerable<T> source)
		{
			Source = source;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return Source.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Source.GetEnumerator();
		}

		#region Collection Addition
		public static AbusableCollection<T> operator +(AbusableCollection<T> collection, T element)
		{
			return collection + new[] { element };
		}

		public static AbusableCollection<T> operator +(AbusableCollection<T> collection, AbusableCollection<T> appendage)
		{
			return collection + appendage.Source;
		}

		public static AbusableCollection<T> operator +(AbusableCollection<T> collection, IEnumerable<T> appendage)
		{
			return new AbusableCollection<T>(collection.Source.Concat(appendage));
		}

		public static T operator +(AbusableCollection<T> collection)
		{
			return collection.FirstOrDefault();
		}

		public static AbusableCollection<T> operator ++(AbusableCollection<T> collection)
		{
			return collection.Distinct().Abuse();
		}
		#endregion

		#region Collection Subtraction
		public static AbusableCollection<T> operator -(AbusableCollection<T> collection, Func<T, bool> predicate)
		{
			return new AbusableCollection<T>(collection.Source.Where(t => !predicate(t)));
		}

		public static AbusableCollection<T> operator -(AbusableCollection<T> collection, T element)
		{
			return collection - new[] { element };
		}

		public static AbusableCollection<T> operator -(AbusableCollection<T> collection, AbusableCollection<T> subpendage)
		{
			return collection - subpendage.Source;
		}

		public static AbusableCollection<T> operator -(AbusableCollection<T> collection, IEnumerable<T> subpendage)
		{
			return new AbusableCollection<T>(collection.Source.Except(subpendage));
		}

		public static T operator -(AbusableCollection<T> collection)
		{
			return collection.LastOrDefault();
		}

		public static AbusableCollection<T> operator --(AbusableCollection<T> collection)
		{
			return collection.Reverse().Abuse();
		}
		#endregion

		#region Collection Division
		public static AbusableCollection<IGrouping<dynamic, T>> operator /(AbusableCollection<T> collect, Func<T, dynamic> grouper)
		{
			return new AbusableCollection<IGrouping<dynamic, T>>(collect.Source.GroupBy(grouper));
		}

		public static AbusableCollection<IEnumerable<T>> operator /(AbusableCollection<T> collect, int size)
		{
			return collect.Batch(size).Abuse();
		}

		public static AbusableCollection<T> operator %(AbusableCollection<T> collect, int size)
		{
			var current = new List<T>();
			foreach(var item in collect)
			{
				current.Add(item);
				if (current.Count == size)
					current.Clear();
			}

			return current.Abuse();
		}
		#endregion

		#region Collection Multiplication
		public static AbusableCollection<T> operator *(AbusableCollection<T> collect, int times)
		{
			return collect.Repeat(times).Abuse();
		}

		public static AbusableCollection<T> operator *(AbusableCollection<T> collect, IEnumerable<T> uni)
		{
			return collect.Union(uni).Abuse();
		}

		public static AbusableCollection<T> operator *(AbusableCollection<T> collect, T element)
		{
			return collect * new[] { element };
		}
		#endregion

		#region

		public static AbusableCollection<T> operator ~(AbusableCollection<T> collect)
		{
			var rnd = new Random();
			return collect.OrderBy(t => rnd.Next()).Abuse();
		}

		public static AbusableCollection<dynamic> operator |(AbusableCollection<T> collect, Func<T, dynamic> change)
		{
			return collect.Select(change).Abuse();
		}

		public static AbusableCollection<T> operator <<(AbusableCollection<T> collect, int take)
		{
			return collect.Take(take).Abuse();
		}

		public static AbusableCollection<T> operator >>(AbusableCollection<T> collect, int skip)
		{
			return collect.Skip(skip).Abuse();
		}

		public static AbusableCollection<T> operator &(AbusableCollection<T> collect, IEnumerable<T> data)
		{
			return collect.Intersect(data).Abuse();
		}

		#endregion
	}
}
