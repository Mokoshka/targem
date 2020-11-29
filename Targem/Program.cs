using System;

namespace Targem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение");

            string expression = Console.ReadLine();
            Calculator.Calculator calculator = new Calculator.Calculator();

            try
            {
                double result = calculator.Calculate(expression);

                Console.WriteLine("Результат: {0}", result);
            }
            catch (Exception err)
            {
                Console.WriteLine("Ошибка: {0}", err.Message);
                Console.WriteLine(err.StackTrace);
            }

            Console.ReadKey();
        }
    }
}
