using System;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace QuantumRandomGenerator
{
    public static class QuantumRand
    {
        public static bool NextBoolean()
        {
            using (var qsim = new QuantumSimulator())
            {
                return Quantum.QuantumRandomGenerator.NextBoolean.Run(qsim, Result.Zero).Result;
            }
        }

        public static long Next(long min, long max)
        {
            if(min>max)throw new ArgumentOutOfRangeException();
            if (min == max) return min;

            using (var qsim = new QuantumSimulator())
            {
                return Quantum.QuantumRandomGenerator.Next.Run(qsim, Result.Zero, min, max).Result;
            }
        }
    }
}
