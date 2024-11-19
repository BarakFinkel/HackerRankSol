using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'absolutePermutation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     */

    public static List<int> absolutePermutation(int n, int k)
    {
        List<int> values = new List<int>(new int[n]);
            
        // If k is 0, return the identity permutation (1, 2, ..., n)
        if (k == 0)
        {
            for(int i=0; i < n; i++) values[i] = i+1;
            return values;
        }

        // If n is not divisible by 2k, absolute permutation isn't possible.
        if (n % (2 * k) != 0)
        {
            return new List<int> { -1 };
        }

        for (int i = 0; i < n; i++)
        {
            // Compute the new position based on the pattern
            if ((i / k) % 2 == 0) values[i] = i + k + 1; // If in the first block, move forward k steps
            else values[i] = i - k + 1;                  // If in the second block, move backward k steps
        }

        return values;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> result = Result.absolutePermutation(n, k);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
