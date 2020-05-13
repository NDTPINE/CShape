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
        for (int m = 0; m < alice.Length; m++){
            result[m] = rank2(scores,alice[m]);
        }
        return result;
    }
    public static int rank2(int[] scores, int number){
        if (number > scores[0]) return 1;
        int count = 0;
        int temp2 = scores[0];
        for (int j = 1; j < scores.Length; j++){
            if (scores[j] == temp2) {
                count++;
            } else temp2 = scores[j];
        }
        if (number < scores[scores.Length - 1]) return scores.Length - count +1;
        Array.Resize(ref scores, scores.Length + 1);
        scores[scores.Length - 1] = number;
        Array.Sort(scores);
        Array.Reverse(scores);
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
        return rank[Array.IndexOf(scores,number)];
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
