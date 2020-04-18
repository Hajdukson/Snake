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
        private bool outOfRange = false;
        public bool GameOver
        {
            get
            {
                return (snake.Tail.Where(c => c.X == snake.HeadPosition.X
                && c.Y == snake.HeadPosition.Y).ToList().Count > 1) || outOfRange;
            }
        }
        public Game()
        {
            Board board = new Board();
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
                    if (input.Key != ConsoleKey.Escape)
                        Control(input);
                    else
                        IfGameIsOver();
                }
                snake.Move();
                try
                {
                    Console.SetCursorPosition(snake.HeadPosition.X, snake.HeadPosition.Y);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("@");
                    snake.Tail.Add(new Coordinate(snake.HeadPosition.X, snake.HeadPosition.Y));
                    if (snake.Tail.Count > snake.Length)
                    {
                        var endTail = snake.Tail.First();
                        Console.SetCursorPosition(endTail.X, endTail.Y);
                        Console.Write(" ");
                        snake.Tail.Remove(endTail);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    outOfRange = true;
                }

                if (fruit.FruitCoordinate.X == snake.HeadPosition.X && fruit.FruitCoordinate.Y == snake.HeadPosition.Y)
                {
                    snake.EatFruit();
                    fruit = new Fruit();

                    frame += 1;
                }
                
                if (GameOver == true)
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
        private void Control(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
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
    }

}
