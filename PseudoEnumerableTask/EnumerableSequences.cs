using System;
using System.Collections.Generic;
using PseudoEnumerableTask.Interfaces;

namespace PseudoEnumerableTask
{
	public static class EnumerableSequences
	{
		/// <summary>
		/// Filters a sequence based on a predicate.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="predicate">A <see cref="IPredicate{T}"/> to test each element of a sequence for a condition.</param>
		/// <returns>An sequence of elements from the source sequence that satisfy the condition.</returns>
		/// <exception cref="ArgumentNullException">Thrown when source sequence or predicate is null.</exception>
		public static IEnumerable<TSource> Filter<TSource>(this TSource[] source, IPredicate<TSource> predicate)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				throw new ArgumentException("source is empty");
			}

			List<TSource> newSource = new List<TSource>();

			foreach (TSource s in source)
			{
				if (predicate.Verify(s))
				{
					newSource.Add(s);
				}
			}

			return newSource.ToArray();
		}

		/// <summary>
		/// Transforms each element of source sequence from one type to another type by some rule.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
		/// <typeparam name="TResult">The type of the elements of result sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="transformer">A <see cref="ITransformer{TSource,TResult}"/> that defines the rule of transformation.</param>
		/// <returns>A sequence, each element of which is transformed.</returns>
		/// <exception cref="ArgumentNullException">Thrown when sequence or transformer is null.</exception>
		public static IEnumerable<TResult> Transform<TSource, TResult>(this TSource[] source, ITransformer<TSource, TResult> transformer)
		{
			if (source is null || transformer is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				throw new ArgumentException("source is empty");
			}

			List<TResult> result = new List<TResult>();

			foreach (TSource s in source)
			{
				result.Add(transformer.Transform(s));
			}

			return result.ToArray();
		}

		/// <summary>
		/// Sorts the elements of a sequence in ascending order by using a specified comparer.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
		/// <returns>An ordered by comparer sequence.</returns>
		/// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
		/// <exception cref="ArgumentNullException">Thrown when comparer is null, and one or more elements
		/// of the sequence do not implement the <see cref="IComparable{T}"/>  interface.
		///</exception>
		public static IEnumerable<TSource> SortBy<TSource>(this TSource[] source, IComparer<TSource> comparer)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				throw new ArgumentException("source is empty");
			}

			Array.Sort(source, comparer);

			foreach (TSource s in source)
			{
				yield return s;
			}
		}

		/// <summary>
		/// Filters the elements of source sequence based on a specified type.
		/// </summary>
		/// <typeparam name="TResult">Type selector to return.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <returns>A sequence that contains the elements from source sequence that have type TResult.</returns>
		/// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
		public static IEnumerable<TResult> TypeOf<TResult>(this object[] source)
		{
			if (source is null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (source.Length == 0)
			{
				throw new ArgumentException("source is empty");
			}

			List<TResult> newList = new List<TResult>();

			for (int i = 0; i < source.Length; i++)
			{
				if (source[i] is TResult)
				{
					newList.Add((TResult)source[i]);
				}
			}

			return newList.ToArray();
		}

		/// <summary>
		/// Inverts the order of the elements in a sequence.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of sequence.</typeparam>
		/// <param name="source">A sequence of elements to reverse.</param>
		/// <exception cref="ArgumentNullException">Thrown when sequence is null.</exception>
		public static IEnumerable<TSource> Reverse<TSource>(this TSource[] source)
		{
			Array.Reverse(source);
			return source;
		}

		/// <summary>
		/// Swaps two objects.
		/// </summary>
		/// <typeparam name="T">The type of parameters.</typeparam>
		/// <param name="left">First object.</param>
		/// <param name="right">Second object.</param>
		internal static void Swap<T>(ref T left, ref T right)
		{
			T temp = left;
			left = right;
			right = temp;
		}
	}
}