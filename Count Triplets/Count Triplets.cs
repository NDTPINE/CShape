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
        Dictionary<long, long>  ht2 = new Dictionary<long, long>();
        Dictionary<long, long>  ht3 = new Dictionary<long, long>();
        long count = 0;
        foreach (long val in  arr){
            if (ht3.ContainsKey(val)){
                count+= ht3[val];
            }
            if (ht2.ContainsKey(val)){
                if (ht3.ContainsKey(val*r)){
                    ht3[val*r] += ht2[val];
                }else {
                    ht3[val*r] = ht2[val];
                }
            } 
            if (ht2.ContainsKey(val*r)){
                ht2[val*r]++;
            } else ht2[val*r] = 1;
        }
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
