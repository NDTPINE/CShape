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

    // Complete the encryption function below.
    static string encryption(string s) {
        int sq = (int)Math.Sqrt(s.Length);
        int sq1 = (int)sq+1;
        if (sq*(sq1) < s.Length) {
            sq++;
        } else if (sq*sq == s.Length) sq1 = sq;
        string result = "";
        char[,] tempChar = new char[sq,(sq+1)];
        int index = 0;
        for (int i = 0; i< sq; i++){
            for (int j = 0; j < sq1; j++){
                if (index >= s.Length) {
                    tempChar[i,j] = ' ';
                    index++;
                }
                else {
                    tempChar[i,j] = s[index];
                    index++;
                }   
            }
        }
        for (int m = 0; m < sq1; m++){
            for (int n = 0; n < sq; n++){
                if (tempChar[n,m] != ' ') result = result + Convert.ToString(tempChar[n,m]);
            }
            result += " ";
        }
    return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
