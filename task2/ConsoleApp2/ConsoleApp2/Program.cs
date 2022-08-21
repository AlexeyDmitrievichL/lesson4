using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = GetRowsCount();
            int columnsCount = GetColumnsCount();

            sbyte[,] matrix = new sbyte[rowsCount, columnsCount];

            FillMatrix(ref matrix);
            DisplayMatrix("Matrix", ref matrix);
            CalculateMatrixParams(ref matrix);
            RevertMatrix(ref matrix);

            Console.ReadKey();
        }

        private static int GetRowsCount()
        {
            Console.WriteLine("Set count of rows:");
            int rowsCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return rowsCount;
        }

        private static int GetColumnsCount()
        {
            Console.WriteLine("Set count of columns:");
            int columnsCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return columnsCount;
        }

        private static void FillMatrix(ref sbyte[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;
            Random randm = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sbyte nextValue = (sbyte)randm.Next(-100, 100);
                    matrix[i,j] = nextValue;
                }
            }
        }

        private static void DisplayMatrix(in string title, ref sbyte[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;
            Console.WriteLine($"{title}:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void CalculateMatrixParams(ref sbyte[,] matrix)
        {
            sbyte min = matrix[0,0];
            sbyte max = matrix[0,0];
            int sum = 0;
            foreach (sbyte i in matrix)
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
                sum += i;
            };
            float arMean = (float)sum / matrix.Length;
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Arithmetic mean: {arMean}");
            Console.WriteLine();
        }

        private static void RevertMatrix( ref sbyte[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.Length / rows;
            int matrixLength = rows * columns;
            sbyte[] array = new sbyte[matrixLength];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i * columns + j] = matrix[i, j];
                }
            }

            List<int> excludedIndexes = new List<int>(matrixLength);
            for (int i = 0; i < array.Length; i++)
            {
                int indexOfMax = 0;
                sbyte max = array[0];
                for (int j = 0; j < array.Length; j++)
                {
                    if (excludedIndexes.Exists(ei => ei == j))
                      continue;

                    max = array[j];
                    break;
                }
                for (int j = 0; j < array.Length; j++)
                {
                    if (excludedIndexes.Exists(ei => ei == j))
                        continue;

                    if (array[j] >= max)
                    {
                        max = array[j];
                        indexOfMax = j;
                    }
                }
                excludedIndexes.Add(indexOfMax);
            }
            sbyte[] sortedArray = new sbyte[matrixLength];
            for (int i = 0; i < excludedIndexes.Count; i++)
            {
                sortedArray[i] = array[excludedIndexes[i]];
            }

            sbyte[,] sortedMatrix = new sbyte[rows, columns];
            for (int i = 0; i < rows; i ++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sortedMatrix[i, j] = sortedArray[i * columns + j];
                }
            }
            DisplayMatrix("Sorted matrix", ref sortedMatrix);
        }
    }
}
