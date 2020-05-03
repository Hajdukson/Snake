using System;

namespace Snake.RankingLogic
{
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public Player(string playerName)
        {
            Name = playerName;
        }
        public Player()
        {
         
        }

        //public int CompareTo(Player other)
        //{
        //   return this.Score.CompareTo(other.Score);
        //}
    }
}
