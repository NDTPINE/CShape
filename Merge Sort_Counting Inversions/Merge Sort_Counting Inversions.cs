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
        private static long countInversions(int[] arr) {
        int[] aux = new int[arr.Length];
        Array.Copy(arr,aux, arr.Length);
        return countInversions(arr, 0, arr.Length - 1, aux);
        }

        private static long countInversions(int[] arr, int lo, int hi, int[] aux) {
        if (lo >= hi) return 0;

        int mid = lo + (hi - lo) / 2;

        long count = 0;
        count += countInversions(aux, lo, mid, arr);
        count += countInversions(aux, mid + 1, hi, arr);
        count += merge(arr, lo, mid, hi, aux);

        return count;
    }

    public static long merge(int[] arr, int lo, int mid, int hi, int[] aux) {
        long count = 0;
        int i = lo, j = mid + 1, k = lo;
        while (i <= mid || j <= hi) {
            if (i > mid) {
                arr[k++] = aux[j++];
            } else if (j > hi) {
                arr[k++] = aux[i++];
            } else if (aux[i] <= aux[j]) {
                arr[k++] = aux[i++];
            } else {
                arr[k++] = aux[j++];
                count += mid + 1 - i;
            }
        }

        return count;
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
