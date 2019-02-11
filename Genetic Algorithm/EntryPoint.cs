using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    class EntryPoint
    {
        public static void Main()
        {
            int[] profitArr = new int[] { 55, 10, 47, 5, 4, 50, 8, 61, 85, 87 };
            int[] weightArr = new int[] { 95, 4, 60, 32, 23, 72, 80, 62, 65, 46 };
            Knapsack k = new Knapsack(269, 50, 20, 10, profitArr, weightArr);
            int y = 0;
            int x = k.RunKnapsackResult(ref y);
            Console.WriteLine("The Maximum Profit : {0}", x);
            Console.WriteLine("Capacity of Maximum Profit : {0}", y);

            Console.ReadLine();
        }

        



        


    }
}
