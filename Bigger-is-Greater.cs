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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        List<char> list = w.ToList();

        // Find the first character from the end that's smaller than the next character.
        int right = list.Count - 1;
        while (right > 0 &&  list[right - 1] >= list[right]) right--;
        int i = right - 1;
        
        if(right == 0) return "no answer";   // If no swap is needed, return no answer.         

        // Find the smallest character on the right side of pivot 'i' that is larger
        int j = list.Count - 1;
        while (list[j] <= list[i]) j--;

        // Swap the pivot and the successor
        Swap(list, i, j);

        // Reverse the suffix after the pivot.
        Reverse(list, i + 1);

        return new string(list.ToArray());
    }

    // Swap function (now works with char)
    public static void Swap(List<char> list, int i, int j)
    {
        char temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }

    // Reverse function (returns void, modifies the list in place)
    public static void Reverse(List<char> list, int start)
    {
        int end = list.Count - 1;
        while (start < end)
        {
            Swap(list, start, end);
            start++;
            end--;
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
