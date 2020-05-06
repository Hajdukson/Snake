using System;
using System.IO;
using System.Collections.Generic;

namespace Snake.RankingLogic
{
    class WritePlayer
    {
        private string _filePath;
        public WritePlayer(string filename)
        {
            _filePath = filename;
        }
        public void OverwritePlayerOrAddNewPlayer(string name, Snake.GameLogic.Snake snake)
        {
            ReadPlayer read = new ReadPlayer(_filePath);
            List<Player> players = read.ReadAllPlayers();
            
            int recentScore = snake.Length - 5;
            string line = name + ";" + recentScore + Environment.NewLine;

            Player find = players.Find(player => player.Name == name);

            if (find == null)
                File.AppendAllText(_filePath, line);
            else if (find.Score < recentScore)
            {
                find.Score = recentScore;
                File.WriteAllLines(_filePath, PlayersToString(players));
            }     
        }
        private IEnumerable<string> PlayersToString(IEnumerable<Player> players)
        {
            List<string> lines = new List<string>(); 
            foreach (var player in players)
            {
                string line = player.Name + ";" + player.Score;
                lines.Add(line);
            }
            return lines;
        }
        public void SaveOnlyTop10(List<Player> players)
        {
            if (players.Count > 10)
            {
                players.RemoveAt(10);
                File.WriteAllLines(_filePath, PlayersToString(players));
            }
        }

    }
}
