using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SherlockAndTheValidString
{
    public static class SherlockAndAnagrams
    {
        /*
          Kaynak Alınan Site : https://codereview.stackexchange.com/questions/153367/hackerrank-sherlock-and-anagram
         */

        /*
     * Complete the 'sherlockAndAnagrams' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

        public static int sherlockAndAnagrams(string s)
        {
            Dictionary<int, int> valuePairs = new Dictionary<int, int>();
            int length = s.Length;

            //  Karakter sayısına bakmak ıcın ılk basta 1 basamak sonra 2 sonra 3 ..
            //  örn: abba -> a , b , b , a ; ab, bb, ba ; abb , bba gibi
            //  burda tutulacak dictionary dekı mantık onemli,  sırası onemlı degıl abb veya bab olabılır ama burdakı karakterlere gore key degerının hash algorıtması ıle alacagız.
            for (int subStringLength = 1; subStringLength < length; subStringLength++) // string ı 1'den baslayacak parcalamak
            {
                for (int i = 0; i <= length - subStringLength; i++) // ne kadar donecegız
                {
                    Dictionary<char, int> keyValues = new Dictionary<char, int>();

                    for (int j = i; j < i + subStringLength; j++) // adetlerını bulmak
                    {
                        char character = s[j];
                        if (keyValues.ContainsKey(character)) {
                            keyValues[character]++;
                        } else {
                            keyValues.Add(character, 1);
                        }
                    }

                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (var item in keyValues.OrderBy(x=> x.Key))
                    {
                        stringBuilder.Append(item.Key + item.Value.ToString());

                    }

                    var key = stringBuilder.ToString().GetHashCode();

                    if (valuePairs.ContainsKey(key))
                    {
                        valuePairs[key]++;
                    } else {
                        valuePairs.Add(key, 1);
                    }
                }
            }

            int result = 0;

            foreach (var item in valuePairs)
            {
                result += item.Value * (item.Value - 1) / 2; 
            }

            return result;
        }
    }
}
