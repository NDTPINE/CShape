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

    // Complete the icecreamParlor function below.
    static int[] icecreamParlor(int m, int[] arr) {
        int[] buyIce = new int[2]{0,0};
        
        var ice = new Hashtable();
        for (int i = 0; i < arr.Length; i++){
            ice.Add(i+1, Array.IndexOf(arr, m - arr[i],i+1)+1);
        }
        foreach(DictionaryEntry hash in ice){
            if (Convert.ToInt32(hash.Value) != 0 && buyIce[0] == 0){
                buyIce[1] = Convert.ToInt32(hash.Value);
                buyIce[0] = Convert.ToInt32(hash.Key);
            }
        }
        return buyIce;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int m = Convert.ToInt32(Console.ReadLine());

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            int[] result = icecreamParlor(m, arr);

            textWriter.WriteLine(string.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
