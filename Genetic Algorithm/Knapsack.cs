using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    struct Cell
    {
        public int weight;
        public int profit;
    } 
    class Knapsack
    {
        #region Member Variables

        int capacity;
        int iterations;
        double[,] population;
        int popSize;
        int dimension;
        int[] profitArray;
        int[] weightArray;
        int bestFitness;
        Cell[] fitnessArray;
        int[] arr1;
        int[] arr2;

        #endregion

        #region Get & Set Methods
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int PopSize
        {
            get { return popSize; }
            set { popSize = value; }
        }
        public int Dimension
        {
            get { return dimension; }
            set { dimension = value; }
        }
        #endregion

        #region Constrctors
        public Knapsack(int _capacity, int _iterations, int _popSize, int _dimension, int[] _profitArray, int[] _weightArray)
        {
            capacity = _capacity;
            iterations = _iterations;
            popSize = _popSize;
            dimension = _dimension;
            population = new double[popSize, dimension];
            profitArray = _profitArray;
            weightArray = _weightArray;
            fitnessArray = new Cell[popSize];
            bestFitness = 0;
            arr1 = new int[dimension];
            arr2 = new int[dimension];
        }
        #endregion

        #region Methods

        private void CreatePopulation()
        {
            Random getRandom = new Random();
            for (int i = 0; i < popSize; i++)
            {
                for (int k = 0; k < dimension; k++)
                {
                    population[i, k] = getRandom.NextDouble();
                }
            }
            for (int i = 0; i < popSize; i++)
            {
                for (int k = 0; k < dimension; k++)
                {
                    if (population[i, k] >= 0.5 )
                    {
                        population[i, k] = 1;
                    }
                    else
                    {
                        population[i, k] = 0;
                    }
                }
            }
        }
        private void CreateFitnessArray()
        {
            int fitWeight;
            int fitProfit;
            for (int i = 0; i < popSize; i++)
            {
                fitProfit = 0;
                fitWeight = 0;
                for (int j = 0; j < dimension; j++)
                {
                    if(population[i,j] == 1)
                    {
                        fitWeight += weightArray[j];
                        fitProfit += profitArray[j];
                    }
                }
                fitnessArray[i].weight = fitWeight;
                fitnessArray[i].profit = fitProfit;
            }
        }
        private int BestFitness()
        {
            int bestIndividual = 0;
            for (int i = 0; i < popSize; i++)
            {
                if (bestFitness <= this.fitnessArray[i].profit && capacity >= this.fitnessArray[i].weight)
                {
                    bestFitness = fitnessArray[i].profit;
                    bestIndividual = i;
                }
            }
            return bestIndividual;
        }
        private void SelectIndividuals()
        {
            Random getRandom = new Random();
            int x = getRandom.Next(0, popSize - 1);
            int y = BestFitness();
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] =(int) population[y, i];
                arr2[i] = (int)population[x, i];
            }

        }
        private void SelectIndividuals(int[] arr)
        {
            Random getRandom = new Random();
            int x = getRandom.Next(0, popSize - 1);
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = arr[i];
                arr2[i] = (int)population[x, i];
            }
        }
        private int SolutionFitness(int[] arr)
        {
            int currentProfit = 0;
            int currentWeight = 0;
            for (int i = 0; i < dimension; i++)
            {
                if(arr[i] == 1)
                {
                    currentProfit += profitArray[i];
                    currentWeight += weightArray[i];
                }
            }
            if(currentProfit >= bestFitness && currentWeight <= capacity)
            {
                bestFitness = currentProfit;
                SelectIndividuals(arr);
            }
            return currentWeight;          
        }
        
        public int RunKnapsackResult (ref int z)
        {
            this.CreatePopulation();
            this.CreateFitnessArray();
            this.SelectIndividuals();
            int[] solutionArr = new int[dimension];
            int bestCapacity = 0;
            for (int i = 0; i < iterations; i++)
            {
                solutionArr = Genetic_Algorithm.Uniform_Crossover(arr1, arr2);
                Genetic_Algorithm.Swap_Mutation(ref solutionArr);
                z = this.SolutionFitness(solutionArr);
                if(z >= bestCapacity && z <= capacity)
                {
                    bestCapacity = z;
                }
            }
            if(bestCapacity == 0)
            {
                RunKnapsackResult(ref z);
            }
            //Console.WriteLine("Best Capacity : {0}",bestCapacity);

            return bestFitness;
        }

        #endregion
    }
}
