using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SherlockAndTheValidString
{
    public class CommonChild
    {
        /*
     * Complete the 'commonChild' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING s1
     *  2. STRING s2
     */

        public static int commonChild(string s1, string s2)
        {
            int s1Length = s1.Length;
            int s2Length = s2.Length;
            int[] array = new int[s1Length + 1];
            char[] arrayS1 = s1.ToArray();
            char[] arrayS2 = s2.ToArray();

            for (int i = 1; i <= s1Length; i++)
            {
                int prev = 0;
                for (int j = 1; j <= s2Length; j++)
                {
                    int temp = array[j];
                    if (arrayS1[i-1] == arrayS2[j-1]) 
                    {
                        array[j] = prev + 1;
                    }
                    else
                    {
                        array[j] = Math.Max(array[j], array[j - 1]);
                    }
                    prev = temp;
                }
            }
            return array[s1Length];
        }
         
    }
}
