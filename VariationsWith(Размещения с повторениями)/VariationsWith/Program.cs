using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VariationsWith
{
    class Program
    {
        
        static int[] GetNext(int[] current, int k)
        {
            bool flag = true;
            int position = current.Length - 1;
            while (position >= 0 && flag)
            {
                if (current[position] == k - 1)
                {
                    current[position] = 0;
                    position--;
                }
                else
                {
                    current[position]++;
                    flag = false;
                }
                
            }
            return current;
        }
        static void Main(string[] args)
        {
            int[] next = GetNext(new int[] {1, 3, 6, 5, 9}, 10);
            foreach (var elem in next)
            {
                Console.Write(elem);
            }
            Console.WriteLine();

        }
    }
}
