using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    static class Genetic_Algorithm
    {
        #region Static Methods
        public static void OnePointCrossover(ref int[] _arr1, ref int[] _arr2)
        {
            int size = _arr1.Length;
            Random getRandom = new Random();
            int cross = getRandom.Next(0, size - 1);
            if (cross == size - 1)
            {
                int[] temp = new int[size];
                for (int i = 0; i < _arr1.Length; i++)
                {
                    temp[i] = _arr1[i];
                    _arr1[i] = _arr2[i];
                    _arr2[i] = temp[i];
                }
            }
            else
            {
                int[] temp = new int[size - cross - 1];
                int tempCross = cross;
                tempCross++;
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = _arr1[tempCross++];
                }
                tempCross = 0;
                for (int i = cross + 1; i < _arr1.Length; i++)
                {
                    _arr1[i] = _arr2[i];
                    _arr2[i] = temp[tempCross++];
                }
            }
        }

        public static int TwoPointCrossover(ref int[] arr1, ref int[] arr2, ref int x)
        {
            int size = arr1.Length;
            Random getRandom = new Random();
            int cross1 = getRandom.Next(0, size - 2);
            int cross2 = 0;
            bool flag = false;
            while (flag == false)
            {
                cross2 = getRandom.Next(0, size - 1);
                if (cross2 > cross1)
                    flag = true;
            }
            if ((cross2 - cross1) == 1)
            {
                int temp = arr1[cross2];
                arr1[cross2] = arr2[cross2];
                arr2[cross2] = temp;
            }
            else
            {
                int[] temp = new int[cross2 - cross1];
                int k = cross1 + 1;
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = arr1[k];
                    arr1[k] = arr2[k];
                    arr2[k] = temp[i];
                    k++;
                }
            }
            x = cross2;
            return cross1;

        }

        public static int[] Uniform_Crossover(int[] arr1, int[] arr2)
        {
            int[] temp = new int[arr1.Length];
            Random getRandom = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                if ((getRandom.NextDouble()) >= 0.5)
                {
                    temp[i] = arr2[i];
                }
                else
                {
                    temp[i] = arr1[i];
                }
            }

            return temp;
        }

        public static void Flip_Mutation(ref int[] arr)
        {
            double mutationRate = 1 / (arr.Length - 1);
            Random getRandom = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                if ((getRandom.NextDouble()) <= mutationRate)
                {
                    if (arr[i] == 1)
                    {
                        arr[i] = 0;
                    }
                    else { arr[i] = 1; }
                }
            }
        }

        public static void Swap_Mutation(ref int[] arr)
        {
            int temp = 0;
            Random getRandom = new Random();
            int x = getRandom.Next(0, arr.Length - 1);
            int y = getRandom.Next(0, arr.Length - 1);
            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        #endregion
    }
}
