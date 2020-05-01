using System;
using System.Collections.Generic;
using System.IO;

namespace Snake
{
    class ReadPlayer
    {
        IEnumerable<string> _lines;
        public ReadPlayer(string filename)
        {
            _lines = File.ReadAllLines(filename);
        }
        public List<Player> ReadAllPlayers()
        {
            List<Player> players = new List<Player>();
            
            foreach (string line in _lines)
            {
                if(line != ";" && !string.IsNullOrEmpty(line))
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
                Console.WriteLine(player.Name + " has " + player.Score);
            } 
        }
    }
}
