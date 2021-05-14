using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SherlockAndTheValidString
{

    class MaximumPalindrome
    {

        /*
         * Complete the 'initialize' function below.
         *
         * The function accepts STRING s as parameter.
         */

        public static void initialize(string s)
        {
            // This function is called once before all queries.

        }

        /*
         * Complete the 'answerQuery' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER l
         *  2. INTEGER r
         */

        public static int answerQuery(int l, int r,string s)
        {
            // Return the answer for this query modulo 1000000007.

            string str = expand(s,l,r); // s.Substring(l-1, r-l+1);
            // String deki her karajkterin adet sayısı
            var groupBy = str.GroupBy(x => x);

            int CountOfSingles = 0;
            int numeratorOfResult = 0;
            int denominatorOfResult = 1;
            int frequency = 0;

            foreach (var item in groupBy)
            {
                Console.WriteLine(item.Key + " " + item.Count());
                // frequency =  Karakter adetleri çift ise adet/2 işlemi gerçekleştirilir değilse adet -1 / 2 işlemine tabi tutulur.

                if (item.Count() % 2 == 0)
                {
                    frequency = item.Count() / 2;
                }
                else
                {
                    frequency = (item.Count() - 1) / 2;
                    CountOfSingles++;
                }

                numeratorOfResult = numeratorOfResult + frequency;
                denominatorOfResult = denominatorOfResult * Faktor(frequency);
            }

            if (numeratorOfResult != 0)
                numeratorOfResult = Faktor(numeratorOfResult);

            int result = numeratorOfResult / denominatorOfResult;

            if (CountOfSingles != 0)
            {
                result = result * CountOfSingles;
            }

            return (result);
        }

        public static int Faktor(int n) {
            if (n == 0)
            {
                return 1;
            }
            return n * Faktor(n - 1);
        }

        // Expand in both directions of `low` and `high` to find
        // maximum length palindrome
        public static string expand(string str, int low, int high)
        {
            int len = str.Length;

            // run till `str[low.high]` is a palindrome
            while (low >= 0 && high < len && (str[low] == str[high]))
            {
                low--; high++;        // Expand in both directions
            }

            // return palindromic substring
            return str.Substring(low + 1, high - low - 1);
        }
    }

}
