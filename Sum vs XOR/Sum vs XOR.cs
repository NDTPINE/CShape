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

    // Complete the sumXor function below.
    static long sumXor(long n) {
    	// count the number's Zero when convert n to bin
        long c = 0;
            while (n > 0){
                c += n % 2 == 1?0:1;
                n = n / 2; 
            }
        return (long)Math.Pow(2,c);
        
        /* Time out test case*/
        // long count = 0;
        // for (long i = 0; i <= n/2; i++){
        //     if (n + i == (n^i)) count++;
        // }
        // return count;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = sumXor(n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
