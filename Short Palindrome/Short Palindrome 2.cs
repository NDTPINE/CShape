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

    long[] ones = new long[26];
    long[] twos = new long[26 * 26];
    long[] threes = new long[26];
    int n = s.Length;
    long ret = 0;

    for(int i=0;i<n;i++)
    {
        int idx = Convert.ToInt32(s[i]) - 97;
        ret = (ret + threes[idx])%(1000000007);

        for(int j=0;j<26;j++) threes[j]=(threes[j]+twos[j*26+idx])%((1000000007));

        for(int m=0;m<26;m++) twos[m*26+idx]=(twos[m*26+idx]+ones[m])%(1000000007);

        ones[idx]=(ones[idx]+1)%(1000000007);
    }
        return (int)((long)ret % (1000000007));
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
