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
            /*
             *  Написать какой-нибудь класс из минимум четырех каких-нибдуь полей(пример класс Book)
             *  
             *  Все поля сделать приватными и под каждый написать свойства
                3 конструктора: По умолчанию, иницилизирующий и копировани
             * 
             * 
             * Создайте массив из ваших классов и напиши функцию, которая будет сортировать ваш массив
             * по какого-нибудь критерию
             */

            {
                Point3D point3D = new Point3D { 
                   X = 100,
                   Y = 200,
                   Z = 300
                };
                point3D.Z = 199;
                Console.WriteLine($"Z = {point3D.Z}");

                point3D.X = 4;
                Console.WriteLine($"X = {point3D.X}");

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

    class Point3D {
        int x, y;

        // По мимо полей и методов в классе есть ещё свойства
        /**
         *  Свойства - специальные методы дл обращения к полям класса
         */

        public int X
        {
            /*
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
            */

            /**
             *  get и set так же имею свои модификаторы доступа
             *  по умолчанию он такой же как у всего блока
             *  
             *  их модификатор доступа не может быть более доступным, чем общий
             */
            get => x;
            /*protected*/ set => x = value;
        }

        public int Y
        {
            /*protected*/ get => y;
            set => y = value;
        }

        public int Z
        {
            get; set;
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
