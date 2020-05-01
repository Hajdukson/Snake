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
            Console.WriteLine(players.Count());
            int recentScore = snake.Length - 5;
            string line = name + ";" + recentScore + Environment.NewLine;

            Player find = players.Find(player => player.Name == name);

            if (find == null)
                File.AppendAllText(_fileName, line);
            else
            {
                Console.WriteLine(find.Score);
                if (find.Score < recentScore)
                    find.Score = recentScore;
                
                File.WriteAllLines(_fileName, PlatersToString(players));
            }    
        }
        private IEnumerable<string> PlatersToString(IEnumerable<Player> players)
        {
            List<string> lines = new List<string>(); 
            foreach (var player in players)
            {
                string line = player.Name + ";" + player.Score;
                lines.Add(line);
            }
            return lines;
        }
    }
}
