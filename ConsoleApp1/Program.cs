using System;
using QuantumRandomGenerator;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(QuantumRand.Next(1, 10000));
            }

            Console.ReadKey();
        }
    }
}
