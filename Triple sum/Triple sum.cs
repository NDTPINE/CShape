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

    // Complete the triplets function below.
    static long triplets(int[] a, int[] b, int[] c) {
        long count = 0;
        Array.Sort(a);
        Array.Sort(b);
        Array.Sort(c);
        int i = 0;
        for (i = 1; i < b.Length ; i++){
            if (b[i] == b[i -1]) b[i -1] = 0;
        }
        int q = 0;
        int p = 0;
        int r = 0;
        while (q < b.Length){
            while (p < a.Length && b[q] >= a[p]){
                p++;
            }
            while (r < c.Length && b[q] >= c[r]){
                r++;
            }
        count += p*r;
        q++;
        r = 0;
        p = 0;
        }
        return count;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] lenaLenbLenc = Console.ReadLine().Split(' ');

        int lena = Convert.ToInt32(lenaLenbLenc[0]);

        int lenb = Convert.ToInt32(lenaLenbLenc[1]);

        int lenc = Convert.ToInt32(lenaLenbLenc[2]);

        int[] arra = Array.ConvertAll(Console.ReadLine().Split(' '), arraTemp => Convert.ToInt32(arraTemp))
        ;

        int[] arrb = Array.ConvertAll(Console.ReadLine().Split(' '), arrbTemp => Convert.ToInt32(arrbTemp))
        ;

        int[] arrc = Array.ConvertAll(Console.ReadLine().Split(' '), arrcTemp => Convert.ToInt32(arrcTemp))
        ;
        long ans = triplets(arra, arrb, arrc);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
