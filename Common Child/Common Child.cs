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

    // Complete the commonChild function below.
    static int commonChild(string s1, string s2) {
        int len = 0;
        s1 = String.Concat(" ", s1.Substring(0));
        s2 = String.Concat(" ", s2.Substring(0));
        int[,] arr = new int[s1.Length,s2.Length];
        int start = 1;
        int len1 = s1.Length -1;
        int len2 = s2.Length -1;
        while (start <= len1 && start <= len2 && s1[start] == s2[start]){
            start++;
            len++;
        }
        while (start <= len1 && start <= len2 && s1[len1] == s2[len2]){
            len1--;
            len2--;
            len++;
        }
        
        for (int i = start; i <= len1; i++){
            for (int j = start; j <= len2; j++){
                if (s1[i] == s2[j]){
                    arr[i,j] = arr[i -1, j -1] +1;
                } else {
                    arr[i,j] = Math.Max(arr[i, j -1],arr[i -1,j]);
                }
            }
        }
        len += arr[len1, len2];
        return len;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = commonChild(s1, s2);
        
        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
