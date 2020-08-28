using System;
using System.Linq;

namespace AnagramFinder
{
	public class Program
	{
		public static void Main()
		{
			var input = "I saw a spot on a post that was labeled 'opts'. That didn't really make any sense because the post should have said \"tops\".";
			input = RemovePunctuation(input);

			var anagrams = new AnagramFinderV1().Parse(input);
			foreach (var set in anagrams)
				set.Print();

			Console.ReadKey();
		}

		private static string RemovePunctuation(string input)
		{
			return new string(input.ToCharArray().Where(c => !Char.IsPunctuation(c)).ToArray());
		}
	}
}
