using System;

namespace Incapsulate
{
    internal class InternalExample
    {
        // Доступ внутри сборки, за её пределами - доступа к методу нет
        internal void print()
        {
            Console.WriteLine("Incapsulate internal method");
        }

        // Доступ внутри сборки, за её пределами
        //  - доступа к методу есть только у наследников класса
        internal protected void protectedPrint()
        {
            Console.WriteLine("Incapsulate internal protected method");
        }
    }
}
