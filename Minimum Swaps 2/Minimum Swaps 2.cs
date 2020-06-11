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

class Solution {

    // Complete the minimumSwaps function below.
    static int minimumSwaps(ref int[] arr) {
        int count = 0;
        int minimum;
        for (int i = 0; i < arr.Length; i++){
            int[] arrTemp = new int[arr.Length - i];
            Array.Copy(arr, i, arrTemp, 0, arr.Length - i);
            minimum = min(arrTemp);
            if (minimum < arr[i]) {
                int temp = arr[i];
                arr[i] = arr[Array.IndexOf(arr, minimum)];
                arr[Array.IndexOf(arrTemp, minimum)+i] = temp;
                count++;
            }
        }
        return count;
    }
    static int min (int[] ar){
        int min = ar[0];
        for (int i = 1; i < ar.Length; i++){
            min = Math.Min(min, ar[i]);
        }
        return min;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = minimumSwaps(ref arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
