using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] mas = {
                { { 1, 2 }, { 3, 4 } },
                { { 4, 5 }, { 6, 7 } },
                { { 7, 8 }, { 9, 10 } },
                { { 10, 11 }, { 12, 13 } }
            };

            Console.Write("{");
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                Console.Write("{");
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write("{");
                    for (int k = 0; k < mas.GetLength(2); k++)
                    {
                        Console.Write(mas[i, j, k]);
                        if (k < mas.GetLength(2) - 1)
                            Console.Write(", ");
                    }
                    Console.Write("}");
                    if (j < mas.GetLength(1) - 1)
                        Console.Write(", ");
                }
                Console.Write("}");
                if (i < mas.GetLength(0) - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("}");

            Console.ReadKey();
        }
    }
}
