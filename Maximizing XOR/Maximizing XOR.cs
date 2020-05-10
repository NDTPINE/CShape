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

    // Complete the maximizingXor function below.
    static int maximizingXor(int l, int r) {
        int result;
        int[] temp = new int[l*r];
        int index = 0;
        for (int i = 0; i < l; i++){
            for (int j = 0; j < r; j++){
                byte[] value1 = BitConverter.GetBytes(i);
                byte[] value2 = BitConverter.GetBytes(j);
                int check = BitConverter.ToInt32(value1,0);
            }
        }
        result = check;
        return result;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int l = Convert.ToInt32(Console.ReadLine());

        int r = Convert.ToInt32(Console.ReadLine());

        int result = maximizingXor(l, r);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
