using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    public class BechmarkClass
    {
        [Benchmark]
        public float TestDistancePointClassFloat()
        {
            PointClassFloat p1 = new PointClassFloat();
            PointClassFloat p2 = new PointClassFloat();
            float x = p1.X - p2.X;
            float y = p1.Y - p2.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }


        [Benchmark]
        public float TestDistancePointStructFloat()
        {
            PointStructFloat p1 = new PointStructFloat();
            PointStructFloat p2 = new PointStructFloat();
            p1.Init();
            p2.Init();
            float x = p1.X - p2.X;
            float y = p1.Y - p2.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        public float TestDistancePointStructFloatWithoutSqrt()
        {
            PointStructFloat p1 = new PointStructFloat();
            PointStructFloat p2 = new PointStructFloat();
            p1.Init();
            p2.Init();
            float x = p1.X - p2.X;
            float y = p1.Y - p2.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public double TestDistancePointStructDouble()
        {
            PointStructDouble p1 = new PointStructDouble();
            PointStructDouble p2 = new PointStructDouble();
            p1.Init();
            p2.Init();
            double x = p1.X - p2.X;
            double y = p1.Y - p2.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
    }
}
