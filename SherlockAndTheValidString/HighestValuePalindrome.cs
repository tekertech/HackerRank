using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SherlockAndTheValidString
{
    public static class HighestValuePalindrome
    {
        /*
        * Complete the 'highestValuePalindrome' function below.
        *
        * The function is expected to return a STRING.
        * The function accepts following parameters:
        *  1. STRING s
        *  2. INTEGER n
        *  3. INTEGER kVDHCC 
        */

        public static string highestValuePalindrome(string s, int n, int k)
        {
            int firstIndex = 0;
            int lastIndex = n - 1;
            int diff = 0;
            List<char> character = new List<char>();
            character = s.ToList();

            if (n == 1 && character[0] != '9' && k >= 1)
            {
                character[0] = '9';
            }

            for (int i = 0, j = lastIndex; i < n / 2; i++, j--)
            {
                if (character[i] != character[j]) diff++;
            }

            if (k < diff) return "-1";

            while (firstIndex <= lastIndex)
            {
                if (character[firstIndex] == character[lastIndex] && character[firstIndex] != '9' && k - 2 >= 0)
                {
                    character[firstIndex] = '9';
                    character[lastIndex] = '9';
                    k -= 2;
                }
                else if (character[firstIndex] == character[lastIndex] && character[firstIndex] != '9' && k >= 1 && firstIndex == lastIndex)
                {
                    character[firstIndex] = '9';
                }
                else if (character[firstIndex] != character[lastIndex] && character[firstIndex] != '9' && character[lastIndex] != '9' && k - 2 >= 0)
                {
                    character[firstIndex] = '9';
                    character[lastIndex] = '9';
                    k -= 2;
                    diff -= 1;
                }else if (character[firstIndex] != character[lastIndex] && k >= 1)
                {
                    if(character[firstIndex] > character[lastIndex])
                    {
                        character[lastIndex] = character[firstIndex];
                    }
                    else
                    {
                        character[firstIndex] = character[lastIndex]; 
                    }
                }

                firstIndex++;
                lastIndex--;
            }

            return new string(character.ToArray());
        }
    }
}
