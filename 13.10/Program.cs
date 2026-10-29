using System;
using System.Collections.Generic;

namespace _13._10
{
    class UserPlacesMap : Dictionary<Place, string> { }
    class AirplaneMap : Dictionary<PlaceType, UserPlacesMap> { }

    class MapAirlines : Dictionary<string, AirplaneMap> { }

    public struct Place
    {
        ushort line;
        char code;

        public Place(char code, ushort line)
        {
            this.code = code;
            this.line = line;
        }

        public override string ToString()
        {
            return $"{code}{line}";
        }
    }

    enum PlaceType
    {
        ECONOM,
        BUSSINES
    }


    internal class Program
    {
        static void G<T>(ICollection<T> collection)
        {
            foreach (T item in collection) { }
        }

        static void F<T>(List<T> list)
        {

        }

        static void Main(string[] args)
        {
            {
                /**
                 *  {
                 *      "C-105": {
                 *          "ECCONOM": {
                 *              "A3": "Nokolay",
                 *              "B1": "Svetlana,
                 *              "C3": "Vladimir"
                 *          }
                 *      },
                 *      "B-103": {
                 *          "ECCONOM": {
                 *              "A3": "Nokolay",
                 *              "B1": "Svetlana,
                 *              "C3": "Vladimir"
                 *          }
                 *      }
                 *  }
                 * 
                 */

                MapAirlines airlines = new MapAirlines();

                {
                    AirplaneMap airplanes = new AirplaneMap();

                    UserPlacesMap placesMap = new UserPlacesMap();
                    placesMap.Add(
                        new Place('A', 3),
                        "Nikolay"
                    );
                    placesMap.Add(
                        new Place('B', 1),
                        "Svetlana"
                    );
                    placesMap.Add(
                        new Place('C', 3),
                        "Vladimir"
                    );

                    airplanes.Add(
                        PlaceType.ECONOM, placesMap
                    );

                    airlines.Add("C-105", airplanes);
                }

                {
                    AirplaneMap airplanes = new AirplaneMap();

                    UserPlacesMap placesMap = new UserPlacesMap();
                    placesMap.Add(
                        new Place('F', 1),
                        "Svetlana"
                    );
                    placesMap.Add(
                        new Place('B', 2),
                        "Genadiy"
                    );
                    placesMap.Add(
                        new Place('C', 1),
                        "Vladimir"
                    );

                    airplanes.Add(
                        PlaceType.ECONOM, placesMap
                    );

                    airlines.Add("B-103", airplanes);
                }

                Console.Write("Введие ваше имя: ");
                string name = Console.ReadLine();

                foreach (KeyValuePair<string, AirplaneMap> airplane in airlines)
                {
                    foreach (KeyValuePair<PlaceType, UserPlacesMap> placesMap in airplane.Value)
                    {
                        foreach (KeyValuePair<Place, string> customer in placesMap.Value)
                        {
                            if(name == customer.Value)
                            {
                                Console.WriteLine($"Рейс: {airplane.Key}, Место: {customer.Key}({placesMap.Key})");
                            }
                        }
                    }
                }
            }

            {
                List<int> l = new List<int>();
                LinkedList<bool> ll = new LinkedList<bool>();
                SortedSet<string> ss = new SortedSet<string>();
                Dictionary<object, Program> d = new Dictionary<object, Program>();

                G(l);
                G(ll);
                G(ss);
                G(d);
            }

            {
                Console.Write("Введите предложение: ");
                string value = Console.ReadLine();

                Dictionary<char, uint> lettersCount = new Dictionary<char, uint>();

                // пробежаться по всем буквам в строке
                foreach(char letter in value)
                {
                    char lowerLetter = letter.ToString().ToLower()[0];
                    if(lettersCount.ContainsKey(lowerLetter))
                    {
                        lettersCount[lowerLetter] += 1;
                    } else
                    {
                        lettersCount.Add(lowerLetter, 1);
                    }
                }

                foreach(KeyValuePair<char, uint> pairLetter in lettersCount)
                {
                    Console.WriteLine($"{pairLetter.Key}: {pairLetter.Value}");
                }
            }

            {
                Dictionary<int, string> dictLow = new Dictionary<int, string>();
                dictLow.Add(1, "один");
                dictLow.Add(2, "два");
                dictLow.Add(3, "три");
                dictLow.Add(4, "четыре");

                Dictionary<int, string> dictMedium = new Dictionary<int, string>();
                dictMedium.Add(2, "двадцать");
                dictMedium.Add(3, "тридцать");
                dictMedium.Add(4, "сорок");
                dictMedium.Add(5, "пятьдесят");

                Dictionary<int, string> dictLarg = new Dictionary<int, string>();
                dictLarg.Add(1, "сто");
                dictLarg.Add(2, "двести");
                dictLarg.Add(3, "триста");
                dictLarg.Add(4, "четыреста");

                Console.Write("Введите 3х значное число: ");
                int value = int.Parse(Console.ReadLine());

                string strValue = value.ToString();

                int firstDigit = int.Parse(strValue[0].ToString());

                if(dictLarg.ContainsKey(firstDigit))
                {
                    Console.Write($"{dictLarg[firstDigit]} ");

                    int secondDigit = int.Parse(strValue[1].ToString());
                    if(dictMedium.ContainsKey(secondDigit))
                    {
                        Console.Write($"{dictMedium[secondDigit]} ");
                    }

                    int thirsDigit = int.Parse(strValue[2].ToString());
                    if (dictLow.ContainsKey(thirsDigit))
                    {
                        Console.Write($"{dictLow[thirsDigit]}");
                    }
                }
            }  
        }
    }
}
