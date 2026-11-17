using System;
using System.IO;

namespace _13._10
{
    /**
     *  Запишите в файл N рандомных чисел N > 1,
     *  
     *      1. Первое число, это количество чисел, который идет после него, а оставшиеся - это просто рандомные числа
     *      и запишите это в файл, где каждое число с новой строки
     *      
     *      2. Прочитайте этот файл с компьютера и посчитайте сумму чисел
     * 
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            {
                string seporator = " | ";

                while(true)
                {
                    Console.Clear();
                    Console.WriteLine("Приложение 'Мой дневник'");
                    Console.WriteLine("\n===================\n");

                    Console.WriteLine("1. Сделать запись");
                    Console.WriteLine("2. Прочитать");

                    int changeMenu = int.Parse(Console.ReadLine());

                    switch(changeMenu)
                    {
                        case 1:
                            {
                                using (FileStream fileStream = new FileStream("files/data.txt", FileMode.Append, FileAccess.Write))
                                {
                                    using (StreamWriter sw = new StreamWriter(fileStream))
                                    {
                                        Console.Write("Хотите ли что-нибудь записать в дневник?(y/n): ");
                                        char change = Console.ReadLine().ToLower()[0];

                                        if (change == 'y')
                                        {
                                            while (true)
                                            {
                                                Console.WriteLine("Чем хотите поделиться?");
                                                Console.Write("Напишите: ");

                                                string line = Console.ReadLine();

                                                sw.Write(DateTime.Now);
                                                sw.Write(seporator);
                                                sw.Write(line);
                                                sw.Write('\n');

                                                Console.Clear();
                                                Console.Write("Спасибо за доверие! Желаете ли сделать ещё запись?(y/n): ");

                                                change = Console.ReadLine().ToLower()[0];

                                                if (change != 'y')
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 2: {
                            using (FileStream fileStream = new FileStream("files/data.txt", FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fileStream))
                                {
                                    while(true)
                                    {
                                            Console.Clear();

                                            Console.WriteLine("Ваши записи: ");
                                            Console.WriteLine("\n--------------------\n");

                                            int i = 0;
                                            while(!sr.EndOfStream && i < 10)
                                            {
                                                Console.WriteLine($"{i + 1}.\t{sr.ReadLine()}");
                                                i += 1;
                                            }

                                            Console.WriteLine("\n--------------------\n");

                                            if (sr.EndOfStream)
                                            {
                                                Console.Write("Конец записей, выйти в меню?(y/n): ");

                                                char change = Console.ReadLine().ToLower()[0];

                                                if (change == 'y')
                                                {
                                                    break;
                                                }
                                            } else
                                            {
                                                Console.Write("Открыть следующую страницу?(y/n): ");

                                                char change = Console.ReadLine().ToLower()[0];

                                                if (change != 'y')
                                                {
                                                    break;
                                                }
                                            }

                                                
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
                

                

            }


            /**
             *  FileMode
             *      Open    - открыть - Работа с существующим файлом, если попытаться открыть несуществующий, то ошибка
             *      Create  - создать - Работа с несуществующим файлам, если попытаться открыть существующий, то ошибка
             *      OpenOrCreate - открыть или создать - если файла нет, то будет создан, иначе будет открыт
             *      Append  - добавить - работа с существующим файлом, но запись пойдет в конец файла
             */

            using (FileStream fileStream = new FileStream("files/init.txt", FileMode.OpenOrCreate, FileAccess.Read)) 
            {
                using (StreamReader sr = new StreamReader(fileStream)) {
                    Console.WriteLine($"Данные файла: \"");
                    while (!sr.EndOfStream)
                    {
                        string data = sr.ReadLine();
                        Console.WriteLine(data);
                    }
                    Console.WriteLine($"\"");

                    /*
                    byte [] buffer = new byte[1024];
                    fileStream.Read(buffer, 0, buffer.Length);

                    Console.WriteLine($"Данные файла: {Encoding.UTF8.GetString(buffer)}");
                    */
                }
            }
            
        }
    }
}
