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

    // Complete the freqQuery function below.
    static List<int> freqQuery(int[,] queries) {
    List<int> result = new List<int>();
    Dictionary<int, int> temp = new Dictionary<int, int>();
    for (int i = 0; i < queries.GetLength(0); i++){
        if (queries[i,0] == 1){
            if (temp.ContainsKey(queries[i,1])){
                temp[queries[i,1]]++;
            } else temp[queries[i,1]] = 1;
        } else  
        if (queries[i,0] == 2){
            if (temp.ContainsKey(queries[i,1])){
                temp[queries[i,1]]--;
            } else temp[queries[i,1]] = 0;
            if (temp[queries[i,1]] <= 0){
                temp.Remove(queries[i,1]);
            }
        } else
        if (queries[i,0] == 3 ){
            if (temp.ContainsValue(queries[i,1])){
                result.Add(1);
            } else result.Add(0);
        }
    }
    return result;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

                var queries = new int[q,2];

                for (int i = 0; i < q; i++)
                {
                    var nq = new int[2];
                    nq = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToArray();
                    queries[i, 0] = nq[0];
                    queries[i, 1] = nq[1];
                }

                List<int> ans = freqQuery(queries);
                textWriter.WriteLine(String.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
