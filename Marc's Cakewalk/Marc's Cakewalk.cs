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

    // Complete the marcsCakewalk function below.
    static long marcsCakewalk(int[] calorie) {
        Array.Sort(calorie);
        long result = 0;
        int index = 0;
        for (int i = calorie.Length - 1; i >= 0; i--){
            result += calorie[i]*(long)Math.Pow(2,index);
            index++;
        }
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] calorie = Array.ConvertAll(Console.ReadLine().Split(' '), calorieTemp => Convert.ToInt32(calorieTemp))
        ;
        long result = marcsCakewalk(calorie);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
