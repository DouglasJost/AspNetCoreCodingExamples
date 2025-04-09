namespace AspNetCoreCodingExamples.Domain.DataStructures.Interfaces
{
    public interface ICharStringAlgorithms
    {
        /*
        Convert char to ASCII and back
        Detect if a string is a palindrome
        Replace vowels with a symbol
        */

        string FormatAlphabetAlternatingCase(bool isFirstCharUpper);
        string ConvertFrom12To24HoursFormat(string inputTime);
        bool IsPalindrome(string input);
        string ReplaceVowelsWithSymbol(string input, char symbol);
        bool IsValidIpAddress(string? ipAddress);
        public (string? sentenceWithoutSpecialChars, string? specialChars) RemoveSpecialCharacters(string testStr);
    }
}
