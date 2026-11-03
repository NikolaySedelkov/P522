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
            return value % 2 == 0;
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

        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            FindIndex(list, new EvenIntFounder());
        }
    }
}
