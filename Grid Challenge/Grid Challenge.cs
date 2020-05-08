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

    // Complete the gridChallenge function below.
    static string gridChallenge(string[] grid) {
        string result = "YES";
        for(int i = 0; i < grid.Length; i++){
            grid[i] = sortString(grid[i]);
        }
        int j = 0;
        int index = 0;
        for (j = 0; j< grid.Length - 1; j++){
            for(index = 0; index < grid[j].Length; index++){
              if (grid[j][index] > grid[j+1][index]) {
                result = "NO";
                break;
              }
            } 
        }
        return result;
    }

    public static string sortString(string s){
        char[] arrChar = s.ToCharArray();
        string result="";
        Array.Sort(arrChar);
        for (int i = 0; i < s.Length; i++){
            result = string.Concat(result, Convert.ToString(arrChar[i]));
        }
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            string[] grid = new string [n];

            for (int i = 0; i < n; i++) {
                string gridItem = Console.ReadLine();
                grid[i] = gridItem;
            }

            string result = gridChallenge(grid);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
