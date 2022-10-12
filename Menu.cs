using System;

namespace Daijou
{
    class Menu
    {
        public int selectedIndex;
        public List<Task> userTasks;

        public Menu(List<Task> userTasks)
        {
            this.userTasks = userTasks;
            selectedIndex = 0;
        }

        public void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("Daijou - Daily Journal");
                for (var i = 0; i < userTasks.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($"{userTasks[i].taskID}. {userTasks[i].taskName}");
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                var input = Console.ReadKey();

                if (input.Key is ConsoleKey.DownArrow)
                {
                    if (selectedIndex < userTasks.Count - 1) selectedIndex++;
                }

                if (input.Key is ConsoleKey.UpArrow)
                {
                    if (selectedIndex > 0) selectedIndex--;
                }

                if (input.Key is ConsoleKey.A)
                {
                    Program.AddTask();
                }

                if (input.Key is ConsoleKey.R)
                {
                    Program.RemoveTask();
                }

                if (input.Key is ConsoleKey.E)
                {
                    Program.EditTask();
                }

                if (input.Key is ConsoleKey.Enter)
                {
                    Console.Clear();
                    Program.ViewTaskDetails();
                }

                if (input.Key is ConsoleKey.Escape)
                {
                    Program.SaveDataToFile();
                    Environment.Exit(0);
                }

                Console.Clear();
            }
        }

    }
}