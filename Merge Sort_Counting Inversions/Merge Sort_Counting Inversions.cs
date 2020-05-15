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

        // Complete the countInversions function below.
        static long countInversions(int[] arr) {
            long count = 0;
            for (int i = 0; i < arr.Length -1; i++){
                for ( int j = i + 1; j < arr.Length; j++){
                    if (arr[j] < arr[i]){
                        swap(ref arr[j], ref arr[i]);
                        count++;
                    }
                }
            }
            return count;
        }
        static void swap (ref int a, ref int b){
            int temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args) {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++) {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
                ;
                long result = countInversions(arr);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
