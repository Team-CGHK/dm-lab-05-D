using System;
using System.Collections.Generic;
using System.IO;

namespace DiscreteMAthLab5_D
{
    class Program
    {
        static StreamReader sr = new StreamReader("choose2num.in");
        static StreamWriter sw = new StreamWriter("choose2num.out");

        static void Main(string[] args)
        {
            string[] parts = sr.ReadLine().Split(' ');
            int n = int.Parse(parts[0]),
                k = int.Parse(parts[1]);
            int[] choose = new int[k];
            parts = sr.ReadLine().Split(' ');
            for (int i = 0; i < k; i++)
            {
                choose[i] = int.Parse(parts[i]);
            }
            sw.WriteLine(GetNumByChoose(choose, n, k));
            sw.Close();
        }

        static long GetNumByChoose(int[] choose, int n, int k)
        {
            long result = 0;
            int[] set = new int[n];
            for (int i = 0; i < n; i++)
                set[i] = i+1;
            for (int pos = 0; pos < k; pos++)
            {
                int i;
                for (i = 0; i < set.Length && set[i] < choose[pos]; i++ )
                    result += C(set.Length - i - 1, k - pos - 1);
                int[] nextset = new int[set.Length - i - 1];
                int a = 0;
                for (int j = i+1; j < set.Length; j++)
                    nextset[a++] = set[j];
                set = nextset;
            }
            return result;
        }

        static int indexOf(int what, int[] where)
        {
            int result = -1;
            for (int i = 0; i < where.Length; i++)
                if (where[i] == what) return i;
            return result;
        }

        static long C(int n, int k)
        {
            double divident = 1;
            int j = 2;
            for (int i = 0; i < k; i++)
            {
                divident *= n - i;
                if (j <= k) divident /= j++;
            }
            for (; j <= k; j++)
                divident /= j++;
            return (long)Math.Round(divident);
        }
    }
}
