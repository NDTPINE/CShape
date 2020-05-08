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

    // Complete the missingNumbers function below.
    static int[] missingNumbers(int[] arr, int[] brr) {
        int[] result = new int[brr.Length - arr.Length];
        int min = arr[0];
        for (int n = 0; n < brr.Length; n++){
            min = Math.Min(min, brr[n]);
        }
        int[] diff = new int[101];
        foreach (int b in brr){
            diff[b - min]++;
        }
        foreach (int a in arr){
            diff[a - min]--;
        }
        int count = 0;
        for(int i = 0; i < 101; i++) {
            if(diff[i] > 0){
                result[count] = min+i;
                count++;
            }
        }
        Array.Resize(ref result, count);
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int m = Convert.ToInt32(Console.ReadLine());

        int[] brr = Array.ConvertAll(Console.ReadLine().Split(' '), brrTemp => Convert.ToInt32(brrTemp))
        ;
        int[] result = missingNumbers(arr, brr);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
