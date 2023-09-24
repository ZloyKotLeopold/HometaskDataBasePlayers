namespace HometaskDataBasePlayers.Scripts
{ 
    public class Player
    {
        public int Id { get; private set; }
        public int Level { get; private set; }
        public string Name { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(int id, int level, string name)
        {
            Id = id;
            Level = level;
            Name = name;
            IsBanned = false;
        }

        public void GiveBanPlayer()
        {
            IsBanned = true;
        }

        public void RemoveBanPlayer()
        {
            IsBanned = false;
        }
    }
}
