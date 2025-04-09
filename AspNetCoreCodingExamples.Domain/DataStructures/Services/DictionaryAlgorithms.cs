using System;
using System.Collections.Generic;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;

namespace AspNetCoreCodingExamples.Domain.DataStructures.Services
{
    public class DictionaryAlgorithms : IDictionaryAlgorithms
    {
        public bool TryGetValue(Dictionary<string, int> input, string key, out int value)
        {
            value = default;
            if (input == null || string.IsNullOrEmpty(key))
            {
                return false;
            }


            foreach(var kvPair in input)
            {
                if (kvPair.Key == key)
                {
                    value = kvPair.Value;
                    return true;
                }
            }
            return false;
        }

        public Dictionary<string, int> MergeDictionaries(Dictionary<string, int> first, Dictionary<string, int> second)
        {
            var result = new Dictionary<string, int>();

            if (first != null)
            {
                foreach (var kvFirst in first)
                {
                    result[kvFirst.Key] = kvFirst.Value;
                }
            }

            if (second != null)
            {
                foreach (var kvSecond in second)
                {
                    result[kvSecond.Key] = kvSecond.Value;
                }
            }

            return result;
        }

        public int CountKeysStartingWith(Dictionary<string, int> input, char prefix)
        {
            int count = 0;
            if (input != null)
            {
                foreach (var kvPair in input)
                {
                    if (!string.IsNullOrEmpty(kvPair.Key) && kvPair.Key[0] == prefix)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public List<string> GetKeysForValue(Dictionary<string, int> input, int value)
        {
            var result = new List<string>();

            if (input != null)
            {
                foreach (var kvPair in input)
                {
                    if (kvPair.Value == value)
                    {
                        result.Add(kvPair.Key);
                    }
                }
            }

            return result;
        }

        public Dictionary<string, int> Invert(Dictionary<int, string> input)
        {
            var result = new Dictionary<string, int>();

            if (input != null)
            {
                foreach (var kvPair in input)
                {
                    if (string.IsNullOrWhiteSpace(kvPair.Value))
                    {
                        throw new ArgumentException("Input dictionary contains a null value which cannot be used as a key.");
                    }
                    if (result.ContainsKey(kvPair.Value))
                    {
                        throw new ArgumentException($"Duplicate key detected when inverting: {kvPair.Value}");
                    }
                    result[kvPair.Value] = kvPair.Key;
                }
            }

            return result;
        }
    }
}
