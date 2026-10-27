using System;
using System.Collections.Generic;
using System.Diagnostics; // Обязательно подключить

namespace _13._10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i = 100_000; i <= 1_000_000; i += 100_000 )
            {
                List<int> data = new List<int>(i);
                Random rnd = new Random();
                for (int j = 0; j < data.Capacity; j++) {
                    data.Add(rnd.Next());
                }

                Console.WriteLine($"Эксперимент на {i} элементов");
                Console.WriteLine("/=============================/\n");

                {
                    Console.WriteLine("Испутыемый 'HashSet'");
                    Console.WriteLine("/=============================/\n");

                    HashSet<int> set = new HashSet<int>(data);

                    var stopwatch = new Stopwatch();

                    stopwatch.Start(); // Запуск таймера

                    for (int temp = 0; temp < 100; ++temp)
                    {
                        int value = data[(data.Count - 1) / 100 * temp];

                        set.Contains(value);
                    }

                    stopwatch.Stop(); // Остановка таймера

                    // Вывод результатов
                    Console.WriteLine($"Время в миллисекундах: {stopwatch.ElapsedMilliseconds} мс");
                    Console.WriteLine($"Точное время (TimeSpan): {stopwatch.Elapsed}");
                    Console.WriteLine("--------------------------");
                }

                
            }

            // деревья
            {
                HashSet<int> items = new HashSet<int>();
                items.Add(100);
                items.Add(-2);
                items.Add(77);
                items.Add(9);
                items.Add(15);

                foreach (int value in items)
                {
                    Console.WriteLine(value);
                }
            }

            // Список
            {
                LinkedList<string> items = new LinkedList<string>();
                items.AddFirst("first-1");
                items.AddFirst("first-2");
                items.AddFirst("first-3");
                items.AddFirst("first-4");
                items.AddFirst("first-5");

                items.AddLast("last-1");
                items.AddLast("last-2");
                items.AddLast("last-3");
                items.AddLast("last-4");
                items.AddLast("last-5");

                LinkedListNode<string> node = items.Find("last-5");

                items.AddAfter(node, "after-1");
                items.AddBefore(node, "before-1");
            }

            // массив
            {
                List<int> items = new List<int>(5);
                items.Add(2);
                items.Add(22);
                items.Add(222);
                items.Add(2222);
                items.Add(22222);

                items.AddRange(new List<int> { 1, 2, 3 });
                Console.WriteLine($"Capacity = {items.Capacity}");
            }
        }
    }
}
