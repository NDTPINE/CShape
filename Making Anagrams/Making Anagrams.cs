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

    // Complete the makingAnagrams function below.
    static int makingAnagrams(string s1, string s2) {
        int count =0;
        int index = -1;
        for (int i = 0; i< s1.Length; i++){
            index = s2.IndexOf(s1[i]);
            if (index != -1){
                count++;
                s2 = s2.Remove(index,1);
            }
        }
        count = s1.Length - count + s2.Length;
        return count;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = makingAnagrams(s1, s2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
