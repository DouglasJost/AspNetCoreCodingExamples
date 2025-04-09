using FluentAssertions;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;
using AspNetCoreCodingExamples.Domain.DataStructures.Services;

namespace AspNetCoreCodingExamples.Tests.DataStructures
{
    public class HashSetExamplesTests
    {
        private readonly IHashSetExamples _algorithms;

        public HashSetExamplesTests() 
        {
            _algorithms = new HashSetExamples();
        }

        [Fact]
        public void HasDuplicates_Should_ReturnFalse_ForEmptyList()
        {
            var list = new List<int>();
            var result = _algorithms.HasDuplicates(list);
            result.Should().BeFalse();
        }

        [Fact]
        public void HasDuplicates_Should_ReturnFalse_WhenNoDuplicates()
        {
            var list = new List<string> { "apple", "banana", "cherry" };
            var result = _algorithms.HasDuplicates(list);
            result.Should().BeFalse();
        }

        [Fact]
        public void HasDuplicates_Should_ReturnTrue_WhenDuplicatesExist()
        {
            var list = new List<string> { "apple", "banana", "apple" };
            var result = _algorithms.HasDuplicates(list);
            result.Should().BeTrue();
        }

        [Fact]
        public void HasDuplicates_Should_ReturnFalse_ForSingleElementList()
        {
            var list = new List<char> { 'A' };
            var result = _algorithms.HasDuplicates(list);
            result.Should().BeFalse();
        }

        [Fact]
        public void HasDuplicates_Should_Handle_NumericTypes()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 3 };
            var result = _algorithms.HasDuplicates(list);
            result.Should().BeTrue();
        }

        [Fact]
        public void GetSetDifference_Should_Return_Correct_Difference()
        {
            var first = new List<string>() { "a", "b", "c" };
            var second = new List<string>() { "b", "c", "d" };

            var result = _algorithms.GetSetDifference(first, second);

            result.Should().BeEquivalentTo("a");
        }

        [Fact]
        public void GetSetDifference_Should_Throw_On_Null_Input()
        {
            Action act = () => _algorithms.GetSetDifference<string>(null!, new[] { "x" });
            act.Should().Throw<ArgumentNullException>().WithMessage("*cannot be null*");
        }

        [Fact]
        public void GetIntersection_Should_Return_Common_Elements()
        {
            var first = new List<int>() { 1, 2, 3, 4 };
            var second = new List<int>() { 3, 4, 5, 6 };

            var actualResult = _algorithms.GetIntersection(first, second);

            var testResult = new List<int>() {3, 4 };
            actualResult.Should().BeEquivalentTo(testResult);
        }

        [Fact]
        public void GetIntersection_Should_Return_Empty_If_No_Common_Elements()
        {
            var first = new List<string>() { "x", "y" };
            var second = new List<string>() { "a", "b" };

            var actualResult = _algorithms.GetIntersection(first, second);

            actualResult.Should().BeEmpty();
        }

        [Fact]
        public void GetIntersection_Should_Throw_On_Null_Input()
        {
            Action act = () => _algorithms.GetIntersection<int>(null!, new[] { 1 });
            act.Should().Throw<ArgumentNullException>().WithMessage("*cannot be null*");
        }
    }
}
