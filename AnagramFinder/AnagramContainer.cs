using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramFinder
{
	public class AnagramContainer
	{
		public AnagramContainer()
		{
		}

		public AnagramContainer(IEnumerable<string> items)
		{
			Anagrams.AddRange(items);
		}

		public List<string> Anagrams { get; set; } = new List<string>();

		public void Print()
		{
			var b = new StringBuilder();
			foreach (var a in (IEnumerable<object>)Anagrams)
				b.AppendFormat("{0} ", a);

			Console.WriteLine(b.ToString());
		}
	}
}
