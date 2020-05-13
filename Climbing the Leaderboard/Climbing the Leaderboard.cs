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
        int index = scores[0];
        int count = 0;
        for (int i = 1; i < scores.Length; i++){
            if (scores[i] == index) {
                scores[i] = 0;
                count++;
            } else index = scores[i];
        }
        Array.Sort(scores);
        Array.Reverse(scores);
        Array.Resize(ref scores, scores.Length - count);
    
        index = 0;
        for (int m = 0; m < alice.Length; m++){
            if (alice[m] < scores[scores.Length - 1]){
                result[index] = scores.Length +1;
                index++;
            } else if ( alice[m] > scores[0]){
                result[index] = 1;
                index++;
            }else {
                for(int j = 0; j < scores.Length; j++){
                    if (alice[m] >= scores[j]) {
                        result[index] = j+1;
                        index++;
                        break;
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
