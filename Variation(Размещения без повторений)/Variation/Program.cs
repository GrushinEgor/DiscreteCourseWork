using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Variation
{
    class Program
    {
        static int[] letters = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


        static int[] GetNext(int[] current)
        {
            List<int> vacant = new List<int>();
            foreach (int elem in letters)
            {
                if (!current.Contains(elem))
                {
                    vacant.Add(elem);
                }
            }

            int j = current.Length - 1;
            while (j >= 0)
            {
                bool flag = false;
                int vacantIndex = 0;
                for (int i = 0; i < vacant.Count - 1; i++)
                {
                    if (vacant[i] > current[j] && !flag)
                    {
                        flag = true;
                        vacantIndex = i;
                    }
                }
                if (!flag)
                {
                    vacant.Add(current[j]);
                    vacant.Sort();
                }
                else
                {
                    current[j] ^= vacant[vacantIndex];
                    vacant[vacantIndex] ^= current[j];
                    current[j] ^= vacant[vacantIndex];
                    int l = j + 1;
                    for (int k = 0; k < current.Length - j - 1; k++)
                    {
                        current[l] = vacant[k];
                        l++;
                    }
                    return current;
                }

                j--;
            }
            return current;
        }

        static void Main(string[] args)
        {
            int[] next = GetNext(new int[]{1,3,6,5,9,8});
            foreach (var elem in next)
            {
                Console.Write(elem);
            }
            Console.WriteLine();
        }
    }
}
