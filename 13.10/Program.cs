using System;
using System.Linq;

namespace _13._10
{
    internal class Program
    {

        static int ReadInt()
        {
            return int.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            // Создать прямоугольную матрицу N x M. 
            // которую отзеркалить по вертикали

            {
                // матрицы - прямоугольные и ступенчатые
                {
                    Console.Write("введите высоту матрицы: ");
                    int row = int.Parse(Console.ReadLine());

                    Console.Write("введите ширину матрицы: ");
                    int col = int.Parse(Console.ReadLine());
                    int[,] matrix = new int[row, col];

                    for(int i = 0; i < matrix.GetLength(0); ++i)
                    {
                        for(int j = 0; j < matrix.GetLength(1); ++j)
                        {
                            Console.Write($"Введите значение матрицы[{i}][{j}]: ");
                            matrix[i, j] = int.Parse(Console.ReadLine());
                        }
                    }

                    int middleI = matrix.GetLength(0) / 2;
                    int middleJ = matrix.GetLength(1) / 2;

                    Console.WriteLine($"Элемент середины матрицы: [{middleI}][{middleJ}] = {matrix[middleI, middleJ]}");
                }

                Console.Clear();
                {
                    Console.Write("введите количество строк матрицы: ");
                    int row = int.Parse(Console.ReadLine());

                    int[][] matrix = new int[row][];

                    for(int i = 0; i < matrix.Length; ++i)
                    {
                        matrix[i] = new int[i + 1];
                        for(int j = 0; j < matrix[i].Length; ++j)
                        {
                            Console.Write($"Введите значение матрицы[{i}][{j}]: ");
                            matrix[i][j] = int.Parse(Console.ReadLine());
                        }
                    }

                    for (int i = 0; i < matrix.Length; ++i)
                    {
                        for (int j = 0; j < matrix[i].Length; ++j)
                        {
                            Console.Write($"{matrix[i][j]} ");
                        }
                        Console.WriteLine();
                    }
                }
            }

            {
                Console.Write("введите разамер массива: ");
                int n = int.Parse(Console.ReadLine());
                // Статичные массивы
                int[] mas = new int[n];

                for(int i = 0; i < mas.Length; ++i)
                {
                    Console.Write($"Введите значение массива[{i}]: ");
                    mas[i] = int.Parse(Console.ReadLine());
                }

                int sum = 0, avg = 0;
                for(int i = 0; i < mas.Length; ++i)
                {
                    sum += mas[i];
                }
                avg = sum / mas.Length;

                Console.WriteLine($"Сумма всех значений массива = {sum}, их среднее значение = {avg}");

                sum = mas.Sum();
                double davg = mas.Average();

                Console.WriteLine($"Сумма всех значений массива = {sum}, их среднее значение = {davg}");

                // Добавить элемент не в массив, а создать и вернуь новый массив, в котором будет новый элемент
                mas.Append(2);
            }

            /**
             *  int, long, short, byte
             *  
             *  int - 4 байта
             *  long - 8 байт
             *  short - 2 байта
             *  byte - 1 байт
             *  
             *  uint, ulong, ushort, ubyte - unsigned TYPEs
             */

            /**
             *  Приведение типов - работает очень строго
             *  
             *  byte <- short <- int <- long
             */
            {
                byte b = 2;
                short s = 2;
                int i = 2;
                long l = 2;

                l = i; l = s; l = b;
                i = s; i = b; // ERROR i = l; т.к попытка значение на 8б запись в ячейку на 4б
                s = b;

                ushort us = 2;
                uint ui = 2;
                ulong ul = 2;

                // Исключение - приведение типов между безнаковыми и обычными
                // ul = i;

                // Хоть эти данные и являются примитивами, но у них есть опция toString()
                i.ToString();
            }

            {
                // Условия, циклы
                int from = -100, to = 100, count = 0;

                for (int i = from; i <= to; ++i)
                {
                    if (i % 2 == 0)
                    {
                        count += 1;
                    }
                }

                {
                    int i = from;
                    while (i <= to)
                    {
                        if (i % 2 == 0)
                        {
                            count += 1;
                        }
                        ++i;
                    }
                }

                {
                    int i = from;
                    do
                    {
                        if (i % 2 == 0)
                        {
                            count += 1;
                        }
                        ++i;
                    } while (i <= to);
                }

            }

            {
                // Ввод, вывод

                // Вывод
                Console.Write("Введите ваш возраст: ");
                // Ввод из консоли всегда в формате строки
                byte age = byte.Parse(Console.ReadLine());

                int birthYear = DateTime.Now.Year - age;
                Console.WriteLine($"Вы родились в {birthYear}?");
            }
        }
    }
}
