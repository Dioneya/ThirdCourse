using System;
using System.Collections.Generic;
using System.Numerics;

namespace VMathLaba1._2
{
    class Program
    {
        public enum FactorialMode
        {
            None,
            Integer,
            Real
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Без изменения формулы {0}", ErrorFucn(3, FactorialMode.None));
            Console.WriteLine("Расчёт факториала с числом целого типа {0}", ErrorFucn(3, FactorialMode.Integer));
            Console.WriteLine("Расчёт факториала с числом вещественного типа {0}", ErrorFucn(3, FactorialMode.Real));
            Console.WriteLine("Расчёт формулы через предыдущий член ряда {0}", ErrorFuncModify(3));
            Console.ReadKey();
        }

        private static int Factorial(int n)
        {
            int factorial = 1;

            if (n == 0)
                return 1;

            for (int i = 1; i <= n; i++)
                factorial *= i;

            return factorial;
        }

        private static double Factorial(double n)
        {
            double factorial = 1;
            try
            {
                if (n == 0)
                    return 1;
                else
                    for (int i = 0; i <= n; i++)
                        factorial *= i;
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            return factorial;
        }

        public static double ErrorFucn(double x, FactorialMode factorialMode)
        {
            double sum = 0;

            for (int n = 0; ; n++)
            {
                double res = Math.Pow(-1, n) * Math.Pow(x, 2 * n + 1) / (factorialMode == FactorialMode.Real ? Factorial((double)n) : Factorial(n) * (2 * n + 1));
                if (double.IsInfinity(res)) break;
                sum += res;
            }

            return 2 / Math.Sqrt(Math.PI) * sum;
        }

        public static double ErrorFuncModify(double x) 
        {
            double sum = 0;
            double prevElem = (-1)*x; // Потому что a(0) = -x т.е. каждый первый элемент будет равным -x

            for (int n = 1; ; n++) 
            {
                double k = GetCoefficient(x,n);
                double res = k * prevElem;
                if (res == 0)
                    break;
                prevElem = res;
                sum += res;
            }

            return 2 / Math.Sqrt(Math.PI) * sum;
        }

        private static double GetCoefficient(double x, int n)
        {
            return (-1)*Math.Pow(x, 2) * (2 * n - 1) / (n*(2*n+1));
        } 

    }
}
