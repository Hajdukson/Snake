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
            Console.SetWindowSize(120,30);
            Console.SetBufferSize(120, 30);
            Console.CursorVisible = false;
            List<string> MenuItem = new List<string>(){
                "START THE GAME",
                "SHOW RECORDS",
                "INSTRUCTIONS",
                "EXIT",
            };

            while (true)
            {
                Console.Clear();
                string selectedItem = DrawMenu(MenuItem);
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

        static int _index = 0;
        private static string DrawMenu(List<string> items)
        {
            
            Console.ForegroundColor = ConsoleColor.White;
            string[] instruction = { "USE UP AND DOWN ARROW",
                                    "TO MOVE ABOVE THE MENU!"};
            Console.SetCursorPosition((Console.WindowWidth - instruction.Length - 20) / 2, Console.CursorTop);
            Console.WriteLine(instruction[0]);
            Console.SetCursorPosition((Console.WindowWidth - instruction[1].Length) / 2, Console.CursorTop);
            Console.WriteLine(instruction[1]);

            Console.WriteLine();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == _index)
                {
                    Console.SetCursorPosition((Console.WindowWidth - items[i].Length - 4) / 2, Console.CursorTop);
                    Console.Write(">   ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.SetCursorPosition((Console.WindowWidth - items[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(items[i]);
            }
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.DownArrow) _index++;
            else if (key.Key == ConsoleKey.UpArrow) _index--;
            else if (key.Key == ConsoleKey.Enter) return items[_index];

            if (_index == items.Count)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                _index = 0;
            }
            else if (_index < 0)
            { 
                Console.BackgroundColor = ConsoleColor.Black;
                _index = items.Count - 1;
            }

            return "";
        }
    }
}