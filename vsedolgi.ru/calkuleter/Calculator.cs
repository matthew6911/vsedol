namespace Task1
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Доступные операции:");
            Console.WriteLine("1. Сложение (+)");
            Console.WriteLine("2. Вычитание (-)");
            Console.WriteLine("3. Умножение (*)");
            Console.WriteLine("4. Деление (/)");
            Console.WriteLine("5. Остаток от деления (%)");
            Console.WriteLine("6. Инкремент (++)");
            Console.WriteLine("7. Декремент (--)");

            Console.Write("Выберите операцию (введите номер или символ): ");
            string operation = Console.ReadLine();

            double num1, num2 = 0;
            bool isUnaryOperation = operation == "6" || operation == "++" ||
                                  operation == "7" || operation == "--";

            Console.Write("Введите первое число: ");
            num1 = Convert.ToDouble(Console.ReadLine());

            if (!isUnaryOperation)
            {
                Console.Write("Введите второе число: ");
                num2 = Convert.ToDouble(Console.ReadLine());
            }

            double result = 0;
            bool error = false;

            switch (operation)
            {
                case "1":
                case "+":
                    result = num1 + num2;
                    break;
                case "2":
                case "-":
                    result = num1 - num2;
                    break;
                case "3":
                case "*":
                    result = num1 * num2;
                    break;
                case "4":
                case "/":
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        error = true;
                    break;
                case "5":
                case "%":
                    result = num1 % num2;
                    break;
                case "6":
                case "++":
                    result = num1 + 1;
                    break;
                case "7":
                case "--":
                    result = num1 - 1;
                    break;
                default:
                    Console.WriteLine("Неверная операция!");
                    return;
            }

            if (error)
                Console.WriteLine("Ошибка: деление на ноль!");
            else
                Console.WriteLine($"Результат: {result}");

            Console.ReadKey();
        }
    }
}