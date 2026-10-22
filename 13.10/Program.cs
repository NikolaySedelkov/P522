using System;
using System.Collections;
using System.Collections.Generic;

namespace _13._10
{
    class PointDistanceComparer : IComparer, IComparer<Point>
    {
        public int Compare(object x, object y)
        {
            if (x is Point first && y is Point second)
            {
                return Compare(first, second);
            }
            throw new ArgumentException();
        }

        public int Compare(Point x, Point y)
        {
            return x.Distance().CompareTo(y.Distance());
        }
    }

    class PointXComparer : IComparer<Point>
    {
        public int Compare(Point first, Point second)
        {
            return first.X.CompareTo(second.X);
        }
    }

    class Point : IComparable, IComparable<Point>
    {
        int x, y;

        public int X { get => x; }
        public int Y { get => Y; }
        public Point(int x, int y)
        {
            this.y = y;
            this.x = x;
        }

        public int CompareTo(object obj)
        {
            // is - опретор провреки возможности приведение типа
            if (obj is Point)
            {
                // as - приведение типа
                Point other = obj as Point;

                return CompareTo(other);
            }
            throw new ArgumentException($"{obj} is not type Point");
        }

        public int CompareTo(Point other)
        {
            return this.Distance().CompareTo(other.Distance());
        }

        public double Distance()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }

    class Poligon : IEnumerable
    {
        List<Point> nodes;

        public Poligon(List<Point> nodes)
        {
            this.nodes = nodes;
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    internal class Programe
    {
        static void Main(string[] args)
        {
            {
                List<Point> points = new List<Point>(){ new Point(-100, 4), new Point(20, 4), new Point(-1, -1) };
                Poligon poligon = new Poligon(points);

                Console.WriteLine("summary poligon: ");
                foreach(Point node in poligon)
                {
                    Console.WriteLine(node);
                }
            }

            Console.WriteLine("\n\n=============================\n\n");

            {
                Point[] points = { new Point(-100, 4), new Point(20, 4), new Point(-1, -1) };

                Array.Sort(points, new PointXComparer());

                foreach (Point point in points)
                {
                    Console.WriteLine(point);
                }
            }

            Console.WriteLine("\n\n=============================\n\n");

            {
                Point[] points = { new Point(1, 4), new Point(20, 4), new Point(-1, -1) };

                Array.Sort(points);

                foreach (Point point in points)
                {
                    Console.WriteLine(point);
                }
            }

            Console.WriteLine("\n\n=============================\n\n");
            
            {
                int[] mas = { 42, 24, 1000 };
                Array.Sort(mas);

                foreach(int value in mas)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
