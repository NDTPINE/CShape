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
using System.Numerics;
using System;


class Solution {

    // Complete the extraLongFactorials function below.
    static void extraLongFactorials(int n) {
        BigInteger number = new BigInteger(1);
        for (int i = 2; i < n+1; i++){
            number = BigInteger.Multiply(number,i);
        }
        if (n < 2) Console.WriteLine("{0}", 1);
        else Console.WriteLine("{0}",number);
    }

    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());

        extraLongFactorials(n);
    }
}
