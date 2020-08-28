using System.Collections;
using System.Collections.Generic;

namespace AnagramFinder
{
	public class SortedList<T> : ICollection<T>
	{
		public List<T> Items { get; set; } = new List<T>();
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return Items.GetEnumerator();
		}

		public void Add(T item)
		{
			Items.Add(item);
			Items.Sort();
		}

		public void Clear()
		{
			Items.Clear();
		}

		public bool Contains(T item)
		{
			return Items.Contains(item);
		}

		public void CopyTo(T[] array, int index)
		{
			Items.CopyTo(array, index);
		}

		public bool Remove(T item)
		{
			return Items.Remove(item);
		}

		public int Count
		{
			get { return Items.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public void AddRange(List<T> toList)
		{
			Items.AddRange(toList);
			Items.Sort();
		}
	}
}
