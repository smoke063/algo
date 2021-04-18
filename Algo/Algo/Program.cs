using System;
using System.Diagnostics;
using System.Globalization;

namespace Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Простое число
            Console.WriteLine("2 " + IsPrimeNumber(2));
            Console.WriteLine("3 " + IsPrimeNumber(3));
            Console.WriteLine("4 " + IsPrimeNumber(4));
            Console.WriteLine("5 " + IsPrimeNumber(5));
            Console.WriteLine("6 " + IsPrimeNumber(6));
            Console.WriteLine("7 " + IsPrimeNumber(7));
            Console.WriteLine("11 " + IsPrimeNumber(11));
            Console.WriteLine("12 " + IsPrimeNumber(12));
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Фибоначи через рекурсию
            for (int i = 0; i < 40; i++)
            {
                CountRec = 0;
                Console.WriteLine($"Fib Recursive ({i}) = {FibRecursive(i)} CountRec = {CountRec}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Фибоначи без рекурсии
            for (int j = 0; j < 40; j++)
            {
                CountFor = 0;
                Console.WriteLine($"Fib For ({j}) = {FibFor(j)} CountFor = {CountFor}");
            }

            Console.ReadKey();
        }

        private static int CountFor = 0;
        private static int CountRec = 0;

        static int FibFor(int n)
        {
            CountFor++;

            int a0 = 0;
            int a1 = 1;
            int t = 0;
            for (int i = 1; i < n; i++)
            {
                CountFor++;
                t = a0 + a1;
                a0 = a1;
                a1 = t;
            }

            return n switch
            {
                0 => 0,
                1 => 1,
                _ => t
            };
        }

        static int FibRecursive(int n)
        {
            CountRec++;

            if (n == 0) return 0;
            if (n == 1) return 1;

            return FibRecursive(n - 1) + FibRecursive(n - 2);
        }

        static bool IsPrimeNumber(int n)
        {
            int d = 0;
            int i = 2;

            while (i < n)
            {

                if (n % i == 0)
                {
                    d++;
                }

                i++;

            }

            return d == 0;
        }
    }
}
