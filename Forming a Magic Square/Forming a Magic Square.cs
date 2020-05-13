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

    // Complete the formingMagicSquare function below.
    static int formingMagicSquare(int[][] s) {
        int result = 0;
        int[][] arr = new int[8][]{
            new int[] {8,1,6,3,5,7,4,9,2},
            new int[] {6,8,1,7,5,3,2,9,4},
            new int[] {2,7,6,9,5,1,4,3,8},
            new int[] {4,3,8,9,5,1,2,7,6},
            new int[] {2,9,4,7,5,3,6,1,8},
            new int[] {4,9,2,3,5,7,8,1,6},
            new int[] {8,3,4,1,5,9,6,7,2},
            new int[] {6,7,2,1,5,9,8,3,4}
        };
        int index = 0;
        int[] sum = new int[8];
        int min;
        int temp = 0;
        for (int i = 0 ; i < 8; i++){
            for (int m = 0 ; m < 3; m++){
                for(int n = 0 ; n < 3; n++){
                    sum[index] += Math.Abs(arr[i][temp] - s[m][n]);
                    temp++;
                }
            }
        temp = 0;
        index++;
        }
        min = sum[0];
        for (int j = 1; j <sum.Length; j++){
            if (min >= sum[j]) min = sum[j];
        }
        return min;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] s = new int[3][];

        for (int i = 0; i < 3; i++) {
            s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
        }

        int result = formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
