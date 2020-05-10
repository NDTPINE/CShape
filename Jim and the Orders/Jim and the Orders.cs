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

    // Complete the jimOrders function below.
    static int[] jimOrders(int[][] orders) {
		int[] result = new int[orders.Length];
        int[] temp = new int[orders.Length];
        int[] temp2 = new int[orders.Length];
        for (int i= 0; i < orders.Length; i++){
            temp[i] = orders[i][0] + orders[i][1];
            temp2[i] = orders[i][0] + orders[i][1];
        }
        Array.Sort(temp); 
        for (int i = 0; i < orders.Length; i++){
            result[i] = Array.IndexOf(temp2, temp[i]) +1;
            temp2[result[i] - 1] = 0;    
        }
        return result;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[][] orders = new int[n][];

        for (int i = 0; i < n; i++) {
            orders[i] = Array.ConvertAll(Console.ReadLine().Split(' '), ordersTemp => Convert.ToInt32(ordersTemp));
        }

        int[] result = jimOrders(orders);

        textWriter.WriteLine(string.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
