using System;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        /////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            Console.Title = "Snake";
            Console.CursorVisible = false;
            Console.SetWindowSize(120,30);
            Console.SetBufferSize(120, 30);

            while (true)
            {
                Console.Clear();
                DrawMenu();
                string selectedItem = SelectMenuItem();
                if (selectedItem == MenuItems.ElementAt(0))
                {
                    Console.Clear();
                    Game game = new Game();
                }
                else if (selectedItem == MenuItems.ElementAt(2))
                {
                    Console.Clear();
                    Console.WriteLine("THE SNAKE IS ... \n" +
                        "PRESS ANY KEY TO CONTINUE.");
                    Console.ReadKey();
                }
                else if (selectedItem == MenuItems.ElementAt(3))
                    Environment.Exit(0);
            }
        }

        /////////////////////////////////////////////////////////////////////////////

        static List<string> MenuItems = new List<string>(){
                "START THE GAME",
                "SHOW RECORDS",
                "INSTRUCTIONS",
                "EXIT",
            };

        static int _index = 0;
        static void DrawMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;

            foreach (var line in Graffiti.Logo)
            {
                Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }
           
            string[] instruction = { "USE UP AND DOWN ARROWS",
                                    "TO MOVE ABOVE THE MENU!",
                                    "DO NOT CHANGE THE WINDOW SIZE!"};
            foreach (var line in instruction)
            {
                Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }

            Console.WriteLine();
        }
        static string SelectMenuItem()
        {
            string choose = null;
            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (i == _index)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition((Console.WindowWidth - MenuItems[i].Length - 3) / 2, Console.CursorTop);
                    Console.Write(">");
                }
                else
                {
                    Console.ResetColor();
                }
                Console.SetCursorPosition((Console.WindowWidth - MenuItems[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(MenuItems[i]);
            }

            if (SetIndex())
                choose = MenuItems[_index];

            return choose;
        }
        static bool SetIndex()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.DownArrow) _index++;
            else if (key.Key == ConsoleKey.UpArrow) _index--;

            if (_index > MenuItems.Count - 1) _index = 0;
            else if (_index < 0) _index = MenuItems.Count - 1;

            return key.Key == ConsoleKey.Enter;
        }
    }
}