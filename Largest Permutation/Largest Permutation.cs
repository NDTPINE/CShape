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

    // Complete the largestPermutation function below.
    static int[] largestPermutation(int k, int[] arr) {
        int[] b = new int[arr.Length];
        for (int i = 0; i < arr.Length;i++){
            b[arr[i] - 1] = i;
        }
        int j = 0;
        while(k > 0 && j < arr.Length){
            if(arr[j] != arr.Length - j){
                int pos = b[arr.Length - j - 1];
                int temp = arr[j];
                swap (ref arr[j], ref arr[pos]);
                b[arr.Length -  j - 1] = j;
                b[temp - 1] = pos;
                k--;
            }
        j++;
    }
    return arr;
    }

    public static void swap(ref int a,ref int b){
        int temp = a;
        a = b;
        b = temp;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int[] result = largestPermutation(k, arr);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
