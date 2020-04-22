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
        Snake _snake = new Snake();
        bool Exit = false;
        private bool outOfRange = false;
        private bool GameOver
        {
            get
            {
                return (_snake.Tail.Where(c => c.X == _snake.HeadPosition.X
                && c.Y == _snake.HeadPosition.Y).ToList().Count > 1) || outOfRange;
            }
        }
        public Game(string mode)
        {
            Board.DrawBoard();
            _fruit = new Fruit();
            StartGame(mode);
        }
        private void StartGame(string mode)
        {
            var frame = 40;

            while (!Exit)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Console.BufferWidth - 14, 6);
                Console.Write("POINTS: " + (_snake.Length - 5));

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    if (input.Key != ConsoleKey.Escape)
                        Control(input);
                    else
                        GameIsOver();
                }
                _snake.Move();

                if (mode == "GAME OVER WHEN SNAKE HIT THE WALL.")
                {
                    if (SnakeHitWallDie())
                        outOfRange = true;
                }
                else
                    SnakeHitWallAppearOpposite();

                if (_fruit.FruitCoordinate.X == _snake.HeadPosition.X && _fruit.FruitCoordinate.Y == _snake.HeadPosition.Y)
                {
                    _snake.EatFruit();
                    frame += 3;
                    _fruit = new Fruit();
                }

                if (GameOver == true)
                    GameIsOver();

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
        private bool SnakeHitWallDie()
        {
            if (_snake.HeadPosition.X < Board.Width && _snake.HeadPosition.Y < Board.Height + 1 &&
                _snake.HeadPosition.X > 0 && _snake.HeadPosition.Y > 0)
            { 
                    _snake.TailLogic();
            }
            else
                return true;

            return false;
        }
        private void SnakeHitWallAppearOpposite()
        {
            if (_snake.HeadPosition.X == Board.Width)
                _snake.HeadPosition.X = 1;
            if (_snake.HeadPosition.X == 0)
                _snake.HeadPosition.X = Board.Width - 1;
            if(_snake.HeadPosition.Y == Board.Height + 1)
                _snake.HeadPosition.Y = 1;
            if (_snake.HeadPosition.Y == 0)
                _snake.HeadPosition.Y = Board.Height;

            _snake.TailLogic();

        }
        private void GameIsOver()
        {
            Console.Clear();
            string info = $"YOUR SCORE: {_snake.Length - 5}. PRESS ENTER TO CONTIUNUE.";
            Console.SetCursorPosition((Console.WindowWidth - info.Length) / 2, Console.CursorTop);
            Console.WriteLine(info);

            foreach (var gameOverGraffitiElement in Graffiti.GameOver)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition((Console.WindowWidth - gameOverGraffitiElement.Length) / 2, Console.CursorTop);
                Console.WriteLine(gameOverGraffitiElement);
            }

            Exit = true;
            Console.ReadLine();
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
