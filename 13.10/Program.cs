using System;
using System.Linq;

namespace _13._10
{
    internal class Program
    {
        static void TestFunction(string x)
        {
            x = "999";
        }

        static void Main(string[] args)
        {
            {
                Point point = new Point();
                point.x = 2;
            }

            {
                int gg = 7;
                TestFunction(gg.ToString());

                Console.WriteLine(gg);
            }

            {
                string name = Console.ReadLine().ToLower();

                switch (name)
                {
                    case "nikolay":
                    case "vasiliy":
                    case "grigoriy":
                        {
                            Console.WriteLine($"Name - '{name}' - is male");
                            break;
                        }

                    case "anastasiya":
                    case "yulia":
                    case "ekaterina":
                        {
                            Console.WriteLine($"Name - '{name}' - is female");
                            break;
                        }
                }
            }

            Console.ReadLine();
        }
    }

    class Point
    {
        // Объсение полей/методов
        /*
         * ACCESS_LEVEL TYPE NAME = INIT_VALUE;
         * 
         * ACCESS_LEVEL RETURN_TYPE NAME(ARG_TYPE1 NAME1, ARG_TYPE2 NAME2, ARG_TYPE3 NAME3, ...) {}
         * 
         * 
         * ACESS_LEVEL = { public, protected, private, ..., ... } - по умолчанию private
         */
        public int x, y;

        public double Distance(Point other)
        {
            return Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
        }

        public Point() { }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
