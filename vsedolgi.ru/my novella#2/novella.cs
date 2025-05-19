using System;

namespace Task1
{
    class Program
    {
        static bool hasKey = false;
        static bool knowsSecret = false;
        static bool hasMap = false;
        static bool metAlly = false;
        static int trustPoints = 0;
        static string playerName = "";
        static int daysLeft = 3; // Время до атаки враждебного племени

        static void Main()
        {
            Console.WriteLine("=== ТАЙНА СВЯЩЕННОГО ПОМЕСТЬЯ ПЛЕМЕНИ КЕНТАВРОВ ===");
            Console.Write("Введите имя вашего кентавра: ");
            playerName = Console.ReadLine();

            Console.WriteLine($"\n{playerName}, ваше племя стоит на пороге войны. У вас есть {daysLeft} дня, чтобы подготовиться или найти спасение.");
            Chapter1();
        }

        static void Chapter1()
        {
            while (true)
            {
                Console.WriteLine($"\n=== ГЛАВА 1: ПРОБУЖДЕНИЕ В ПОМЕСТЬЕ ===");
                Console.WriteLine($"{playerName}, вы просыпаетесь в священном зале поместья вашего племени.");
                Console.WriteLine("1. Осмотреться вокруг");
                Console.WriteLine("2. Попробовать открыть дверь");
                Console.WriteLine("3. Позвать союзников");
                Console.WriteLine("4. Завершить игру");

                switch (GetChoice(1, 4))
                {
                    case 1:
                        Console.WriteLine("\nВокруг вы видите:");
                        Console.WriteLine("1. Древний ключ с символом племени");
                        Console.WriteLine("2. Записку с предостережением");
                        Console.WriteLine("3. Таинственный светящийся символ на стене");
                        Console.WriteLine("4. Вернуться назад");

                        switch (GetChoice(1, 4))
                        {
                            case 1:
                                hasKey = true;
                                Console.WriteLine("Вы взяли ключ - он может открыть древние двери поместья.");
                                break;
                            case 2:
                                knowsSecret = true;
                                Console.WriteLine("Записка гласит: 'Тени не всегда враги, но не доверяй чужакам.'");
                                break;
                            case 3:
                                Console.WriteLine("Символ светится при вашем прикосновении, укрепляя вашу решимость.");
                                trustPoints++;
                                break;
                        }
                        break;

                    case 2:
                        if (hasKey)
                        {
                            Console.WriteLine("\nВы открываете дверь и выходите в коридор, где решается судьба племени.");
                            daysLeft--;
                            Chapter2();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nДверь заперта. Нужно найти ключ.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nВы зовёте союзников племени на помощь...");
                        if (!metAlly)
                        {
                            Console.WriteLine("К вам приходит старейшина, готовый помочь.");
                            metAlly = true;
                            trustPoints += 2;
                        }
                        else
                        {
                            Console.WriteLine("Все союзники уже с вами.");
                        }
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void Chapter2()
        {
            Console.WriteLine($"\n=== ГЛАВА 2: КОРИДОР ВЫБОРА ===");
            Console.WriteLine($"До атаки осталось {daysLeft} дня(ей).");
            Console.WriteLine("Перед вами три двери и лестница наверх:");
            Console.WriteLine("1. Красная дверь (запах горящих трав)");
            Console.WriteLine("2. Синяя дверь (голоса племени)");
            Console.WriteLine("3. Зеленая дверь (запах свежей травы)");
            Console.WriteLine("4. Подняться по лестнице");

            switch (GetChoice(1, 4))
            {
                case 1:
                    RedDoor();
                    break;
                case 2:
                    BlueDoor();
                    break;
                case 3:
                    GreenDoor();
                    break;
                case 4:
                    Stairs();
                    break;
            }
        }

        static void RedDoor()
        {
            Console.WriteLine("\nВы входите в алхимическую лабораторию племени.");
            Console.WriteLine("1. Исследовать древние свитки");
            Console.WriteLine("2. Осмотреть зелья на столе");
            Console.WriteLine("3. Выйти");

            switch (GetChoice(1, 3))
            {
                case 1:
                    if (knowsSecret)
                    {
                        ShowEnding(1, "Вы нашли рецепт защитного эликсира и приготовили его, чтобы защитить племя!", true);
                    }
                    else
                    {
                        ShowEnding(2, "Вы случайно активировали ловушку и оказались заперты навсегда...", false);
                    }
                    break;
                case 2:
                    hasMap = true;
                    Console.WriteLine("Вы нашли карту священного поместья с тайными проходами!");
                    daysLeft--;
                    Chapter2();
                    break;
                case 3:
                    Chapter2();
                    break;
            }
        }

        static void BlueDoor()
        {
            Console.WriteLine("\nВ комнате вы встречаете воина из враждебного племени.");
            Console.WriteLine("1. Попытаться договориться");
            Console.WriteLine("2. Атаковать");
            Console.WriteLine("3. Уйти");

            switch (GetChoice(1, 3))
            {
                case 1:
                    Console.WriteLine("Воин заинтересован в мире и предлагает союз.");
                    trustPoints += 3;
                    daysLeft--;
                    Chapter2();
                    break;
                case 2:
                    ShowEnding(3, "Воины враждебного племени побеждают вас в бою...", false);
                    break;
                case 3:
                    Chapter2();
                    break;
            }
        }

        static void GreenDoor()
        {
            Console.WriteLine("\nВы попадаете в оранжерею с целебными растениями.");
            Console.WriteLine("1. Сорвать красный цветок");
            Console.WriteLine("2. Сорвать синий цветок");
            Console.WriteLine("3. Выйти");

            switch (GetChoice(1, 3))
            {
                case 1:
                    ShowEnding(4, "Красный цветок выпускает ядовитые пары, и вы теряете сознание...", false);
                    break;
                case 2:
                    Console.WriteLine("Синий цветок дарит вам видение будущего - вы лучше понимаете врага.");
                    trustPoints++;
                    daysLeft--;
                    Chapter2();
                    break;
                case 3:
                    Chapter2();
                    break;
            }
        }

        static void Stairs()
        {
            Console.WriteLine("\nВы поднимаетесь на верхний этаж.");
            Console.WriteLine("1. Открыть дверь на чердак");
            Console.WriteLine("2. Попытаться сбежать через окно");
            Console.WriteLine("3. Вернуться");

            switch (GetChoice(1, 3))
            {
                case 1:
                    Attic();
                    break;
                case 2:
                    if (trustPoints >= 4)
                    {
                        ShowEnding(5, "Вы успешно выбираетесь из поместья и находите безопасное место!", true);
                    }
                    else
                    {
                        ShowEnding(6, "Вы падаете с окна и раните ногу, тени приближаются...", false);
                    }
                    break;
                case 3:
                    Chapter2();
                    break;
            }
        }

        static void Attic()
        {
            Console.WriteLine("\nНа чердаке вы находите древний артефакт племени.");
            Console.WriteLine("1. Взять артефакт");
            Console.WriteLine("2. Оставить артефакт");

            if (GetChoice(1, 2) == 1)
            {
                if (metAlly && hasMap)
                {
                    ShowEnding(7, "Артефакт активируется и переносит вас в безопасное место - вы спасены!", true);
                }
                else
                {
                    ShowEnding(8, "Артефакт поглощает ваше сознание, и вы навсегда теряетесь в его тайнах...", false);
                }
            }
            else
            {
                Console.WriteLine("Вы решаете не трогать артефакт, и это укрепляет вашу связь с племенем.");
                trustPoints++;
                FinalChoice();
            }
        }

        static void FinalChoice()
        {
            Console.WriteLine("\n=== ФИНАЛЬНЫЙ ВЫБОР ===");
            Console.WriteLine("1. Искать тайный выход из поместья");
            Console.WriteLine("2. Вернуться к старейшине за советом");

            if (GetChoice(1, 2) == 1)
            {
                if (trustPoints >= 4)
                {
                    ShowEnding(9, "Используя все знания и союзников, вы находите тайный проход и спасаетесь!", true);
                }
                else
                {
                    ShowEnding(10, "Вы заблудились в коридорах и стали частью легенды поместья...", false);
                }
            }
            else
            {
                if (metAlly)
                {
                    ShowEnding(11, "Старейшина раскрывает вам древний секрет и помогает сбежать!", true);
                }
                else
                {
                    ShowEnding(12, "Старейшина отсутствует, и вы остаетесь в одиночестве в темноте...", false);
                }
            }
        }

        static void ShowEnding(int number, string message, bool isGood)
        {
            Console.WriteLine($"\n=== КОНЦОВКА #{number} ===");
            Console.WriteLine(message);
            Console.WriteLine(isGood ? "★ ХОРОШАЯ КОНЦОВКА ★" : "✖ ПЛОХАЯ КОНЦОВКА ✖");
            Console.WriteLine("\nСпасибо за игру!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        static int GetChoice(int min, int max)
        {
            int choice;
            while (true)
            {
                Console.Write("Ваш выбор: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine($"Пожалуйста, введите число от {min} до {max}.");
            }
        }
    }
}
