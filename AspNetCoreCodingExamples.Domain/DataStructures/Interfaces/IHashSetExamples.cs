using System.Collections.Generic;

namespace AspNetCoreCodingExamples.Domain.DataStructures.Interfaces
{
    public interface IHashSetExamples
    {
        /*
        Set difference
        Intersection
        Detect duplicates in a list
        */

        IEnumerable<T> GetSetDifference<T>(IEnumerable<T> first, IEnumerable<T> second);
        IEnumerable<T> GetIntersection<T>(IEnumerable<T> first, IEnumerable<T> second);
        bool HasDuplicates<T>(IEnumerable<T> items);
    }
}
