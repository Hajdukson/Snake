using Snake.RankingLogic;
using System;
using System.Linq;
using System.Threading;

namespace Snake.GameLogic
{
    class Game
    {
        WritePlayer _writePlayer;
        Fruit _fruit;
        Player _player;
        Board _board = new Board();
        Snake _snake = new Snake();
        bool Exit = false;
        private bool outOfRange = false;
        private int points = 0;
        private bool GameOver
        {
            get
            {
                return (_snake.Tail.Where(c => c.X == _snake.HeadPosition.X
                && c.Y == _snake.HeadPosition.Y).ToList().Count > 1) || outOfRange;
            }
        }
        public Game(string mode, string playerName, string filePath, ConsoleColor boardColor = ConsoleColor.Red)
        {
            _writePlayer = new WritePlayer(filePath);
            _player = new Player(playerName);
            _board.DrawBoard(boardColor);
            Console.CursorVisible = false;
            _fruit = new Fruit();
            StartGame(mode);
        }
        private void StartGame(string mode)
        {
            var frame = 40;

            while (!Exit)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Console.BufferWidth - 16, 8);
                Console.Write("PLAYER " + _player.Name);
                Console.SetCursorPosition(Console.BufferWidth - 13, 9);
                Console.Write("SCORE:" + points);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    if (input.Key != ConsoleKey.Escape)
                        Control(input);
                    else
                        GameIsOver();
                }

                _snake.Move();

                if (mode == "WALL KILLS THE SNAKE")
                {
                    if (SnakeHitWallDie())
                        outOfRange = true;
                }
                else
                    SnakeHitWallAppearOpposite();

                _snake.TailLogic();

                if (_fruit.FruitCoordinate.X == _snake.HeadPosition.X && _fruit.FruitCoordinate.Y == _snake.HeadPosition.Y)
                {
                    points++;
                    _fruit = new Fruit();
                    while (FruitRespOnSnakeTail(_fruit) == true)
                    {
                        Console.SetCursorPosition(_fruit.FruitCoordinate.X, _fruit.FruitCoordinate.Y);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("█");
                        _fruit = new Fruit();
                    }
                    _snake.EatFruit();
                    frame += 1;
                }

                if (GameOver == true)
                    GameIsOver();

                Thread.Sleep(10000 / frame);
                
            }
        }
        private bool FruitRespOnSnakeTail(Fruit fruit)
        {
            foreach (Coordinate tailElement in _snake.Tail)
            {
                if (tailElement.X == fruit.FruitCoordinate.X && tailElement.Y == fruit.FruitCoordinate.Y)
                    return true;
            }
            return false;
        }
        private bool SnakeHitWallDie()
        {
            if (_snake.HeadPosition.X < _board.Width && _snake.HeadPosition.Y < _board.Height + 1 &&
                _snake.HeadPosition.X > 0 && _snake.HeadPosition.Y > 0)
                return false;

            return true;
        }
        private void SnakeHitWallAppearOpposite()
        {
            if (_snake.HeadPosition.X == _board.Width)
                _snake.HeadPosition.X = 1;
            if (_snake.HeadPosition.X == 0)
                _snake.HeadPosition.X = _board.Width - 1;
            if (_snake.HeadPosition.Y == _board.Height + 1)
                _snake.HeadPosition.Y = 1;
            if (_snake.HeadPosition.Y == 0)
                _snake.HeadPosition.Y = _board.Height;
        }
        private void GameIsOver()
        {
            Console.SetWindowSize(120, 30);
            Console.SetBufferSize(120, 30);
            Console.Clear();
            string info = $"YOUR SCORE: {_snake.Length - 5}. PRESS ENTER TO CONTIUNUE.";
            Console.SetCursorPosition((Console.WindowWidth - info.Length) / 2, Console.CursorTop);
            Console.WriteLine(info);

            GlobalFunctions.DrawGraffiti(Graffiti.GameOver, ConsoleColor.Red);

            _writePlayer.OverwritePlayerOrAddNewPlayer(_player.Name, _snake);
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
