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
            FullArray(arrayLength, ref array, out max, out min, out sum, out arMean);
            Console.WriteLine($"Array: {String.Join(" ", array)}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Arithmetic mean: {arMean}");
            Console.ReadKey();
        }

        private static int GetArrayLength(out int length)
        {
            Console.WriteLine("Set length of your array, please:");
            length = Convert.ToInt32(Console.ReadLine());
            return length;
        }

        private static void FullArray(
            in int length,
            ref sbyte[] array,
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
                calculateArrayData(i, nextValue, length, ref max, ref min, ref sum, ref arMean);
                array[i] = nextValue;
            }
        }

        private static void calculateArrayData(
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
