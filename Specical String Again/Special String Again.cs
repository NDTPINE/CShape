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

    // Complete the substrCount function below.
    static long substrCount(int n, string s) {
        long count = 0;
        string tempStr = "";
        string temp = "";
        for (int i = 0; i < n - 1; i++){
            for (int j = i +1 ; j < n; j++){
                       
            }
        }
        count += n;
        return count;

    }
    public static int isPalinedrome(string str){
        int i = 0;
        int j = str.Length - 1;
        char check = str[0];
        while (i < j){
            if (str[i] != str[j] || str[i] != check) {
                return 0;
            }
            i++;
            j--;
        }
        return 1;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        long result = substrCount(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
