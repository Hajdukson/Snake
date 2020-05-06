using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Snake.RankingLogic
{
    class ReadPlayer
    {
        private string _filePath;
        public ReadPlayer(string filePathe)
        {
            _filePath = filePathe;
        }
        public List<Player> ReadAllPlayers()
        {
            IEnumerable<string> lines = File.ReadAllLines(_filePath);

            List<Player> players = new List<Player>();

            foreach (string line in lines)
            {
                if(!string.IsNullOrEmpty(line))
                { 
                    string[] playerItems = line.Split(';');

                    players.Add(new Player { Name = playerItems[0], Score = int.Parse(playerItems[1]) });
                }
            }
            return players;
        }
        public void DisplayTop10()
        {
            List<Player> players = ReadAllPlayers();
            WritePlayer write = new WritePlayer(_filePath);

            players = players.OrderByDescending(p=>p.Score).ToList();

            write.SaveOnlyTop10(players);

            for (int i = 0; i < players.Count; i++)
            {
                if (i < 3)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition((Console.WindowWidth - 30) / 2, 3 + i);
                Console.Write(i + 1 + ".");
                Console.SetCursorPosition((Console.WindowWidth - players[i].Name.Length - 13) / 2, 3 + i);
                Console.Write(players[i].Name);
                Console.SetCursorPosition((Console.WindowWidth - players[i].Score.ToString().Length) / 2 + 8, 3 + i);
                Console.Write(players[i].Score);
                if (i == 9)
                    break;
            }
            GlobalFunctions.PressButton(14);
        }
    }
}
