using System;
using System.Collections.Generic;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;

namespace AspNetCoreCodingExamples.Domain.DataStructures.Services
{
    public class HashSetExamples : IHashSetExamples
    {
        public IEnumerable<T> GetSetDifference<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("Input collections cannot be null");
            }

            var firstHashSet = new HashSet<T>(first);
            var secondHashSet = new HashSet<T>(second);

            firstHashSet.ExceptWith(secondHashSet);
            return firstHashSet;
        }

        public IEnumerable<T> GetIntersection<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException("Input collections cannot be null");
            }

            var firstHashSet = new HashSet<T>(first);
            var secondHashSet = new HashSet<T>(second);

            firstHashSet.IntersectWith(secondHashSet);
            return firstHashSet;
        }

        public bool HasDuplicates<T>(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            var seenHashSet = new HashSet<T>();

            foreach (var item in items)
            {
                if (!seenHashSet.Add(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
