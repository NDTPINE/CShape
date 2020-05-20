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
    static long substrCount(int length, string s) {
    long counter = 0;
    for (int i = 0; i < length; i++) {
        //Case 1: aba - if the current symbol is in the middle of palindrome, e.g. aba
        int offset = 1;
        while (i - offset >= 0 && i + offset < length 
            && s[i - offset] == s[i - 1] && s[i + offset] == s[i - 1]) {
            counter++;
            offset++;
        }
        //Case 2: aaaa - if this is repeatable characters aa
        int repeats = 0;
        while (i + 1 < length && Convert.ToInt32(s[i]) == Convert.ToInt32(s[i + 1])) {
            repeats++;
            i++;
        }
        counter += repeats * (repeats + 1) / 2;
    }
    return counter + length;
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
