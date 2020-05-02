using System;
using System.Collections.Generic;
using System.IO;

namespace Snake.RankingLogic
{
    class ReadPlayer
    {
        private string _filename;
        public ReadPlayer(string filename)
        {
            _filename = filename;
        }
        public List<Player> ReadAllPlayers()
        {
            IEnumerable<string> lines = File.ReadAllLines(_filename);

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
            IEnumerable<Player> players = ReadAllPlayers();

            foreach (var player in players)
            {
                //string name = player.Name;
                //int score = player.Score;
                //Console.SetCursorPosition((Console.WindowWidth - name.Length) / 2, Console.CursorTop);
                //Console.WriteLine(name);
                //Console.SetCursorPosition((Console.WindowWidth score.Length) / 2, Console.CursorTop);
                //Console.WriteLine(score);
            } 
        }
    }
}
