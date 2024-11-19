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
     * Complete the 'extraLongFactorials' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void extraLongFactorials(int n)
    {
        int[] result = new int[500];  // Array to store the result, each index holds one digit
        result[0] = 1;                // Start result array with 1 (since 0! = 1)
        int result_size = 1;          // Current size of the result

        // Multiply numbers from 2 to n to calculate the factorial
        for (int curr = 2; curr <= n; curr++)
        {
            result_size = Multiply(curr, result, result_size);
        }

        // Print the final factorial result
        for (int i = result_size - 1; i >= 0; i--)
        {
            Console.Write(result[i]);
        }
        Console.WriteLine();
    }

    // Function to multiply the current number by the result
    static int Multiply(int x, int[] result, int result_size)
    {
        int carry = 0;  // Value to store that carry of the multiplication.

        // Multiply the current number 'x' with each digit in the result array
        for (int i = 0; i < result_size; i++)
        {
            int product = result[i] * x + carry;
            result[i] = product % 10;  // Store the last digit of the product in the result array
            carry = product / 10;      // Carry the remaining value
        }

        // If there is a carry, add it to the result array and increase the result size
        while (carry != 0)
        {
            result[result_size] = carry % 10;
            carry = carry / 10;
            result_size++;
        }

        return result_size;  // Return the updated size of the result
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        Result.extraLongFactorials(n);
    }
}