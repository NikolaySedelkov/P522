using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._10
{
    interface IFounder<T>
    {
        bool IsFind(T value);
    }

    class FounderRectangleSqeaMore : IFounder<Rectangle>
    {
        uint N;

        public FounderRectangleSqeaMore(uint N)
        {
            this.N = N;
        }

        public bool IsFind(Rectangle rectangle)
        {
            return rectangle.A * rectangle.B > N;
        }
    }

    class EvenIntFounder : IFounder<int>
    {
        public bool IsFind(int value)
        {
            return (value % 2 == 0);
        }
    }

    class Rectangle
    {
        uint a, b;

        public Rectangle(uint a, uint b) {
            this.a = a;
            this.b = b;
        }

        public uint A { get => a; }
        public uint B { get => b; }

        public static bool IsAllSideEven(Rectangle rectangle)
        {
            return rectangle.A % 2 == 0 && rectangle.B % 2 == 0;
        }

        public override string ToString()
        {
            return $"({A}, {B})";
        }
    }

    internal class Program
    {
        static int FindIndex<T>(ICollection<T> collenction, IFounder<T> founder)
        {
            int i = 0;
            foreach(T value in collenction)
            {
                if(founder.IsFind(value))
                {
                    return i;
                }
                i += 1;
            }
            return -1;
        }

        static int FindIndex<T>(ICollection<T> collenction, Predicate<T> findPredicate)
        {
            int i = 0;
            foreach (T value in collenction)
            {
                if (findPredicate(value))
                {
                    return i;
                }
                i += 1;
            }
            return -1;
        }

        static bool OddIntPredicate(int value)
        {
            return value % 2 != 0;
        }

        static bool More100Predicate(int value)
        {
            return value > 100;
        }

        static int FindNoFirstIndex<T>(IList<T> collenction, Predicate<T> findPredicate)
        {
            int i = collenction.Count - 1;
            for (T value; i >= 0; i--)
            {
                value = collenction[i];
                if (findPredicate(value))
                {
                    return i;
                }
            }
            return -1;
        }

        static bool IsSqart(int v)
        {
            return Math.Sqrt(v) >= 0;
        }

        static List<T> Filter<T>(List<T> list, Predicate<T> predicate)
        {
            List<T> result = new List<T>();
            foreach(T value in list)
            {
                if (predicate(value)) {
                    result.Add(value);
                }
            }
            return result;
        }

        static List<Rectangle> Filter(
            List<Rectangle> list, 
            FounderRectangleSqeaMore founder) => Filter(list, founder.IsFind);

        // delegate - специальный конструктор для типов функций
        delegate bool SortComparer<T>(T val1, T val2); 
        static List<T> Sort<T>(List<T> old, SortComparer<T> comparer)
        {
            List<T> result = new List<T>(old);

            for(int i = 1; i < result.Count; ++i)
            {
                for(int j = 0; j < result.Count - i; ++j)
                {
                    if (comparer(result[j], result[j + 1]))
                    {
                        T temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        delegate double MathCalc(double num1, double num2);

        class Calc
        {
            List<MathCalc> handlers = new List<MathCalc>
            {
                (num1, num2) => num1 + num2,
                (num1, num2) => num1 - num2,
                (num1, num2) => num1 / num2,
                (num1, num2) => num1 * num2,
            };

            public void Add(MathCalc handler)
            {
                handlers.Add(handler);
            } 
        }

        static bool IsSqeaMore20(Rectangle rectangle)
        {
            return rectangle.A * rectangle.B > 20;
        }

        static bool IsBlock(Rectangle rectangle) => rectangle.B > rectangle.A;

        static bool IsSimple(int value) => value % 2 != 0;

        // Исходная модель заказа
        public class Order
        {
            public int Id { get; set; }
            public string Product { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public bool IsPaid { get; set; }
        }

        // Модель для итоговой статистики
        public class CategoryStats
        {
            public decimal TotalRevenue { get; set; }
            public int TotalItemsSold { get; set; }
            public string MostExpensiveProduct { get; set; }

            public override string ToString()
            {
                return $"Total: {TotalRevenue}\nCount: {TotalItemsSold}\nMax: {MostExpensiveProduct}";
            }
        }

        static void Main(string[] args)
        {
            {
                // Тестовые данные
                List<Order> orders = new List<Order> { 
                    new Order { Id = 1, Product = "Ноутбук", Category = "Электроника", Price = 80000m, Quantity = 1, IsPaid = true },
                    new Order { Id = 2, Product = "Мышь", Category = "Электроника", Price = 1500m, Quantity = 2, IsPaid = true },
                    new Order { Id = 3, Product = "Футболка", Category = "Одежда", Price = 2000m, Quantity = 3, IsPaid = false },
                    new Order { Id = 4, Product = "Клавиатура", Category = "Электроника", Price = 5000m, Quantity = 1, IsPaid = true },
                    new Order { Id = 5, Product = "Джинсы", Category = "Одежда", Price = 4500m, Quantity = 2, IsPaid = true },
                    new Order { Id = 6, Product = "Кроссовки", Category = "Одежда", Price = 7000m, Quantity = 1, IsPaid = false },
                    new Order { Id = 7, Product = "Кофеварка", Category = "Бытовая техника", Price = 12000m, Quantity = 1, IsPaid = true },
                    new Order { Id = 8, Product = "Куртка", Category = "Одежда", Price = 10000m, Quantity = 1, IsPaid = true }
                };

                // TASK: Составить список продуктор, каждой категории

                Dictionary<string, CategoryStats> groups = orders
                    .Where(order => order.IsPaid)
                    .GroupBy(order => order.Category)
                    .ToDictionary(
                        group => group.Key,
                        group =>
                        {
                            List<Order> _orders = group.ToList();
                            return new CategoryStats
                            {
                                TotalRevenue = _orders.Select(order => order.Price * order.Quantity).Sum(),
                                TotalItemsSold = _orders.Select(order => order.Quantity).Sum(),
                                MostExpensiveProduct = _orders.OrderByDescending(order => order.Price).First().Product
                            };
                        }
                    )
                    .OrderByDescending(group => group.Value.TotalRevenue)
                    .ToDictionary(
                        group => group.Key,
                        group => group.Value
                    );

                foreach( var group in groups)
                {
                    Console.WriteLine( group.Key );
                    Console.WriteLine(group.Value);
                    Console.WriteLine("===============");
                }
            }

            {
                List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
                
                if(numbers.Exists(value => value > 0))
                {
                    int target = numbers.Find(value => value > 0);
                    int index = numbers.FindIndex(value => value > 0);
                    List<int> allTargets = numbers.FindAll(value => value > 0);
                }

                {
                    // Группировка по кол-во цифер в чисел
                    Dictionary<byte, List<int>> groups = new Dictionary<byte, List<int>>();
                    foreach(int value in numbers)
                    {
                        byte countDigist = (byte)value.ToString().Length;
                        if(groups.ContainsKey(countDigist))
                        {
                            groups[countDigist].Add(value);
                        } else
                        {
                            groups.Add(countDigist, new List<int> { value });
                        }
                    }
                }

                {
                    // Группировка по кол-во цифер в чисел
                    Dictionary<byte, List<int>> groups = numbers.GroupBy(
                        value => (byte)value.ToString().Length
                    ).ToDictionary(
                        group => group.Key,
                        group => group.ToList()
                    );
                }

                // LINQ
                {
                    // Поиск всех элементов, подходящих под критерий
                    numbers.Where(value => value > 5);
                    // Сделать из одной коллекции - другую, в которой каждое новое значение 
                    // будет каким-то образом зависить от другово
                    List<Rectangle> rectangles = numbers.Select(value => new Rectangle(
                        value > 0 ? (uint)value : 0, value > 0 ? (uint)value : 0)).ToList();
                    // Сортировка (возрастание)
                    rectangles.OrderBy(rectangle => rectangle.A);
                    // (убывание)
                    rectangles.OrderByDescending(rectangle => rectangle.B);


                    numbers
                        .Where(value => value > 5)
                        .Select(value => new Rectangle(
                            value > 0 ? (uint)value : 0, value > 0 ? (uint)value : 0))
                        .OrderBy(rectangle => rectangle.A);
                }
                
            }

            {
                Calc calc = new Calc();
                calc.Add(Math.Pow);
                calc.Add(
                    (height, weight) => 2 * (height + weight)
                );
            }

            {
                List<Rectangle> rectangles = new List<Rectangle>
                {
                    new Rectangle(2, 4),
                    new Rectangle(1, 100),
                    new Rectangle(5, 2),
                    new Rectangle(70, 2),
                    new Rectangle(10, 10)
                };
                List<Rectangle> result = Filter(rectangles, IsSqeaMore20);
                result = Filter(rectangles, IsBlock);

                uint N = uint.Parse(Console.ReadLine());
                FounderRectangleSqeaMore founderN = new FounderRectangleSqeaMore(N);

                result = Filter(rectangles, founderN);
                result = Filter(rectangles, founderN.IsFind);

                Predicate<Rectangle> t = rectangle => rectangle.B * rectangle.A > N;

                result = Filter(rectangles, t);
                result = Filter(
                    rectangles,
                    /**
                     * 
                     * bool ANONIMUS_FUNCTION(Rectangle rectangle) {
                     *      return rectangle.B * rectangle.A > N;
                     * }
                     * 
                     */
                    (rectangle) =>
                    {
                        return rectangle.B * rectangle.A > N;
                    }
                );
            }

            {
                List<int> list1 = new List<int> { -1, 1, 2, 3, 4, 25, 5 };
                int i = FindNoFirstIndex(list1, IsSqart);
                Console.WriteLine(i);
            }

            {
                List<Rectangle> rectangles = new List<Rectangle>
                {
                    new Rectangle(2, 4),
                    new Rectangle(1, 100),
                    new Rectangle(5, 2),
                    new Rectangle(70, 2),
                    new Rectangle(10, 10)
                };

                {
                    int index = FindIndex(rectangles, Rectangle.IsAllSideEven);
                    Console.WriteLine($"Прямоугольник, у котого обе стороны нечетные: {rectangles[index]}, под номером: {index}");
                }
                
            }


            List<int> list = new List<int> { 1, 2, 3, 4, 5 };

            {
                Sort(
                    list,
                    (num1, num2) => num1 > num2
                );

                Sort(
                   list,
                   (num1, num2) =>
                   {
                       return num1 < num2;
                   }
               );
            }

            {
                int index = FindIndex(list, new EvenIntFounder());
                Console.WriteLine($"Первый четный элемент: {list[index]}, на позиции {index}");
            }

            {
                int index = FindIndex(list, OddIntPredicate);
                Console.WriteLine($"Первый нечетный элемент: {list[index]}, на позиции {index}");
            }

            {
                int index = FindIndex(list, More100Predicate);
                if(index >= 0)
                {
                    Console.WriteLine($"Первый элемент больщий чем 100: {list[index]}, на позиции {index}");
                } else
                {
                    Console.WriteLine("Элементов больших 100 в массиве нет");
                }
                
            }

            Console.ReadLine();
        }
    }
}
