using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnagramFinder
{
	/// <summary>
	/// Given a paragraph of text, find all sets of anagrams contained within.
	/// Store set of anagrams in alphabetical in-order and in a container.
	/// </summary>
	public class AnagramFinderV2 : IAnagramFinder
	{
		public ReadOnlyCollection<AnagramContainer> Parse(string input)
		{
			if(string.IsNullOrWhiteSpace(input))
				return new ReadOnlyCollection<AnagramContainer>(new List<AnagramContainer>());

			var originalWords = ParseInput(input);
			var sortedWords = CreateDuplicateListOfSortedWords(originalWords);
			var containers = new Dictionary<string, AnagramContainer>();

			for (int originalIndex = 0; originalIndex < originalWords.Count; originalIndex++)
			{
				var anagramsFound = new Dictionary<string, string>();
				for (int sortedIndex = 0; sortedIndex < sortedWords.Count; sortedIndex++)
				{
					if (IsAnAnagram(originalWords, sortedWords, originalIndex, sortedIndex, anagramsFound))
						anagramsFound.Add(originalWords[sortedIndex], null);
				}

				if (anagramsFound.Count > 1)
				{
					string key = Sort(originalWords[originalIndex]);
					if (!containers.ContainsKey(key))
						containers.Add(key, CreateNewAnagramContainer(originalWords[originalIndex], anagramsFound));
				}
			}

			return new ReadOnlyCollection<AnagramContainer>(containers.Values.ToList());
		}

		private static ReadOnlyCollection<string> ParseInput(string input)
		{
			return new ReadOnlyCollection<string>(RemovePunctuation(input).ToLower().Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries));
		}

		private static ReadOnlyCollection<string> CreateDuplicateListOfSortedWords(IEnumerable<string> originalWords)
		{
			return new ReadOnlyCollection<string>(originalWords.Select(Sort).ToList());
		}

		private static bool IsAnAnagram(
			IList<string> originalWords,
			IList<string> sortedWords,
			int originalIndex,
			int sortedIndex,
			IDictionary<string, string> matching)
		{
			bool qualifyingWord = sortedWords[originalIndex].Length > 1;
			bool isAnagram = sortedWords[originalIndex] == sortedWords[sortedIndex];
			bool alreadyFound = matching.ContainsKey(originalWords[sortedIndex]);

			return qualifyingWord && isAnagram && !alreadyFound;
		}

		private static AnagramContainer CreateNewAnagramContainer(
			string originalWord,
			IDictionary<string, string> anagramsFound)
		{
			return new AnagramContainer(new List<string>(new[] { originalWord }).Concat(anagramsFound.Keys.ToList()).Distinct());
		}

		private static string RemovePunctuation(string input)
		{
			return new string(input.ToCharArray().Where(c => !char.IsPunctuation(c)).ToArray());
		}

		private static string Sort(string input)
		{
			return string.Concat(input.OrderBy(c => c));
		}
	}
}