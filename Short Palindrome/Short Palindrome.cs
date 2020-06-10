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

    // Complete the shortPalindrome function below.
    static int shortPalindrome(string s) {
        int result = 0;
        int index1, index2, index3, index4;
        for (int i = 0; i < s.Length - 3;i++){
            index1 = i;
            for (int j = i+1; j< s.Length - 2;j++){
                index2 = j;
                index3 = s.IndexOf(s[index2],index2+1);
                while (index3 != -1){
                    index4 = s.IndexOf(s[index1],index3+1);
                        while (index4 !=-1){
                            result++;
                            int temp4 = index4+1;
                            index4 = s.IndexOf(s[index1],temp4);
                        }
                    int temp3 = index3+1;
                    index3 = s.IndexOf(s[index2],temp3);
                }
            }
        }
        return result ;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = shortPalindrome(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
