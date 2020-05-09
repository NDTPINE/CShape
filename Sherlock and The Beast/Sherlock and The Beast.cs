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

    // Complete the decentNumber function below.
    static void decentNumber(int n) {
        if (n == 1 || n == 2) Console.WriteLine("-1");
        else {
            int numberThree = 1;
            int numberFive = 1;
            StringBuilder s1 = new StringBuilder();
            int intNumber = (int)n/5;
            for (int i = 0; i <= intNumber;i++){
                numberFive = n - (i*5);
                if (numberFive % 3 == 0){
                    numberThree = i*5;
                    break;
                } 
            }
            if (numberFive % 3 != 0 && numberThree % 5 != 0) {
                Console.WriteLine("-1");
            } else{
                for (int j = 0; j < numberFive; j++){
                    s1 = s1.Append("5");
                }
                for (int m = 0; m < n - numberFive; m++){
                    s1 = s1.Append("3");
                }
                Console.WriteLine("{0}", s1);
            }
        }

    }

    static void Main(string[] args) {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++) {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            decentNumber(n);
        }
    }
}
