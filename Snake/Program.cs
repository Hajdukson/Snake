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
        static Game _game;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120,30);
            Console.SetBufferSize(120, 30);

            while (true)
            {
                Console.Clear();
                string selectedItem = DrawMenu();
                if (selectedItem == "START THE GAME")
                {
                    Console.Clear();
                    _game = new Game();
                }
                else if (selectedItem == "INSTRUCTIONS")
                {
                    Console.Clear();
                    Console.WriteLine("THE SNAKE IS ... \n" +
                        "PRESS ANY KEY TO CONTINUE.");
                    Console.ReadKey();
                }
                else if (selectedItem == "EXIT")
                    Environment.Exit(0);
            }
        }
        static List<string> MenuItems = new List<string>(){
                "START THE GAME",
                "SHOW RECORDS",
                "INSTRUCTIONS",
                "EXIT",
            };

        static int _index = 0;
        static string DrawMenu()
        {
            string choose = null;

            Console.ForegroundColor = ConsoleColor.White;

            foreach (var line in Graffiti.Logo)
            {
                Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }
           
            string[] instruction = { "USE UP AND DOWN ARROW",
                                    "TO MOVE ABOVE THE MENU!",
                                    "DO NOT CHANGE THE WINDOW SIZE!"};
            Console.SetCursorPosition((Console.WindowWidth - instruction[0].Length) / 2, Console.CursorTop);
            Console.WriteLine(instruction[0]);
            Console.SetCursorPosition((Console.WindowWidth - instruction[1].Length) / 2, Console.CursorTop);
            Console.WriteLine(instruction[1]);
            Console.SetCursorPosition((Console.WindowWidth - instruction[2].Length) / 2, Console.CursorTop);
            Console.WriteLine(instruction[2]);

            Console.WriteLine();

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

            return (key.Key == ConsoleKey.Enter);
        }
    }
}