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
     * Complete the 'formingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */


    // --- This is the solution to the problem of forming a magic square from a given 3x3 matrix. ---
    // --- The solution is based on the fact that there are only 8 possible magic squares of 3x3. ---
    // --- The the is calculated by summing the differences between the elements of the given matrix with each of the 8 magic squares's elements. ---
    // --- The minimum cost is returned as the result. ---
    public static int formingMagicSquare(List<List<int>> s)
    {
        // Initialize the 8 magic squares as List<List<int>> (2D matrices)
        List<List<List<int>>> magicSquares = new List<List<List<int>>>()
        {
            new List<List<int>> { new List<int> { 2, 7, 6 }, new List<int> { 9, 5, 1 }, new List<int> { 4, 3, 8 } },
            new List<List<int>> { new List<int> { 4, 3, 8 }, new List<int> { 9, 5, 1 }, new List<int> { 2, 7, 6 } },
            new List<List<int>> { new List<int> { 6, 1, 8 }, new List<int> { 7, 5, 3 }, new List<int> { 2, 9, 4 } },
            new List<List<int>> { new List<int> { 8, 3, 4 }, new List<int> { 1, 5, 9 }, new List<int> { 6, 7, 2 } },
            new List<List<int>> { new List<int> { 2, 9, 4 }, new List<int> { 7, 5, 3 }, new List<int> { 6, 1, 8 } },
            new List<List<int>> { new List<int> { 4, 9, 2 }, new List<int> { 3, 5, 7 }, new List<int> { 8, 1, 6 } },
            new List<List<int>> { new List<int> { 6, 7, 2 }, new List<int> { 1, 5, 9 }, new List<int> { 8, 3, 4 } },
            new List<List<int>> { new List<int> { 8, 1, 6 }, new List<int> { 3, 5, 7 }, new List<int> { 4, 9, 2 } }
        };


        int minCost = int.MaxValue;
        int currCost = 0;
        
        foreach(var sqr in magicSquares)
        {
            for(int i=0; i<3; i++)
            {
                for(int j=0; j<3; j++)
                {
                    int n = Math.Abs(s[i][j] - sqr[i][j]);
                    currCost = currCost + n;
                }
            }
            
            if (minCost > currCost) minCost = currCost;
            currCost = 0;
        }

        return minCost;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }

        int result = Result.formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
