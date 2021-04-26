using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    public struct PointStructFloat
    {
        [ParamsSource(nameof(ValuesX))]
        public float X { get; set; }
        [ParamsSource(nameof(ValuesY))]
        public float Y { get; set; }

        public float[] ValuesX { get; set; }
        public float[] ValuesY { get; set; }

        public void Init()
        {
            Random rnd = new Random();
            int count = 10;

            ValuesX = new float[count];
            ValuesY = new float[count];

            for (int i = 0; i < count; i++)
            {
                ValuesX[i] = GenerateFloat(rnd);
                ValuesY[i] = GenerateFloat(rnd);
            }
        }

        public float GenerateFloat(Random rand)
        {
            var sign = rand.Next(2);
            var exponent = rand.Next((1 << 8) - 1); // do not generate 0xFF (infinities and NaN)
            var mantissa = rand.Next(1 << 23);

            var bits = (sign << 31) + (exponent << 23) + mantissa;
            return (float)(float.MaxValue * 2.0 * (rand.NextDouble() - 0.5));
        }
    } 
}
