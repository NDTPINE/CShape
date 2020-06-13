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

    // Complete the organizingContainers function below.
    static string organizingContainers(int[][] container) {
        string result1 = "Impossible";
        string result2 = "Possible";
        int[] totalColum = new int[container.GetLength(0)];
        int[] totalRow = new int[container.GetLength(0)];
        for (int i = 0; i < container.GetLength(0); i++){
            for (int j = 0; j < container.GetLength(0); j++){
                totalColum[i] += container[i][j];
                totalRow[j]+= container[i][j];
            }
        }
        for (int m = 0; m < container.GetLength(0); m++){
            if (!Array.Exists(totalColum, element => element == totalRow[m])) return result1;
        }
        return result2;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] container = new int[n][];

            for (int i = 0; i < n; i++) {
                container[i] = Array.ConvertAll(Console.ReadLine().Split(' '), containerTemp => Convert.ToInt32(containerTemp));
            }

            string result = organizingContainers(container);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
