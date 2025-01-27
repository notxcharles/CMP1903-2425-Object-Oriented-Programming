using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_01_27_Workshop_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] random_integers = GenerateRandomIntegers();
            
            foreach (int integer in random_integers)
            {
                Console.WriteLine(integer);
            }

            int[] array = {1, 2, 3};
            int total_sum = ComputeSum(array);
            Console.WriteLine(total_sum);
            return;
        }
        static int[] GenerateRandomIntegers()
        {
            Random random = new Random();
            int[] random_integers = new int[100];
            for (int i = 0; i < 100; i++)
            {
                random_integers[i] = random.Next();
            }
            return random_integers;
        }

        static int ComputeSum(int[] array)
        {
            int total = 0;
            foreach (int integer in array)
            {
                total += integer;
            }
            return total;
        }
    }
}

