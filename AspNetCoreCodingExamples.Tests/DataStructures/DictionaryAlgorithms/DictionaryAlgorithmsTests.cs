using FluentAssertions;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;
using AspNetCoreCodingExamples.Domain.DataStructures.Services;

namespace AspNetCoreCodingExamples.Tests.DataStructures
{
    public class DictionaryAlgorithmsTests
    {
        private readonly IDictionaryAlgorithms _algorithms;

        public DictionaryAlgorithmsTests()
        {
            _algorithms = new DictionaryAlgorithms();
        }

        [Fact]
        public void TryGetValue_Should_Return_True_When_Key_Exists()
        {
            var dict = new Dictionary<string, int>()
            {
                { "a", 1 },
                { "b", 2 }
            };

            var result = _algorithms.TryGetValue(dict, "a", out var value);
            Assert.True(result);
            result.Should().BeTrue();

            Assert.Equal(1, value);
            value.Should().Be(1);
        }

        [Fact]
        public void TryGetValue_Should_Return_False_When_Key_Does_Not_Exist()
        {
            var dict = new Dictionary<string, int>()
            {
                { "x", 10 }
            };

            var result = _algorithms.TryGetValue(dict, "y", out var value);
            result.Should().BeFalse();
            Assert.False(result);

            value.Should().Be(0);
            Assert.Equal(0, value);
        }

        [Fact]
        public void TryGetValue_Should_ReturnFalse_WhenDictionaryIsNull()
        {
            var result = _algorithms.TryGetValue(null!, "key", out var value);
            result.Should().BeFalse();
            value.Should().Be(0);
        }

        [Fact]
        public void TryGetValue_Should_Return_False_WhenKeyIsNull()
        {
            var result = _algorithms.TryGetValue(new Dictionary<string,int>(), null!, out var value);
            result.Should().BeFalse();
            value.Should().Be(0);
        }

        [Fact]
        public void MergeDictionaries_Should_Contain_All_Keys()
        {
            var first = new Dictionary<string, int>()
            {
                { "a", 1 }, { "b", 2}
            };
            var second = new Dictionary<string, int>()
            {
                { "c", 3 }, { "d", 4}
            };

            var result = _algorithms.MergeDictionaries(first, second);
            result.Should().HaveCount(4);
            Assert.Equal(4, result.Count);

            result["c"].Should().Be(3);
            Assert.Equal(3, result["c"]);
        }

        [Fact]
        public void MergeDictionaries_Should_Handle_Null_Dictionaries()
        {
            var merged = _algorithms.MergeDictionaries(null!, null!);
            merged.Should().BeEmpty();

            var dict = new Dictionary<string, int> { { "a", 1 } };

            var merged2 = _algorithms.MergeDictionaries(dict, null!);
            merged2.Should().ContainKey("a");

            var merged3 = _algorithms.MergeDictionaries(null!, dict);
            merged3.Should().ContainKey("a");
        }

        [Fact]
        public void CountKeysStartingWith_Should_Return_Correct_Count()
        {
            var dict = new Dictionary<string, int>()
            {
                { "apple", 1 }, { "banana", 2}, { "apricot", 3}
            };

            var result = _algorithms.CountKeysStartingWith(dict, 'a');
            result.Should().Be(2);
            Assert.Equal(2, result);
        }

        [Fact]
        public void CountKeysStartingWith_Should_Return_Zero_When_Input_IsNull()
        {
            var result = _algorithms.CountKeysStartingWith(null!, 'a');
            result.Should().Be(0);
        }

        [Fact]
        public void GetKeysForValue_Should_Return_Correct_Keys()
        {
            var dict = new Dictionary<string, int>()
            {
                { "first", 5 }, { "second", 5}, { "third", 3}
            };

            var result = _algorithms.GetKeysForValue(dict, 5);
            result.Should().BeEquivalentTo(new List<string>() { "first", "second" });
            Assert.Equal(new List<string>() { "first", "second" }, result);
        }

        [Fact]
        public void GetKeysForValue_Should_Return_Empty_List_When_Input_IsNull()
        {
            var result = _algorithms.GetKeysForValue(null!, 5);
            result.Should().BeEquivalentTo(new List<string>());
        }

        [Fact]
        public void Invert_Should_Swap_Keys_And_Values()
        {
            var dict = new Dictionary<int, string>()
            {
                { 1, "a"}, { 2, "b"}, { 3, "c"}
            };
            
            var result = _algorithms.Invert(dict);
            result.Should().BeEquivalentTo(new Dictionary<string, int>() { { "a", 1 }, { "b", 2}, { "c", 3} });

            result.Should().ContainKey("a").WhoseValue.Should().Be(1);
            result.Should().ContainKey("b").WhoseValue.Should().Be(2);
            result.Should().ContainKey("c").WhoseValue.Should().Be(3);

            Assert.Equal(new Dictionary<string, int>() { { "a", 1 }, { "b", 2 }, { "c", 3 } }, result);
        }

        [Fact]
        public void Invert_Should_Throw_WhenInputIsNull()
        {

            var result = _algorithms.Invert(null!);
            result.Should().BeEquivalentTo(new Dictionary<string, int>());
        }

        [Fact]
        public void Invert_Should_Throw_WhenValueIsNull()
        {
            var input = new Dictionary<int, string> { { 1, null! } };
            Action act = () => _algorithms.Invert(input);
            act.Should().Throw<ArgumentException>()
                .WithMessage("*null value*");
        }

        [Fact]
        public void Invert_Should_Throw_WhenDuplicateValues()
        {
            var input = new Dictionary<int, string> { { 1, "a" }, { 2, "a" } };
            Action act = () => _algorithms.Invert(input);
            act.Should().Throw<ArgumentException>()
                .WithMessage("*Duplicate key*");
        }
    }
}