using System.Text;
namespace Levenshtein.Data
{
    public class Soundex
    {
        public static string CalculateSoundex(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return "";
            }

            // Convert to uppercase and get the first character
            char firstChar = char.ToUpper(word[0]);
            word = word.Substring(1);

            // Soundex algorithm implementation
            StringBuilder soundexCode = new StringBuilder().Append(firstChar);
            char prevCode = GetCode(firstChar);

            foreach (char currentChar in word)
            {
                char currentCode = GetCode(currentChar);
                if (currentCode != '0' && currentCode != prevCode)
                {
                    soundexCode.Append(currentCode);
                }
                prevCode = currentCode;
            }

            // Trim or pad to make it a 4-character code
            soundexCode.Length = Math.Min(4, soundexCode.Length);
            soundexCode.Append('0', 4 - soundexCode.Length);

            return soundexCode.ToString();
        }

        static char GetCode(char c)
        {
            switch (char.ToUpper(c))
            {
                case 'B':
                case 'F':
                case 'P':
                case 'V':
                    return '1';
                case 'C':
                case 'G':
                case 'J':
                case 'K':
                case 'Q':
                case 'S':
                case 'X':
                case 'Z':
                    return '2';
                case 'D':
                case 'T':
                    return '3';
                case 'L':
                    return '4';
                case 'M':
                case 'N':
                    return '5';
                case 'R':
                    return '6';
                default:
                    return '0'; // For non-matching characters
            }
        }
    }
}
