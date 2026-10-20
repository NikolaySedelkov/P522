using System;
using Incapsulate;

namespace _13._10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InternalExample incapsulate = new InternalExample();
            incapsulate.print();

            Guard guard = new Guard("1111");
            guard.x = 2;
            //guard.readonlyField = "Hello world!";
            //guard.readonlyField = "Hello world!";

            Console.WriteLine($"ReadOnly field of class 'Guard' = {guard.readonlyField}");
            Console.WriteLine($"Const field of class 'Guard' = {Guard.constField}");
        }
    }

    interface IMath
    {
        int sum(int a, int b);
        int sub(int a, int b);
        int div(int a, int b);
        int mul(int a, int b);
    }

    class Calculate : IMath
    {
        public int sum(int a, int b)
        {
            return a + b;
        }
        public int sub(int a, int b)
        {
            return a - b;
        }
        public int div(int a, int b)
        {
            return a / b;
        }
        public int mul(int a, int b)
        {
            return a * b;
        }
    }

    // partial - частичный, такой класс можно разбить на несколько файлов
    partial class Guard
    {
        // readonly - модификатор, который указаывает что значение поля можно инициализировать
        // только один раз в момент создания экземляра класса
        // - инициализия и какое-либо изменение только в конструкторе
        public readonly string readonlyField;
        public const string constField = "CONST";

        public Guard(string readonlyField)
        {
            this.readonlyField = readonlyField;
        }

        /*
        void setReadonlyField(string value)
        {
            // readonlyField = value; ERROR
        }
        */
    }

    abstract class Parent
    {
        abstract public void execute();
        virtual public void handler() {
            Console.WriteLine("Parent");
        }
    }

    // в классе переопрелили все абстракные методы, значит класс не абстрактный
    class Child1 : Parent
    {
        override public void execute() {
            Console.WriteLine("Override 'execute'");
        }

        override public void handler() {
            Console.WriteLine("Child");
        }
    }

    // в классе не переопрелили все абстракные методы - значит класс должен быть абстрактным
    abstract class Child2 : Parent
    {
        override public void handler()
        {
            Console.WriteLine("Child");
        }
    }
}
