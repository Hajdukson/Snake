using Snake.GameLogic;
using Snake.RankingLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Snake
{
    //main class which is responsible for a game menu
    class Program
    {
        //creats a paht where is a file with players scores 
        static string PathToDb()
        {
            string pathToProject = Assembly.GetExecutingAssembly().Location;
            string _filePath = pathToProject.Substring(0, pathToProject.Length - 19) + "ranking.csv";
            return _filePath;
        }
        /////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            Console.Title = "Snake";
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 30);
            Console.SetBufferSize(120, 30);

            Game _game;

            while (true)
            {
                Found:
                Console.Clear();
                DrawMenuGraphs();
                string selectedItem = SelectItem(MenuItems);
                if (selectedItem == MenuItems.ElementAt(0))
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        GlobalFunctions.DrawGraffiti(Graffiti.GameMode);
                        Console.WriteLine();

                        string line1 = "THE MORE FRUIT YOU EAT THE MORE SCORE YOU GET";
                        string line2 = "────────────────────────────────────────────────────────────────────────────────────";
                        string name = "ENTER PLAYER NAME: ";

                        Console.SetCursorPosition((Console.WindowWidth - line1.Length - 1) / 2, Console.CursorTop);
                        Console.WriteLine(line1);
                        Console.SetCursorPosition((Console.WindowWidth - line2.Length - 1) / 2, Console.CursorTop);
                        Console.WriteLine(line2);

                        selectedItem = SelectItem(GameModeItems);

                        if (!string.IsNullOrEmpty(selectedItem))
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition((Console.WindowWidth - name.Length - 1) / 2, Console.CursorTop);
                            Console.Write(name);


                            if (selectedItem == GameModeItems.ElementAt(0))
                            {
                                Console.CursorVisible = true;
                                name = Console.ReadLine();
                                if (!Max9Char(name))
                                    continue;
                                _game = new Game(selectedItem, name, PathToDb(), ConsoleColor.Blue);
                                break;
                            }
                            else if (selectedItem == GameModeItems.ElementAt(1))
                            {
                                Console.CursorVisible = true;
                                name = Console.ReadLine();
                                if(!Max9Char(name))
                                    continue;
                                _game = new Game(selectedItem, name, PathToDb());
                                break;
                            }
                            else if(selectedItem == GameModeItems.ElementAt(2))
                                goto Found;
                        }
                    }
                }
                else if (selectedItem == MenuItems.ElementAt(1))
                {
                    ReadPlayer readPlayer = new ReadPlayer(PathToDb());
                    Console.Clear();
                    GlobalFunctions.DrawGraffiti(Graffiti.Ranking);
                    readPlayer.DisplayTop10();
                }
                else if (selectedItem == MenuItems.ElementAt(2))
                {
                    Console.WriteLine();
                    GlobalFunctions.DrawGraffiti(Graffiti.Introduction, ConsoleColor.Yellow);
                    GlobalFunctions.PressButton();
                }
                else if (selectedItem == MenuItems.ElementAt(3))
                    Environment.Exit(0);
            }
        }
        /////////////////////////////////////////////////////////////////////////////
        static bool Max9Char(string name)
        {
            if(name.Length > 9)
            {
                Console.CursorVisible = false;
                string notyfication = "PLAYERNAME SHOULD HAVE MAX 9 LETTERS";
                Console.SetCursorPosition((Console.WindowWidth - notyfication.Length) / 2, Console.CursorTop + 1);
                Console.Write(notyfication);
                GlobalFunctions.PressButton();
                return false;
            }
            return true;
        }
        static List<string> MenuItems = new List<string>(){
                "START THE GAME",
                "SHOW RECORDS",
                "INTRODUCTION",
                "EXIT",
            };
        static List<string> GameModeItems = new List<string>()
        {
            "WALL DOES NOT KILL THE SNAKE",
            "WALL KILLS THE SNAKE",
            "BACK"
        };
        static int _index = 0;
        static void DrawMenuGraphs()
        {
            GlobalFunctions.DrawGraffiti(Graffiti.Logo);
            GlobalFunctions.DrawGraffiti(Graffiti.Instruction);
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
    }
}