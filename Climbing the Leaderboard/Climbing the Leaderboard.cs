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
        rank[0] = 1;
        for (int i = 1; i< scores.Length; i++){
            if (scores[i] == scores[i-1]){
                rank[i] = rank[i-1];
            } else rank[i] = rank[i-1] + 1;
        }
        int star = 0;
        int end = scores.Length -1;
        for (int j = 0;j < alice.Length;j++){
            int temp = binarySearch(scores, rank, star,end,alice[j]);
            result[j] = temp;
        }
        return result;
    }
    public static int binarySearch(int[] score, int[] rank,int star, int end, int news){
        int mid = (star + end)/2;
        if (star == end){
            if (news >= score[star]) return rank[star];
            else return rank[star] + 1;
        } else if (news >score[mid]){
            return binarySearch(score, rank, star, Math.Max(mid -1, 0), news);
        } else if(news < score[mid]) {
            return binarySearch(score, rank, Math.Min(mid+1, score.Length - 1), end, news);
        } else return rank[mid];
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
