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
        Fruit fruit;
        Snake snake = new Snake();
        bool Exit = false;
        public Game()
        {
            fruit = new Fruit();
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
        //private bool FruitRespOnSnakeTail(Fruit fruit)
        //{
        //    foreach(Coordinate tailElement in snake.Tail)
        //    {
        //        if (tailElement.X == fruit.FruitCoordinate.X && tailElement.Y == fruit.FruitCoordinate.X)
        //            return true;
        //    }
        //    return false;
        //}

        private void IfGameIsOver()
        {
            Console.Clear();
            string info = $"YOUR SCORE: {snake.Length - 5}. PRESS ENTER TO CONTIUNUE.";
            Console.SetCursorPosition((Console.WindowWidth - info.Length) / 2, Console.CursorTop);
            Console.WriteLine(info);

            foreach (var gameOverGraffitiElement in Graffiti.GameOver)
            {
                Console.SetCursorPosition((Console.WindowWidth - gameOverGraffitiElement.Length) / 2, Console.CursorTop);
                Console.WriteLine(gameOverGraffitiElement);
            }

            Exit = true;
            Console.ReadLine();
            Console.Clear();
        }
    }

}
