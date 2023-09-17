namespace HometaskDataBasePlayers.Scripts
{
    public class PlayerBuilder
    {
        private int _level;
        private string _name;
        private int _id;
        public Player Player { get; private set; }

        public PlayerBuilder SetLevel(int level)
        {
            int minLevel = 0;
            int maxLevel = 100;

            if (level > minLevel && level < maxLevel)
                _level = level;
            return this;
        }

        public PlayerBuilder SetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _name = name;
            else
                _name = "nameless";
            return this;
        }

        public Player Build()
        {
            _id++;
            Player = new Player(_id, _level, _name);
            return Player;
        }
    }
}
