using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrayLength;
            sbyte max;
            sbyte min;
            int sum;
            float arMean;
            GetArrayLength(out arrayLength);
            sbyte[] array = new sbyte[arrayLength];
            sbyte[] sortedArray = new sbyte[arrayLength];
            FillArray(arrayLength, ref array, ref sortedArray, out max, out min, out sum, out arMean);
            Console.WriteLine($"Array: {String.Join(" ", array)}");
            Console.WriteLine($"Sorted array: {String.Join(" ", sortedArray)}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Arithmetic mean: {arMean}");
            Console.ReadKey();
        }

        private static void GetArrayLength(out int length)
        {
            Console.WriteLine("Set length of your array, please:");
            length = Convert.ToInt32(Console.ReadLine());
        }

        private static void FillArray(
            in int length,
            ref sbyte[] array,
            ref sbyte[] sortedArray,
            out sbyte max,
            out sbyte min,
            out int sum,
            out float arMean
        )
        {
            max = 0;
            min = 0;
            sum = 0;
            arMean = 0f;
            Random randm = new Random();
            for (int i = 0; i < length; i++)
            {
                sbyte nextValue = (sbyte)randm.Next(-100, 100);
                SortArray(i, nextValue, ref sortedArray);
                calculateArrayInfo(i, nextValue, length, ref max, ref min, ref sum, ref arMean);
                array[i] = nextValue;
            }
        }

        private static void SortArray(in int iteration, in sbyte nextValue, ref sbyte[] sortedArray)
        {
            if (iteration == 0)
            {
                sortedArray[iteration] = nextValue;
            }
            else
            {
                sbyte[] updatedSortedArray = new sbyte[sortedArray.Length];
                if (nextValue >= sortedArray[0])
                {
                    updatedSortedArray[0] = nextValue;
                    for (int j = 1; j < updatedSortedArray.Length; j++)
                    {
                        updatedSortedArray[j] = sortedArray[j - 1];
                    }
                }
                else if (nextValue <= sortedArray[iteration - 1])
                {
                    for (int j = 0; j < updatedSortedArray.Length; j++)
                    {
                        updatedSortedArray[j] = sortedArray[j];
                    }
                    updatedSortedArray[iteration] = nextValue;
                }
                else
                {
                    for (int j = 1; j < sortedArray.Length - 1; j++)
                    {
                        if (nextValue <= sortedArray[j - 1] && nextValue >= sortedArray[j])
                        {
                            for (int k = 0; k < j; k++)
                            {
                                updatedSortedArray[k] = sortedArray[k];
                            }
                            updatedSortedArray[j] = nextValue;
                            for (int k = j + 1; k < sortedArray.Length; k++)
                            {
                                updatedSortedArray[k] = sortedArray[k - 1];
                            }
                        }
                    }
                }
                for (int j = 0; j < updatedSortedArray.Length; j++)
                {
                    sortedArray[j] = updatedSortedArray[j];
                }
            }
        }

        private static void calculateArrayInfo(
            in int iteration,
            in sbyte value,
            in int length,
            ref sbyte max,
            ref sbyte min,
            ref int sum,
            ref float arMean
        )
        {
            if (iteration == 0)
            {
                max = value;
                min = value;
                sum = value;
            }
            else
            {
                max = max >= value ? max : value;
                min = min <= value ? min : value;
                sum += value;
            }
            if (iteration == length - 1)
            {
                arMean = (float)sum / length;
            }
        }
    }
}
