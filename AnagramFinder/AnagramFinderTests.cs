using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnagramFinder
{
	[TestClass]
	public class AnagramFinderTests
	{
		[TestMethod]
		public void V1_Parse_GivenText_FindTwoSetsOfAnagrams()
		{
			Parse_FindTwoSetsOfAnagrams(new AnagramFinderV1());
		}

		[TestMethod]
		public void V1_Parse_GivenNullInput_ReturnsNullInput()
		{
			Parse_GivenNullInput_ReturnsNullInput(new AnagramFinderV1());
		}

		[TestMethod]
		public void V1_Parse_GivenWhitespaceInput_ReturnsNullInput()
		{
			Parse_GivenWhitespaceInput_ReturnsNullInput(new AnagramFinderV1());
		}

		[TestMethod]
		public void V2_Parse_GivenText_FindTwoSetsOfAnagrams()
		{
			Parse_FindTwoSetsOfAnagrams(new AnagramFinderV2());
		}

		[TestMethod]
		public void V2_Parse_GivenNullInput_ReturnsNullInput()
		{
			Parse_GivenNullInput_ReturnsNullInput(new AnagramFinderV2());
		}

		[TestMethod]
		public void V2_Parse_GivenWhitespaceInput_ReturnsNullInput()
		{
			Parse_GivenWhitespaceInput_ReturnsNullInput(new AnagramFinderV2());
		}


		private void Parse_FindTwoSetsOfAnagrams(IAnagramFinder anagramFinder)
		{
			var input = "I saw a spot on a post that was labeled 'opts'.  That  didn't  really  make  any sense because the post should have said \"tops\".";
			var expectedSets = new List<AnagramContainer>
			{
				new AnagramContainer(new [] { "saw", "was" }),
				new AnagramContainer(new [] { "opts", "post", "spot", "tops" })
			};

			var foundSets = anagramFinder.Parse(input);

			Assert.AreEqual(expectedSets.Count, foundSets.Count);

			for (var index = 0; index < expectedSets.Count; index++)
			{
				List<string> expected = expectedSets[index].Anagrams.ToList();
				expected.Sort();
				List<string> actual = foundSets[index].Anagrams.ToList();
				actual.Sort();
				CollectionAssert.AreEqual(expected, actual);
			}
		}

		private void Parse_GivenNullInput_ReturnsNullInput(IAnagramFinder anagramFinder)
		{
			var emptyCollection = new List<AnagramContainer>();
			var actual = anagramFinder.Parse(null);

			CollectionAssert.AreEqual(emptyCollection, actual);
		}

		private void Parse_GivenWhitespaceInput_ReturnsNullInput(IAnagramFinder anagramFinder)
		{
			var emptyCollection = new List<AnagramContainer>();
			var actual = anagramFinder.Parse("    ");

			CollectionAssert.AreEqual(emptyCollection, actual);
		}

		// TODO Unit tests for CreateDuplicateListOfSortedWords
		// TODO Unit tests for IsAnAnagram
		// TODO Unit tests for RemovePunctuation
		// TODO Unit tests for Sort
	}
}