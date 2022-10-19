namespace Zametka
{
    internal class Program
    {
        static void Main()
        {
            ArrowsUD();
        }
        static void ArrowsUD(DateTime dayDate = new DateTime())
        {
            DateTime def = new DateTime();
            if (def == dayDate)
            {
                dayDate = new DateTime(2022, 10, 16);
            }
            int pozition = 0;
            Menu(dayDate);
            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow)
                {
                    pozition--;
                    if (pozition < 1)
                    {
                        pozition = 2;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    pozition++;
                    if (pozition > 2)
                    {
                        pozition = 1;
                    }
                }
                else if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow)
                {
                    ArrowsLR(key);
                    Console.Clear();
                }
                Console.Clear();
                Menu(dayDate);
                Console.SetCursorPosition(0, pozition);
                Console.WriteLine("->");
                key = Console.ReadKey();
            }
            Console.Clear();
            if (pozition == 1 || pozition == 2)
            {
                Menu(dayDate, pozition);
            }
        }
        static void ArrowsLR(ConsoleKeyInfo key, DateTime dayDate = new DateTime())
        {
            DateTime def = new DateTime();
            if (def == dayDate)
            {
                dayDate = new DateTime(2022, 10, 16);
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                while (key.Key != ConsoleKey.RightArrow)
                {
                    if (key.Key == ConsoleKey.LeftArrow)
                    {
                        Console.Clear();
                        dayDate = dayDate.AddDays(-1);

                        Menu(dayDate);
                        key = Console.ReadKey();
                        if (key.Key == ConsoleKey.DownArrow)
                        {
                            Console.Clear();
                            ArrowsUD(dayDate);
                        }
                        else if (key.Key == ConsoleKey.UpArrow)
                        {
                            Console.Clear();
                            ArrowsUD(dayDate);
                        }
                    }
                    Console.Clear();
                }
                Console.Clear();
                ArrowsLR(key, dayDate);
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                while (key.Key != ConsoleKey.LeftArrow)
                {
                    if (key.Key == ConsoleKey.RightArrow)
                    {
                        Console.Clear();
                        dayDate = dayDate.AddDays(+1);
                        Menu(dayDate);
                        key = Console.ReadKey();
                        if (key.Key == ConsoleKey.DownArrow)
                        {
                            Console.Clear();
                            ArrowsUD(dayDate);
                        }
                        else if (key.Key == ConsoleKey.UpArrow)
                        {
                            Console.Clear();
                            ArrowsUD(dayDate);
                        }
                    }
                    Console.Clear();
                }
                Console.Clear();
                ArrowsLR(key, dayDate);
            }
            key = Console.ReadKey();
        }
        static void Menu(DateTime dayDate = new DateTime(), int position = 0)
        {
            DateTime def = new DateTime();
            if (def == dayDate)
            {
                dayDate = new DateTime(2022, 10, 16);
            }
            Notes first_note = new Notes()
            {
                Name = "   сходить в мпт",
                Description = "Crazy shiting on the floor",
                Created = new DateTime(2022, 10, 15)
            };
            Notes second_note = new Notes()
            {
                Name = "   Покибербулть Софу",
                Description = "Сказать ей что она быдло \r\n" +
                    "и сказать ей на ушко что я люто дристать",
                Created = new DateTime(2022, 10, 15)
            };
            Notes third_note = new Notes()
            {
                Name = "   Сходить за пивом",
                Description = "Купить темный Kozel",
                Created = new DateTime(2022, 10, 14)
            };
            Notes six_note = new Notes()
            {
                Name = "   Сходить в лес",
                Description = "поговорить с уточками",
                Created = new DateTime(2022, 10, 14)
            };
            Notes fourth_note = new Notes()
            {
                Name = "   Купить хлеб",
                Description = "белый батон в магзине у дома",
                Created = new DateTime(2022, 10, 16)
            };
            Notes fifth_note = new Notes()
            {
                Name = "   Сходить в кино",
                Description = "посмотреть фильм Дюна",
                Created = new DateTime(2022, 10, 16)
            };
            List<Notes> dayList1 = new List<Notes>()
            {
                first_note, second_note, third_note, fourth_note, fifth_note, six_note 
            };
            List<Notes> newDayList = dayList1.Where(x => x.Created == dayDate).OrderByDescending(x => x.Created).ToList();
            if (position == 0)
            {
                Console.WriteLine(dayDate);
                foreach (Notes day in newDayList)
                {
                    Console.WriteLine(day.Name);
                }
            }
            else
            {
                Notes selectNote = newDayList[position - 1];
                Console.WriteLine(selectNote.Name);
                Console.WriteLine("----------------------");
                Console.WriteLine(selectNote.Description);
                Console.WriteLine("Дата окончания: " + selectNote.Created);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    ArrowsUD(dayDate);
                }
                else
                {
                    while (key.Key != ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Menu(dayDate, position);
                    }
                }
            }

        }

    }
}