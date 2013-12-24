using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphsLoops
{
    class Program
    {
        static int[,] baseGraph = new int[4, 4]
        {
            {0,0,1,1},
            {0,0,1,1},
            {1,1,0,1},
            {1,1,1,0}
        };

        static List<int> skeleton = new List<int>();
        static int[] colors = new int[4];


        static void DFS(int currentVertex)
        {
            skeleton.Add(currentVertex);
            colors[currentVertex - 1] = 1;
            for (int i = 1; i < 5; i++)
            {
                if (baseGraph[currentVertex - 1, i - 1] == 1 && colors[i - 1] == 0)
                {
                    DFS(i);
                }
            }
            colors[currentVertex - 1] = 2;
        }


        static void Loops()
        {
            for (int i = 1; i < 5; i++)
            {
                int currentVertex = skeleton[i];
                for (int j = 0; j < 4; j++)
                {
                    if (baseGraph[currentVertex - 1, j] == 1 && j != skeleton[i - 1] - 1 && j != skeleton[i + 1] - 1 && j < currentVertex - 1)
                    {
                        for (int k = 1; k < 6; k++)
                        {
                            if (skeleton[k] == j + 1)
                            {
                                for (int m = k; m <= i; m++)
                                {
                                    Console.Write(skeleton[m]);
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            skeleton.Add(-1);
            DFS(1);
            skeleton.Add(-1);
            Loops();
        }
    }
}
