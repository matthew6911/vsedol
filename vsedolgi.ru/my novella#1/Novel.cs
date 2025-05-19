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

        static void Main()
        {
            Console.WriteLine("=== ТАЙНА ЗАБРОШЕННОГО ПОМЕСТЬЯ ===");
            Console.Write("Введите имя вашего персонажа: ");
            playerName = Console.ReadLine();

            Chapter1();
        }

        static void Chapter1()
        {
            while (true)
            {
                Console.WriteLine("\n=== ГЛАВА 1: ПРОБУЖДЕНИЕ ===");
                Console.WriteLine($"{playerName}, вы просыпаетесь в незнакомой комнате старинного поместья.");
                Console.WriteLine("1. Осмотреться вокруг");
                Console.WriteLine("2. Попробовать открыть дверь");
                Console.WriteLine("3. Кричать о помощи");
                Console.WriteLine("4. Выйти из игры");

                switch (GetChoice(1, 4))
                {
                    case 1:
                        Console.WriteLine("\nВ комнате вы видите:");
                        Console.WriteLine("1. Старый ключ на столе");
                        Console.WriteLine("2. Записку на подоконнике");
                        Console.WriteLine("3. Странный символ на стене");
                        Console.WriteLine("4. Вернуться");

                        switch (GetChoice(1, 4))
                        {
                            case 1:
                                hasKey = true;
                                Console.WriteLine("Вы взяли ключ. Он выглядит подходящим для двери.");
                                break;
                            case 2:
                                knowsSecret = true;
                                Console.WriteLine("На записке написано: 'Не доверяйте теням'.");
                                break;
                            case 3:
                                Console.WriteLine("Символ светится при вашем прикосновении!");
                                trustPoints++;
                                break;
                        }
                        break;

                    case 2:
                        if (hasKey)
                        {
                            Console.WriteLine("\nВы открываете дверь и попадаете в длинный коридор.");
                            Chapter2();
                            return;
                        }
                        Console.WriteLine("\nДверь заперта. Нужно найти ключ.");
                        break;

                    case 3:
                        Console.WriteLine("\nВаши крики привлекли внимание...");
                        Console.WriteLine("1. Продолжить звать на помощь");
                        Console.WriteLine("2. Затаиться");

                        if (GetChoice(1, 2) == 1)
                        {
                            ShowEnding(1, "Дверь распахивается, и вас хватают темные силуэты...", false);
                        }
                        else
                        {
                            Console.WriteLine("Шаги проходят мимо. Вы в безопасности... пока.");
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
            Console.WriteLine("\n=== ГЛАВА 2: КОРИДОР ТАЙН ===");
            Console.WriteLine("Перед вами три двери и лестница наверх:");
            Console.WriteLine("1. Красная дверь (помечена черепом)");
            Console.WriteLine("2. Синяя дверь (слышны голоса)");
            Console.WriteLine("3. Зеленая дверь (пахнет травами)");
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
            Console.WriteLine("\nЗа дверью - лаборатория алхимика.");
            Console.WriteLine("1. Исследовать стол");
            Console.WriteLine("2. Осмотреть книжную полку");
            Console.WriteLine("3. Выйти");

            switch (GetChoice(1, 3))
            {
                case 1:
                    if (knowsSecret)
                    {
                        ShowEnding(2, "Вы находите эликсир и используете его, чтобы покинуть поместье!", true);
                    }
                    else
                    {
                        ShowEnding(3, "Вы выпиваете неизвестную жидкость и превращаетесь в статую...", false);
                    }
                    break;
                case 2:
                    hasMap = true;
                    Console.WriteLine("Вы нашли карту поместья!");
                    Chapter2();
                    break;
            }
        }

        static void BlueDoor()
        {
            Console.WriteLine("\nВ комнате сидит старик.");
            Console.WriteLine("1. Заговорить с ним");
            Console.WriteLine("2. Атаковать его");
            Console.WriteLine("3. Уйти");

            switch (GetChoice(1, 3))
            {
                case 1:
                    metAlly = true;
                    Console.WriteLine("Старик оказывается бывшим хозяином поместья. Он дает вам совет.");
                    trustPoints += 2;
                    Chapter2();
                    break;
                case 2:
                    ShowEnding(4, "Старик оказывается призраком и забирает вашу душу...", false);
                    break;
                case 3:
                    Chapter2();
                    break;
            }
        }

        static void GreenDoor()
        {
            Console.WriteLine("\nВы в оранжерее с экзотическими растениями.");
            Console.WriteLine("1. Сорвать красный цветок");
            Console.WriteLine("2. Сорвать синий цветок");
            Console.WriteLine("3. Выйти");

            switch (GetChoice(1, 3))
            {
                case 1:
                    ShowEnding(5, "Цветок оживает и опутывает вас корнями...", false);
                    break;
                case 2:
                    Console.WriteLine("Цветок дает вам странное видение...");
                    trustPoints++;
                    Chapter2();
                    break;
                case 3:
                    Chapter2();
                    break;
            }
        }

        static void Stairs()
        {
            Console.WriteLine("\nПоднявшись, вы видите:");
            Console.WriteLine("1. Дверь в чердак");
            Console.WriteLine("2. Окно с возможностью выбраться");
            Console.WriteLine("3. Вернуться");

            switch (GetChoice(1, 3))
            {
                case 1:
                    Attic();
                    break;
                case 2:
                    if (trustPoints >= 3)
                    {
                        ShowEnding(6, "Вы выбираетесь через окно и оказываетесь в безопасности!", true);
                    }
                    else
                    {
                        ShowEnding(7, "Вы падаете и ломаете ногу... Тени приближаются...", false);
                    }
                    break;
                case 3:
                    Chapter2();
                    break;
            }
        }

        static void Attic()
        {
            Console.WriteLine("\nНа чердаке вы находите древний артефакт.");
            Console.WriteLine("1. Взять его");
            Console.WriteLine("2. Оставить");

            if (GetChoice(1, 2) == 1)
            {
                if (metAlly && hasMap)
                {
                    ShowEnding(8, "Артефакт переносит вас домой! Вы спасены!", true);
                }
                else
                {
                    ShowEnding(9, "Артефакт поглощает ваше сознание...", false);
                }
            }
            else
            {
                Console.WriteLine("Вы чувствуете, что сделали правильный выбор.");
                trustPoints++;
                FinalChoice();
            }
        }

        static void FinalChoice()
        {
            Console.WriteLine("\n=== ФИНАЛЬНЫЙ ВЫБОР ===");
            Console.WriteLine("1. Попытаться найти другой выход");
            Console.WriteLine("2. Вернуться к старику за советом");

            if (GetChoice(1, 2) == 1)
            {
                if (trustPoints >= 4)
                {
                    ShowEnding(10, "Используя все полученные знания, вы находите тайный выход!", true);
                }
                else
                {
                    Console.WriteLine("Вы блуждаете по коридорам...");
                    ShowEnding(11, "Поместье не отпускает вас... Вы становитесь его частью.", false);
                }
            }
            else
            {
                if (metAlly)
                {
                    ShowEnding(12, "Старик раскрывает вам последний секрет и помогает сбежать!", true);
                }
                else
                {
                    ShowEnding(13, "Старика нигде нет... Вы остаетесь один в темноте...", false);
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