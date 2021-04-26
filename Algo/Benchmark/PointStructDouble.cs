using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    class PointStructDouble
    {
        [ParamsSource(nameof(ValuesX))]
        public double X { get; set; }
        [ParamsSource(nameof(ValuesY))]
        public double Y { get; set; }

        public double[] ValuesX { get; set; }
        public double[] ValuesY { get; set; }

        public void Init()
        {
            Random rnd = new Random();
            int count = 10;

            ValuesX = new double[count];
            ValuesY = new double[count];

            for (int i = 0; i < count; i++)
            {
                ValuesX[i] = rnd.NextDouble();
                ValuesY[i] = rnd.NextDouble();
            }
        }
    }
}
