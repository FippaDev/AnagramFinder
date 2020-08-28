using System.Collections.ObjectModel;

namespace AnagramFinder
{
	public interface IAnagramFinder
	{
		ReadOnlyCollection<AnagramContainer> Parse(string input);
	}
}
