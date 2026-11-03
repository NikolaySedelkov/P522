using System;
using System.Collections.Generic;

namespace _13._10
{
    interface IFounder<T>
    {
        bool IsFind(T value);
    }

    class EvenIntFounder : IFounder<int>
    {
        public bool IsFind(int value)
        {
            return (value % 2 == 0);
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

        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
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
