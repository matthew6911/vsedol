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

            for (int i = 0; i < months; i++)
            {
                sum += sum * 0.07m;
            }

            Console.WriteLine($"Конечная сумма вклада: {sum}");
            Console.ReadKey();
        }
    }
}
