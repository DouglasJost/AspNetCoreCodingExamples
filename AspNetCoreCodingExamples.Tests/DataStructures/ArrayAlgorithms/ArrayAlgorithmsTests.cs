using FluentAssertions;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;
using AspNetCoreCodingExamples.Domain.DataStructures.Services;

namespace AspNetCoreCodingExamples.Tests.DataStructures
{
    public class ArrayAlgorithmsTests
    {
        private readonly IArrayAlgorithms _algorithms;

        public ArrayAlgorithmsTests()
        {
            _algorithms = new ArrayAlgorithms();
        }

        [Fact]
        public void Reverse_Should_Return_Reversed_Array()
        {
            var input = new int[] { 1, 2, 3 };
            var result = _algorithms.Reverse(input);
            result.Should().Equal(new int[] { 3, 2, 1 });
        }

        [Fact]
        public void ReverseManual_Should_Return_Reversed_Array()
        {
            var input = new int[] { 1, 2, 3 };
            var result = _algorithms.ReverseManual(input);
            result.Should().Equal(new int[] { 3, 2, 1 });
        }


        [Fact]
        public void FindMin_Should_Return_Minimum_Value()
        {
            var input = new[] { 4, 2, 7, 1 };
            var result = _algorithms.FindMin(input);
            result.Should().Be(1);
        }

        [Fact]
        public void FindMinManual_Should_Return_Minimum_Value()
        {
            var input = new[] { 4, 2, 7, 1 };
            var result = _algorithms.FindMinManual(input);
            result.Should().Be(1);
        }


        [Fact]
        public void FindMax_Should_Return_Maximum_Value()
        {
            var input = new[] { 4, 2, 7, 1 };
            var result = _algorithms.FindMax(input);
            result.Should().Be(7);
        }

        [Fact]
        public void FindMaxManual_Should_Return_Maximum_Value()
        {
            var input = new[] { 4, 2, 7, 1 };
            var result = _algorithms.FindMaxManual(input);
            result.Should().Be(7);
        }


        [Fact]
        public void Sum_Should_Return_Sum_Of_Elements()
        {
            var input = new[] { 1, 2, 3 };
            var result = _algorithms.Sum(input);
            result.Should().Be(6);
        }

        [Fact]
        public void SumManual_Should_Return_Sum_Of_Elements()
        {
            var input = new[] { 1, 2, 3 };
            var result = _algorithms.SumManual(input);
            result.Should().Be(6);
        }


        [Fact]
        public void FindDuplicates_Should_Return_Duplicates()
        {
            var input = new[] { 1, 2, 2, 3, 3, 3, 4 };
            var result = _algorithms.FindDuplicates(input);
            result.Should().BeEquivalentTo(new[] { 2, 3 });
        }

        [Fact]
        public void FindDuplicatesManual_Should_Return_Duplicates()
        {
            var input = new[] { 1, 2, 2, 3, 3, 3, 4 };
            var result = _algorithms.FindDuplicatesManual(input);
            result.Should().BeEquivalentTo(new[] { 2, 3 });
        }
    }
}
