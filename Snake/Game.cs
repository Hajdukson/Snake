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
        Fruit _fruit;
        readonly Board _board;
        Snake _snake = new Snake();
        bool Exit = false;
        private bool outOfRange = false;
        public bool GameOver
        {
            get
            {
                return (_snake.Tail.Where(c => c.X == _snake.HeadPosition.X
                && c.Y == _snake.HeadPosition.Y).ToList().Count > 1) || outOfRange;
            }
        }
        public Game()
        {
            _board = new Board();
            _fruit = new Fruit();
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
                _snake.Move();

                if (_snake.HeadPosition.X < Board.Width && _snake.HeadPosition.Y < Board.Height + 1 && 
                    _snake.HeadPosition.X > 0 && _snake.HeadPosition.Y > 0)
                {
                    Console.SetCursorPosition(_snake.HeadPosition.X, _snake.HeadPosition.Y);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("@");
                    _snake.Tail.Add(new Coordinate(_snake.HeadPosition.X, _snake.HeadPosition.Y));
                    if (_snake.Tail.Count > _snake.Length)
                    {
                        var endTail = _snake.Tail.First();
                        Console.SetCursorPosition(endTail.X, endTail.Y);
                        Console.Write(" ");
                        _snake.Tail.Remove(endTail);
                    }
                }
                else
                    outOfRange = true;
                

                if (_fruit.FruitCoordinate.X == _snake.HeadPosition.X && _fruit.FruitCoordinate.Y == _snake.HeadPosition.Y)
                {
                    _snake.EatFruit();
                    frame += 1;
                    _fruit = new Fruit();
                }
 
                
                if (GameOver == true || outOfRange == true)
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
            string info = $"YOUR SCORE: {_snake.Length - 5}. PRESS ENTER TO CONTIUNUE.";
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
                    _snake.Direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    _snake.Direction = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    _snake.Direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    _snake.Direction = Direction.Down;
                    break;
            }
        }
    }

}
