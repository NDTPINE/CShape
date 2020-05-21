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

    // Complete the getMinimumCost function below.
    static int getMinimumCost(int numFriend, int[] cost) {
        Array.Sort(cost);
        int sum = 0;
        int index = 0;
        int temp = 0;
        if (cost.Length <= numFriend){
            for (int m = 0; m < cost.Length; m++){
                sum+= cost[m];
            }
        } else {
            for (int i = cost.Length - 1; i >= 0; i--){
                if (temp == numFriend){
                    index++;
                    temp = 0;
                }
                sum += (index + 1)*cost[i];
                temp++;
            }
        }
        return sum;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int minimumCost = getMinimumCost(k, c);

        textWriter.WriteLine(minimumCost);

        textWriter.Flush();
        textWriter.Close();
    }
}
