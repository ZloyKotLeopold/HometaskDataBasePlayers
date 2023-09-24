using System;
using System.Collections.Generic;

namespace HometaskDataBasePlayers.Scripts
{
    public class PlayerFactory
    {
        private Dictionary<int, Player> Players;
        public PlayerDatabaseManager PlayerManeger { get; private set; }
        private int _quantityPlayers;

        public IReadOnlyDictionary<int, Player> ReadOnlyPlayers => Players;

        public PlayerFactory()
        {
            PlayerManeger = new PlayerDatabaseManager();
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
                PlayerManeger.AddPlayer(randomLevel, randomName);
            }

            InicializationPlayers();
        }

        public void InicializationPlayers()
        {
            Players = (Dictionary<int, Player>)PlayerManeger.ReadOnlyAllPlayers;
        }
    }
}
