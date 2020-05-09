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

    // Complete the toys function below.
    static int toys(int[] w) {
        Array.Sort(weight);
        int check = weight[0];
        int count = 1;
        for (int i  = 1; i < weight.Length; i++){
            if (weight[i] == check) weight[i] = 0;
            if (weight[i] > check + 4){
                check = weight[i];
                count++;
            }
        }
        return count;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] w = Array.ConvertAll(Console.ReadLine().Split(' '), wTemp => Convert.ToInt32(wTemp))
        ;
        int result = toys(w);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
