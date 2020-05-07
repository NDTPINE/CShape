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

    // Complete the gameOfThrones function below.
    static string gameOfThrones(string s) {
        string result;
        int[] arrChar = new int[26];
        int count = 0;
        if (s.Length == 1) return "NO";
        for (int i = 0; i < s.Length; i++){
            arrChar[Convert.ToInt16(s[i] - 97)]++;
        }
        for (int j = 0; j < 26; j++){
            if (arrChar[j] !=0){
                if (arrChar[j] % 2 != 0) count++;
            }
        }
        if (s.Length % 2 == 0) {
            if (count > 0) result = "NO";
            else result = "YES";
        } else {
            if (count < 2) result = "YES";
            else result = "NO";
        }
        return result;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = gameOfThrones(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
