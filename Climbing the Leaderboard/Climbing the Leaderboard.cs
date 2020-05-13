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

    // Complete the climbingLeaderboard function below.
    static int[] climbingLeaderboard(int[] scores, int[] alice) {
        int[] result = new int[alice.Length];
        int[] rank = new int[scores.Length];
        int temp = scores[0];
        int pointrank = 1;
        for (int i = 0; i < scores.Length;i++){
            if (scores[i] == temp) rank[i] = pointrank;
            else {
                pointrank++;
                temp = scores[i];
                rank[i] = pointrank;
            }
        }
        int mid = scores.Length/2;
        for (int m = 0; m < alice.Length; m++){
            if (alice[m] < scores[scores.Length - 1]){
                result[m] = rank[scores.Length -1 ] +1;
            } else if ( alice[m] > scores[0]){
                result[m] = rank[0];
            } else {
                if (alice[m] > scores[mid]){
                    for(int j = 0; j <= mid; j++){
                        if (alice[m] >= scores[j]){
                            result[m] = rank[j];
                            break;
                        }
                    }
                } else {
                    for(int n = mid; n <scores.Length; n++){
                        if (alice[m] >= scores[n]){
                            result[m] = rank[n];
                            break;
                        }
                    }
                }
                
            }
        }
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int scoresCount = Convert.ToInt32(Console.ReadLine());

        int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
        ;
        int aliceCount = Convert.ToInt32(Console.ReadLine());

        int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp))
        ;
        int[] result = climbingLeaderboard(scores, alice);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
