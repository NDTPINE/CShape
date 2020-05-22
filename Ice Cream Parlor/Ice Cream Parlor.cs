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
    static void icecreamParlor(int m, int[] arr) {
        int[] buyIce = new int[2]{0,0};
        Dictionary<int, int > map = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++){
            int target = m - arr[i];
            if (map.ContainsKey(target)){
                buyIce[0] = map[target];
                buyIce[1] = i+1;
                break;
            }
            map.Add(arr[i], (i+1));
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
