using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;

namespace AspNetCoreCodingExamples.Domain.DataStructures.Services
{
    public class ArrayAlgorithms : IArrayAlgorithms
    {
        public ArrayAlgorithms() { }

        public int[] Reverse(int[] input) 
        {
            if (input == null) 
            {
                throw new ArgumentNullException(nameof(input));
            }
            return input.Reverse().ToArray();
        }
        public int[] ReverseManual(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var result = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                result[i] = input[input.Length - 1 - i];
            }
            return result;
        }


        public int FindMin(int[] input)
        {
            if (input == null || input.Length <= 0)
            {
                throw new ArgumentNullException($"input array cannot be null or empty.");
            }
            return input.Min();
        }
        public int FindMinManual(int[] input)
        {
            if (input == null || input.Length <= 0)
            {
                throw new ArgumentNullException($"input array cannot be null or empty.");
            }

            int min = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] < min)
                {
                    min = input[i];
                }
            }
            return min;
        }


        public int FindMax(int[] input)
        {
            if (input == null || input.Length <= 0)
            {
                throw new ArgumentNullException($"input array cannot be null or empty.");
            }
            return input.Max();
        }
        public int FindMaxManual(int[] input)
        {
            if (input == null || input.Length <= 0)
            {
                throw new ArgumentNullException($"input array cannot be null or empty.");
            }

            int max = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > max)
                {
                    max = input[i];
                }
            }
            return max;
        }


        public int Sum(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return input.Sum();
        }
        public int SumManual(int[] input)
        {
            var sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
            }
            return sum;
        }


        public int[] FindDuplicates(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            return input
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToArray();
        }
        public int[] FindDuplicatesManual(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var duplicates = new List<int>();
            var seen = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                bool alreadySeen = false;
                for (int j = 0; j < seen.Count; j++)
                {
                    if (seen[j] == input[i])
                    {
                        alreadySeen = true;
                        break;
                    }
                }

                if (!alreadySeen)
                {
                    seen.Add(input[i]);
                    for (int k = i + 1; k < input.Length; k++)
                    {
                        if (input[k] == input[i])
                        {
                            duplicates.Add(input[i]);
                            break;
                        }
                    }
                }
            }

            return duplicates.ToArray();
        }
    }
}
