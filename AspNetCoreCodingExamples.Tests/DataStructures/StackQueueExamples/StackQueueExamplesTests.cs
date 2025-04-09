using FluentAssertions;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;
using AspNetCoreCodingExamples.Domain.DataStructures.Services;

namespace AspNetCoreCodingExamples.Tests.DataStructures
{
    public class StackQueueExamplesTests
    {
        private readonly IStackQueueExamples _algorithms;

        public StackQueueExamplesTests()
        {
            _algorithms = new StackQueueExamples();
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("()[({})]{}", true)]
        [InlineData("([)]", false)]
        [InlineData("", false)]
        public void AreBracketsBalanced_Should_Return_Correct_Result(string input, bool expected)
        {
            var result = _algorithms.AreBracketsBalanced(input);
            result.Should().Be(expected);
        }

        [Fact]
        public void ReverseQueue_Should_Throw_When_Null()
        {
            Queue<int> input = null!;

            Action act = () => _algorithms.ReverseQueue(input);

            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("queue");
        }

        [Fact]
        public void ReverseQueue_Should_Return_Same_For_EmptyQueue()
        {
            var input = new Queue<int>();

            var result = _algorithms.ReverseQueue(input);

            result.Should().BeEmpty();
        }

        [Fact]
        public void ReverseQueue_Should_Reverse_Queue()
        {
            var input = new Queue<int>(new[] { 1, 2, 3 });

            var result = _algorithms.ReverseQueue(input);

            result.Should().Equal(3, 2, 1);
        }

        [Fact]
        public void ReverseQueue_Should_Reverse_StringQueue()
        {
            var input = new Queue<string>(new[] { "a", "b", "c" });

            var result = _algorithms.ReverseQueue(input);

            result.Should().Equal("c", "b", "a");
        }


    }
}
