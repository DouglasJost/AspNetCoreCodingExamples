using System;
using System.Collections.Generic;
using System.Text;
using AspNetCoreCodingExamples.Domain.DataStructures.Interfaces;

namespace AspNetCoreCodingExamples.Domain.DataStructures.Services
{
    public class CharStringAlgorithms : ICharStringAlgorithms
    {
        public string FormatAlphabetAlternatingCase(bool isFirstCharUpper)
        {
            // Uppercase alphabets in ASCII range from 65 ('A') to 90 ('Z')
            // Lowercase alphabets in ASCII range from 97 ('a') to 122 ('z')

            var result = new StringBuilder();

            for (int i = 0; i < 26; i++)
            {
                var baseAsciiCode = 65;
                if (isFirstCharUpper)
                {
                    baseAsciiCode = i % 2 == 0 ? 65 : 97;
                }
                else 
                {
                    baseAsciiCode = i % 2 == 0 ? 97 : 65;
                }

                // Calculate current character's ASCII by adding 1 and adjusting case
                var letter = (char)(baseAsciiCode + i);
                result.AppendFormat($"{letter}");
            }

            return result.ToString();
        }

        public string ConvertFrom12To24HoursFormat(string inputTime)
        {
            /*
                Using .NET and C#, you need to convert the time from 12 hours format to 24 hours format.

                Assume the skeleton class TimeConvertor is given.  You need to implement the function
                ConvertFrom12To24HoursFormat(string inputTime).  This function parses the given input
                string (inputTime in 12 hours format) and converts the time to 24 hours format.

                The TimeConvertor class takes a string (InputTime in 12 hours format) and calls the 
                ConvertFrom12To24HoursFormat function to convert the time to 24 hours format.

                Two examples:
                  Input: inputTime = 12:00 am
                  Output: 0:00

                  Input: inputTime = 1:05 pm
                  Output: 13:05
            */

            if (string.IsNullOrWhiteSpace(inputTime))
            {
                throw new ArgumentNullException(nameof(inputTime), "Input time cannot be null or empty.");
            }

            var time = inputTime.Trim().ToUpper();
            var indexAM = time.IndexOf("AM");
            var indexPM = time.IndexOf("PM");

            if (indexAM == -1 && indexPM == -1)
            {
                throw new FormatException("Input time must end with 'AM' or 'PM'.");
            }

            time = time.Replace("AM", string.Empty).Trim();
            time = time.Replace("PM", string.Empty).Trim();

            var timeParts = time.Split(':');
            if (timeParts.Length != 2)
            {
                throw new FormatException("Input time must be in the format 'hh:mm am/pm'.");
            }

            //var hours = int.Parse(timeParts[0]);   // Convert to an int.  May need to do MATH.
            //var minutes = timeParts[1];            // Leave as a string.  If converted to an int, will format "05" as "5".

            if (!int.TryParse(timeParts[0], out int hours) || !int.TryParse(timeParts[1], out int minutes))
            {
                throw new FormatException("Hour and minute must be valid integers.");
            }

            if (hours < 1 || hours > 12 || minutes < 0 || minutes > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(inputTime), "Hours must be between 1-12 and minutes between 0-59.");
            }

            if (indexAM > -1)
            {
                if (hours == 12)
                {
                    hours = 0;
                }
            }
            else
            {
                if (hours != 12)
                {
                    hours = hours + 12;
                }
            }

            return $"{hours}:{minutes:D2}";
        }

        public bool IsPalindrome(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            int left = 0;
            int right = input.Length - 1;

            while (left < right)
            {
                if (char.ToLower(input[left]) != char.ToLower(input[right]))
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }

        public string ReplaceVowelsWithSymbol(string input, char symbol)
        {
            if (input == null) return null!;

            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            var result = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = vowels.Contains(char.ToLower(input[i])) ? symbol : input[i];
            }

            return new string(result);
        }

        public bool IsValidIpAddress(string? ipAddress)
        {
            /*
                1.  Must have 4 octets.
                2.  Octet must be >= 0 and <= 255.
                3.  Cannot have a leading 0.              
              
                Test Cases:
                    IP Address: 192.168.1.1;    Is Valid: True
                    IP Address: 192.168.01.1;   Is Valid: False   Reason False: Third octet has leading zero
                    IP Address: 256.100.50.25;  Is Valid: False;  Reason False: Octet greater than 255
                    IP Address: 192.168.1;      Is Valid: False;  Reason False: Need 4 octets
                    IP Address: 192.168.1.001;  Is Valid: False;  Reason False: Fourth octet has leading zeros
                    IP Address: 10.0.0.0;       Is Valid: True;   
            */

            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                return false;
            }

            var ipStr = ipAddress.Trim();
            var ipParts = ipStr.Split('.');
            if (ipParts.Length != 4)
            {
                return false;
            }

            foreach (var octet in ipParts)
            {
                if (int.TryParse(octet, out var intOctet))
                {
                    if (intOctet < 0 || intOctet > 255)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                if ((octet.Length > 3) || (octet.StartsWith("0") && octet != "0"))
                {
                    return false;
                }
            }

            return true;
        }

        public (string? sentenceWithoutSpecialChars, string? specialChars) RemoveSpecialCharacters(string testStr)
        {
            /*
                The given code snippet is supposed to remove all special characters from a string.  The only
                characters allowed in the string are the 26 letters in the English alphabet(A to Z and a to z),
                digits(0 to 9), spaces(), dashes(-) and underscores(_).  The function should return NA if
                the string only contains special characters.

                Uppercase alphabets in ASCII range from 65 ('A') to 90 ('Z')
                Lowercase alphabets in ASCII range from 97 ('a') to 122 ('z')

                Space       ( )  ASCII 32
                Dash/Minus  (-)  ASCII 45
                Period      (.)  ASCII 46
                Underscore  (_)  ASCII 95
                Integer Numbers from 48 (0) to 57 (9)
            */

            if (string.IsNullOrWhiteSpace(testStr))
            {
                return (string.Empty, string.Empty);
            }

            StringBuilder sentenceWithoutSpecialChars = new StringBuilder();
            HashSet<char> specialChars = new HashSet<char>();

            foreach (var chr in testStr)
            {
                var validCharacter = false;

                if (chr >= 65 && chr <= 90)
                {
                    validCharacter = true;
                }
                else if (chr >= 97 && chr <= 122)
                {
                    validCharacter = true;
                }
                else if (chr >= 48 && chr <= 57)
                {
                    validCharacter = true;
                }
                else if (chr == 32 || chr == 45 || chr == 46 || chr == 95)
                {
                    validCharacter = true;
                }

                if (validCharacter)
                {
                    sentenceWithoutSpecialChars.Append(chr);
                }
                else
                {
                    if (!specialChars.Contains(chr))
                    {
                        specialChars.Add(chr);
                    }
                }
            }

            return (sentenceWithoutSpecialChars.ToString(), String.Join(',', specialChars));
        }


    }
}
