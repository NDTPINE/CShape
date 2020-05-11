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

    // Complete the flippingBits function below.
    static long flippingBits(long n) {
        long result;
        long[] arrTemp = new long[32];
        arrTemp = convertToDecToBin(n);
        for (int j = 0; j < 32; j++){
            if (arrTemp[j] == 0){
                arrTemp[j] = 1;
            } else arrTemp[j] = 0;
        }
        return result = convertToBinToDec(arrTemp);

    }
    public static long[] convertToDecToBin(long number){
        long[] arr = new long[32];       
        for(long i = 0; number > 0; i++){      
            arr[i] = number % 2;      
            number = number/2;    
        }
        //Array.Reverse(arr);
        return arr;
    }
    public static long convertToBinToDec(long[] arr){
        long dec = 0;
        for (long i = 0; i < arr.Length; i++){
            dec += (long)Math.Pow(2,i)*arr[i];
        }
        return (long)dec;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            long n = Convert.ToInt64(Console.ReadLine());

            long result = flippingBits(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
