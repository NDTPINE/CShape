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
        int pos1;
        int pos2;
        string str = "";
        while (s1.Length != 0 && s2.Length != 0){
            pos1 = s1.IndexOf(s2[0]);
            pos2 = s2.IndexOf(s1[0]);
            if (pos1 == -1){
                s2 = s2.Substring(1);
            } else if (pos2 == -1){
                s1 = s1.Substring(1);
            } else if (s1[0] == s2[0]){
                str = String.Concat(str, Convert.ToString(s1[0]));
                s1 = s1.Substring(1);
                s2 = s2.Substring(1);
            } else {
                if (pos1 > pos2 && s1.IndexOf(s2[1]) < pos1){
                    s1 = s1.Substring(1);
                } else if (pos1 < pos2 && s2.IndexOf(s1[1])< pos2){
                    s2 = s2.Substring(1);
                } else if (pos1 < pos2) {
                    s1 = s1.Substring(pos1);
                    str = String.Concat(str,Convert.ToString(s2[0]));
                    s2 = s2.Substring(1);
                } else if (pos1 > pos2){
                    s2 = s2.Substring(pos2);
                    str = String.Concat(str,Convert.ToString(s1[0]));
                    s1 = s1.Substring(1);
                }
            }
        }
        len = str.Length;
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
