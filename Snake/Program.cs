using System;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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
                string selectedItem = SelectItem(MenuItems);
                if (selectedItem == MenuItems.ElementAt(0))
                {
                    ConsoleColor color = ConsoleColor.Red;
                    while(true)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        DrawGraffiti(Graffiti.GameMode);
                        Console.WriteLine();
                        string line1 = "THE MORE FRUIT YOU EAT THE MORE SCORE YOU GET";
                        string line2 = "────────────────────────────────────────────────────────────────────────────────────";
                        Console.SetCursorPosition((Console.WindowWidth - line1.Length - 1) / 2,Console.CursorTop);
                        Console.WriteLine(line1);
                        Console.SetCursorPosition((Console.WindowWidth - line2.Length - 1) / 2,Console.CursorTop);
                        Console.WriteLine(line2); 
                        selectedItem = SelectItem(GameModeItems);
                        
                        if (selectedItem == GameModeItems.ElementAt(0))
                            break;
                        else if(selectedItem == GameModeItems.ElementAt(1))
                        { 
                            color = ConsoleColor.Blue;
                            break;
                        } 
                    }
                    Game game = new Game(selectedItem, color);
                }
                else if (selectedItem == MenuItems.ElementAt(2))
                {
                    Console.WriteLine();
                    DrawGraffiti(Graffiti.Introduction, ConsoleColor.Yellow);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    string notification = "Press any button to continue";
                    Console.SetCursorPosition((Console.WindowWidth - notification.Length) / 2, Console.CursorTop);
                    Console.WriteLine(notification.ToUpper());
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
                "INTRODUCTION",
                "EXIT",
            };
        static List<string> GameModeItems = new List<string>()
        {
            "THE GAME IS OVER WHEN SNAKE HIT THE WALL",
            " WALL DOES NOT KILL THE SNAKE"
        };

        static int _index = 0;
        static void DrawMenu()
        {
            DrawGraffiti(Graffiti.Logo);

            string[] instruction = { "USE UP AND DOWN ARROWS",
                                    "TO MOVE ABOVE THE MENU!",
                                    "DO NOT CHANGE THE WINDOW SIZE!"};
            DrawGraffiti(instruction);

            Console.WriteLine();
        }
        static string SelectItem(List<string> items)
        {
            string choose = null;
            for (int i = 0; i < items.Count; i++)
            {
                if (i == _index)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition((Console.WindowWidth - items[i].Length - 3) / 2, Console.CursorTop);
                    Console.Write(">");
                }
                else
                {
                    Console.ResetColor();
                }
                Console.SetCursorPosition((Console.WindowWidth - items[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(items[i]);
            }

            if (SetIndex(items))
            { 
                choose = items[_index];
                _index = 0;
            }

            return choose;
        }
        static bool SetIndex(List<string> items)
        {
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.DownArrow) _index++;
            else if (key.Key == ConsoleKey.UpArrow) _index--;

            if (_index > items.Count - 1) _index = 0;
            else if (_index < 0) _index = items.Count - 1;

            return key.Key == ConsoleKey.Enter;
        }
        static void DrawGraffiti(string[] graffiti, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (var line in graffiti)
            {
                Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line.ToUpper());
            }
        }
        
    }
}