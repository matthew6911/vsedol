using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите сумму вклада: ");
            decimal sum = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Введите количество месяцев: ");
            int months = Convert.ToInt32(Console.ReadLine());

            int counter = 0;
            while (counter < months)
            {
                sum += sum * 0.07m;
                counter++;
            }

            Console.WriteLine($"Конечная сумма вклада: {sum}");
            Console.ReadKey();
        }
    }
}
