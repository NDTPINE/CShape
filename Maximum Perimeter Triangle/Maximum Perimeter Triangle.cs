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

    // Complete the maximumPerimeterTriangle function below.
    static int[] maximumPerimeterTriangle(int[] sticks) {
        int[] result = new int[3];
        Array.Sort(sticks);
        int i = sticks.Length - 3;
        while (i >= 0 && sticks[i] + sticks[i+1] <= sticks[i+2]){
            i-=1;
        }
        if (i >= 0) {
            result[0] = sticks[i];
            result[1] = sticks[i+1];
            result[2] = sticks[i+2];
        } else {
            result[0] = -1;
            Array.Resize(ref result, 1);
        }
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] sticks = Array.ConvertAll(Console.ReadLine().Split(' '), sticksTemp => Convert.ToInt32(sticksTemp))
        ;
        int[] result = maximumPerimeterTriangle(sticks);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
