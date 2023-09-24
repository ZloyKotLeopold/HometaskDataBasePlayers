using System;
using System.Collections.Generic;

namespace HometaskDataBasePlayers.Scripts
{
    public class PlayerFactory
    {
        private Dictionary<int, Player> _players;
        public PlayerBuilder BuildNewPlayer { get; private set; }
        private int _quantityPlayers;

        public IReadOnlyDictionary<int, Player> ReadOnlyPlayers => _players;

        public PlayerFactory()
        {
            _players = new Dictionary<int, Player>();
            BuildNewPlayer = new PlayerBuilder();
        }

        public void FillingDataBase(int quantityPlayers)
        {
            Random random = new Random();

            _quantityPlayers = quantityPlayers;

            string[] names = new string[]
            {
              "John",
              "Alice",
              "Bob",
              "Eva",
              "Michael",
              "Olivia",
              "William",
              "Sophia",
              "James",
              "Emily",
              "Benjamin",
              "Emma",
              "Daniel",
              "Ava",
              "Joseph",
              "Mia",
              "Henry",
              "Charlotte",
              "Samuel",
              "Liam"
            };

            for (int i = 0; i < _quantityPlayers; i++)
            {
                int randomLevel = random.Next(1, 100);
                string randomName = names[random.Next(0, 20)];
                AddPlayer(randomLevel, randomName);
            }
        }

        private void AddPlayer(int level, string name) //PlayerFactory ничего не знает о PlayerDatabaseManager по этому метод почти дублируется с PlayerDatabaseManager
        {
            BuildNewPlayer.SetLevel(level);
            BuildNewPlayer.SetName(name);
            Player player = BuildNewPlayer.Build();

            if (_players.ContainsKey(player.Id))
                _players.Add(_players.Count + 1, player);
            else
                _players.Add(player.Id, player);
        }
    }
}