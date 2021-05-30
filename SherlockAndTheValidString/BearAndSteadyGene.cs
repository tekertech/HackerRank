using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SherlockAndTheValidString
{
    public static class BearAndSteadyGene
    {
		/*
         * Complete the 'steadyGene' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING gene as parameter.
         * Source : https://gist.github.com/jianminchen/0892107fc0f6b6bec7a0
         * Source : https://stackoverflow.com/questions/37579917/find-the-shortest-substring-whose-replacement-makes-the-string-contain-equal-num
         */

		public static int steadyGene(string gene)
        {
			int length = gene.Length;
			int max = length / 4;
			string constantString = "ACGT";
			bool startProcess = false;


			int[] frequenceCount = new int[100];

			foreach (char c in gene) {
				frequenceCount[c]++;
			}


			foreach (char c in constantString) {
				if (frequenceCount[c] > max) {
					startProcess = true;
					break;
				}
			}

			if (!startProcess)
				return 0;

			int index = 0;
			int result = length;

			for (int left = 0; left < length; left++)
			{
				while (frequenceCount['A'] > max || frequenceCount['C'] > max || frequenceCount['T'] > max || frequenceCount['G'] > max)
				{
					if (index == length)
					{
						return result;
					}

					--frequenceCount[gene[index]];
					++index;
				}
				result = Math.Min(result, index - left);
				++frequenceCount[gene[left]];
			}

			return result;
        }
    }
}
