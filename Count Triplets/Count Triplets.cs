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

    // Complete the countTriplets function below.
    static long countTriplets(List<long> arr, long r, long n) {
        // if (r == 1) {
        //     long temp = n*(n-1)*(n-2)/6;
        //     return temp;
        // }
        long count = 0;
        arr.Sort();
        List<bool> checkArray = new List<bool>();
        for (int i = 0; i < n - 2; i++){
            for (int j = i+1; j < n - 1; j++){
                for (int m = j+1; m < n; m++){
                    if (check(arr[i], arr[j], arr[m],r)){
                        checkArray.Add(true);
                    }
                }
            }
        }
        count = checkArray.Count;
        return count;
    }
    public static bool check(long a, long b, long c, long r){
        if ((long)Math.Pow(b,2) == (long)a*c && (c/b == r)) return true;
        return false;
    }
        

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().Trim().Split(' ');

        long n = Convert.ToInt64(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().Trim().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r, n);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
