using System.Collections.Generic;

namespace AspNetCoreCodingExamples.Domain.DataStructures.Interfaces
{
    public interface IDictionaryAlgorithms
    {
        bool TryGetValue(Dictionary<string, int> input, string key, out int value);
        Dictionary<string, int> MergeDictionaries(Dictionary<string, int> first, Dictionary<string, int> second);
        int CountKeysStartingWith(Dictionary<string, int> input, char prefix);
        List<string> GetKeysForValue(Dictionary<string, int> input, int value);
        Dictionary<string, int> Invert(Dictionary<int, string> input);

    }
}
