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
     * Complete the 'surfaceArea' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY A as parameter.
     */

    public static int surfaceArea(List<List<int>> A)
    {
        int rows = A.Count;
        int cols = A[0].Count;
        int totalSurfaceArea = 0;

        // Direction offsets for neighboring cells: (rowOffset, colOffset)
        int[] dRow = { -1, 1, 0, 0 }; // Up, Down
        int[] dCol = { 0, 0, -1, 1 }; // Left, Right

        // We go over each cell
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // Initialize it's height
                int height = A[row][col];
                
                // Add top and bottom surfaces, since they're always visible on the toy.
                totalSurfaceArea += 2;

                // Check all four sides of the current coordinate.
                for (int i = 0; i < 4; i++)
                {
                    int newRow = row + dRow[i];
                    int newCol = col + dCol[i];
                    
                    // If neighbor exists on current side:
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                    {
                        // Add the difference in height if positive.
                        // This prevents duplicating heights when looking at a higher neighbour.
                        totalSurfaceArea += Math.Max(0, height - A[newRow][newCol]);
                    }
                    else
                    {
                        // No neighbor on the current side, add this coordinate's full height.
                        totalSurfaceArea += height;
                    }
                }
            }
        }

        return totalSurfaceArea;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int H = Convert.ToInt32(firstMultipleInput[0]);

        int W = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> A = new List<List<int>>();

        for (int i = 0; i < H; i++)
        {
            A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
        }

        int result = Result.surfaceArea(A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}