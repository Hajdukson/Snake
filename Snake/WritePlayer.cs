using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class WritePlayer
    {
        private string _fileName;
        public WritePlayer(string filename)
        {
            _fileName = filename;
        }
        public void CheckPlayer(string name, Snake snake)
        {
            ReadPlayer read = new ReadPlayer(_fileName);
            List<Player> players = read.ReadAllPlayers();
            int recentScore = snake.Length - 5;
            string line = name + ";" + recentScore + Environment.NewLine;

            if (players != null)
            {
                foreach (var player in players)
                {
                    if (player.Name == name)
                    {
                        if (player.Score < recentScore)
                            player.Score = recentScore;
                    }
                    else
                    {
                        File.AppendAllText(_fileName, line);
                        break;
                    }
                }
            }
        }
    }
}
