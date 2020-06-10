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

    // Complete the timeInWords function below.
    static string timeInWords(int h, int m) {
        string result = "";
        string[] hour = new string[]{"one","two","three","four","five","six","seven","eight","nine","ten","eleven","twelve"};
        string[] minutes = new string[]{"one","two","three","four","five","six","seven","eight","nine","ten","eleven","twelve","thirteen","fourteen","0","sixteen","seventeen","eightteen","nineteen","twenty","twenty one","twenty two","twenty three","twenty four","twenty five","twenty six","twenty senven","twenty eight","twenty nine"};
        switch (m){
            case 00:
                string temp00 = " o\' clock";
                result = hour[h -1] + temp00;
                break;
            case 15:
                string temp15 = "quarter past ";
                result = temp15 + hour[h -1];
                break;
            case 30: 
                string temp30 = "half past ";
                result = temp30 + hour[h -1];
                break;
            case 45:
                string temp45 = "quarter to ";
                result = temp45 + hour[h];
                break;
            case 1:
                result = minutes[m -1] + " minute past " + hour[ h - 1];
                break;
        }
        if (m > 1 && m < 30 && m != 15){
            result = minutes[m - 1] + " minutes past " + hour[ h - 1];
        } else if (m > 30 && m < 60 && m!=45){
            result = minutes[60 - m - 1] + " minutes to " + hour[h];
        }
        return result;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        string result = timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
