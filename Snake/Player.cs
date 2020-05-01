namespace Snake
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
    }
}
