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

    // Complete the minimumBribes function below.
    static void minimumBribes(int[] q) {
        int swap = 0;
        int[] stt = new int[q.Length];
        for (int j = 0; j <stt.Length; j++){
            stt[j] = j+1;
        }
        string re = "Too chaotic";
        bool check = true;
        for (int i = 0; i < q.Length; i++){
            if(q[i] - stt[i] > 2) {
                check = false;
                break;
            } else {
                for(int m = Math.Max(0,q[i] - 2); m < i;m++){
                    if (q[m] > q[i]) swap++;
                }
            }
        }
        if (check) Console.WriteLine("{0}",swap);
        else Console.WriteLine("{0}",re);
    }

    static void Main(string[] args) {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
            ;
            minimumBribes(q);
        }
    }
}
