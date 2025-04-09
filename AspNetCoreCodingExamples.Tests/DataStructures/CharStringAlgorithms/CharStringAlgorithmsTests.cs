using FluentAssertions;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;
using AspNetCoreCodingExamples.Domain.DataStructures.Services;

namespace AspNetCoreCodingExamples.Tests.DataStructures
{
    public class CharStringAlgorithmsTests
    {
        private readonly ICharStringAlgorithms _algorithms;

        public CharStringAlgorithmsTests()
        {
            _algorithms = new CharStringAlgorithms();
        }

        [Fact]
        public void FormatAlphabetAlternatingCase_Where_IsFirstCharUpper_IsFalse()
        {
            var result = _algorithms.FormatAlphabetAlternatingCase(false);
            result.Should().Be("aBcDeFgHiJkLmNoPqRsTuVwXyZ");
        }

        [Fact]
        public void FormatAlphabetAlternatingCase_Where_IsFirstCharUpper_IsTrue()
        {
            var result = _algorithms.FormatAlphabetAlternatingCase(true);
            result.Should().Be("AbCdEfGhIjKlMnOpQrStUvWxYz");
        }


        [Theory]
        [InlineData("12:00 am", "0:00")]
        [InlineData("1:05 pm", "13:05")]
        [InlineData("12:00 pm", "12:00")]
        [InlineData("11:59 pm", "23:59")]
        [InlineData("1:00 am", "1:00")]
        [InlineData("09:45 am", "9:45")]
        [InlineData(" 2:30 Pm ", "14:30")] // Test with extra spaces and mixed case
        public void ConvertFrom12To24HoursFormat_Should_Return_CorrectResult(string input, string expected)
        {
            var result = _algorithms.ConvertFrom12To24HoursFormat(input);
            result.Should().Be(expected);
        }

        [Fact]
        public void ConvertFrom12To24HoursFormat_Should_Throw_On_Invalid_Format()
        {
            var invalidInput = "25:99 pm";
            Action act = () => _algorithms.ConvertFrom12To24HoursFormat(invalidInput);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData("invalid")]
        public void ConvertFrom12To24HoursFormat_Should_Throw_On_Null_Or_Invalid_Input(string input)
        {
            Action act = () => _algorithms.ConvertFrom12To24HoursFormat(input);
            act.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData("madam", true)]
        [InlineData("Racecar", true)]
        [InlineData("hello", false)]
        [InlineData("", false)]
        [InlineData("A", true)]
        public void IsPalindrome_Should_CorrectlyIdentifyPalindromeStrings(string input, bool expected)
        {
            var result = _algorithms.IsPalindrome(input);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("hello", '*', "h*ll*")]
        [InlineData("HELLO", '#', "H#LL#")]
        [InlineData("xyz", '@', "xyz")]
        [InlineData("aeiou", '-', "-----")]
        [InlineData("", '!', "")]
        public void ReplaceVowelsWithSymbol_Should_ReplaceVowelsCorrectly(string input, char symbol, string expected)
        {
            var result = _algorithms.ReplaceVowelsWithSymbol(input, symbol);
            result.Should().Be(expected);
        }

        [Fact]
        public void ReplaceVowelsWithSymbol_Should_ReturnNull_WhenInputIsNull()
        {
            var result = _algorithms.ReplaceVowelsWithSymbol(null!, '*');
            result.Should().BeNull();
        }

        [Theory]
        [InlineData("192.168.1.1", true)]
        [InlineData("10.0.0.0", true)]
        [InlineData("192.168.01.1", false)] // Leading zero in third octet
        [InlineData("256.100.50.25", false)] // Octet out of range
        [InlineData("192.168.1", false)] // Only 3 octets
        [InlineData("192.168.1.001", false)] // Leading zero in fourth octet
        [InlineData("192.168.1.a", false)] // Non-numeric octet
        [InlineData("192.168..1", false)] // Missing octet
        [InlineData("192.168.1.1.1", false)] // Extra octet
        [InlineData(" 192.168.1.1 ", true)] // Leading/trailing spaces
        [InlineData("", false)] // Empty string
        [InlineData(null, false)] // Null input
        public void IsValidIpAddress_Should_Validate_Correctly(string? ipAddress, bool expected)
        {
            var result = _algorithms.IsValidIpAddress(ipAddress);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Hello, World!", "Hello World", ",,!")]
        [InlineData("Abc123_ -.", "Abc123_ -.", "")] // No special characters
        [InlineData("!@#$%^&*()", "", "!,@,#,$,%,^,&,*,(,)")] // Only special characters
        [InlineData("", "", "")] // Empty string
        [InlineData("C# is awesome!", "C is awesome", "#,!")] // Mixed sentence
        public void RemoveSpecialCharacters_Should_Return_Cleaned_And_Specials(
            string input,
            string expectedCleaned,
            string expectedSpecials)
        {
            // Act
            var (cleanedSentence, specialsRemoved) = _algorithms.RemoveSpecialCharacters(input);

            // Assert
            cleanedSentence.Should().Be(expectedCleaned);
            specialsRemoved.Should().Be(expectedSpecials);
        }

        [Fact]
        public void RemoveSpecialCharacters_Should_Handle_Repeated_Specials()
        {
            var input = "Wow!!! This??? is -- cool...";

            var (cleanedSentence, specialsRemoved) = _algorithms.RemoveSpecialCharacters(input);

            cleanedSentence.Should().Be("Wow This is -- cool...");
            specialsRemoved.Should().Be("!,?");
        }

        [Fact]
        public void RemoveSpecialCharacters_Should_Not_Throw_On_Null()
        {
            // Arrange
            string? input = null;

            // Act
            var result = () => _algorithms.RemoveSpecialCharacters(input!);

            // Assert
            result.Should().NotThrow<Exception>();
        }


    }
}
