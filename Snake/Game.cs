using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Game
    {
        Fruit fruit = new Fruit();
        Snake snake = new Snake();
        bool Exit = false;
        public Game()
        {
            StartGame();
        }
        private void StartGame()
        {
            var frame = 40;
            
            while (!Exit)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.Escape:
                            IfGameIsOver();
                            continue;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                    }
                }
                snake.Move();

                if (fruit.FruitCoordinate.X == snake.HeadPosition.X && fruit.FruitCoordinate.Y == snake.HeadPosition.Y)
                {
                    snake.EatFruit();
                    fruit = new Fruit();
                    
                    frame += 1;
                }
                
                if (snake.GameOver == true)
                    IfGameIsOver();

                Thread.Sleep(10000 / frame);
            }

        }

        private void IfGameIsOver()
        {
            Console.Clear();
            string info = $"YOUR SCORE: {snake.Length - 5}. PRESS ANY KEY TO CONTIUNUE.";
            string[] gameOver = {"────────────────────────────────────────────────────────────────────────────────────",

                                 "─██████──────────██████─██████████████─██████████████─██████████████─████████████───",

                                 "─██░░██──────────██░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░░░██─██░░░░░░░░████─",

                                 "─██░░██──────────██░░██─██░░██████████─██████░░██████─██░░██████████─██░░████░░░░██─",

                                 "─██░░██──────────██░░██─██░░██─────────────██░░██─────██░░██─────────██░░██──██░░██─",

                                 "─██░░██──██████──██░░██─██░░██████████─────██░░██─────██░░██████████─██░░██──██░░██─",

                                 "─██░░██──██░░██──██░░██─██░░░░░░░░░░██─────██░░██─────██░░░░░░░░░░██─██░░██──██░░██─",

                                 "─██░░██──██░░██──██░░██─██████████░░██─────██░░██─────██░░██████████─██░░██──██░░██─",

                                 "─██░░██████░░██████░░██─────────██░░██─────██░░██─────██░░██─────────██░░██──██░░██─",

                                 "─██░░░░░░░░░░░░░░░░░░██─██████████░░██─────██░░██─────██░░██████████─██░░████░░░░██─",

                                 "─██░░██████░░██████░░██─██░░░░░░░░░░██─────██░░██─────██░░░░░░░░░░██─██░░░░░░░░████─",

                                 "─██████──██████──██████─██████████████─────██████─────██████████████─████████████───",

                                 "────────────────────────────────────────────────────────────────────────────────────" };
            Console.SetCursorPosition((Console.WindowWidth - info.Length) / 2, Console.CursorTop);
            Console.WriteLine(info);

            for (int i = 0; i < gameOver.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - gameOver[i].Length) / 2, Console.CursorTop);
                Console.WriteLine(gameOver[i]);
            }


            Exit = true;
            Console.ReadKey();
            Console.Clear();
        }
    }

}
