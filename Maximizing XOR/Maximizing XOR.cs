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
        /* Use MSF to resolve the problem*/
        int value = l ^ r;
        int result = 1;
        while (value >0) {
            value = value >> 1;
            result = result << 1;
        }
        return result - 1;

        /* TIME OUT 4 test case
        int result;
        int index = 0;
        int max = 0;
        for (int q = l; q <= r; q++){
            int[] bin1 = convertToDecToBin(q);
            for (int p = l; p <= r; p++){
                int[] bin2 = convertToDecToBin(p);
                int[] bin3 = bin2;
                for(int m = 0; m < 10; m++){
                    bin3[m] = bin1[m] ^ bin2[m];
                }
                max = Math.Max(max,convertToBinToDec(bin3));
            }
        }
        return result = max;*/
    }
    public static int[] convertToDecToBin(int number){
        int[] arr = new int[10];       
        for(int i = 0; number > 0; i++){      
            arr[i] = number % 2;      
            number= number/2;    
        }
        Array.Reverse(arr);
        return arr;
    }
    public static int convertToBinToDec(int[] arr){
        double dec = 0;
        int i = 0;
        int d;
        string temp = "";
        for (int j = 0; j < arr.Length; j++){
            temp = string.Concat(temp,arr[j].ToString());
        }
        int number = Convert.ToInt32(temp);
        while (number != 0){
            d = number % 10;
            dec = dec + d * (int)Math.Pow(2, i); // su dung ham trong C#
            number = number / 10;
            i++;
        }
        return (int)dec;
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
