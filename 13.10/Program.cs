using System;

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
            int x = 2;
            int y; y = 3;

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
