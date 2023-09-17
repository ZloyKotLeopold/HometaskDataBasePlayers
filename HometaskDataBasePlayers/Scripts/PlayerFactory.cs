using System;
using System.Collections.Generic;

namespace HometaskDataBasePlayers.Scripts
{
    public class PlayerFactory
    {
        public Dictionary<int, Player> Players { get; private set; }
        public PlayerDatabaseManager PlayerManeger { get; private set; }
        private int _quantityPlayers;

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
            Players = PlayerManeger.AllPlayers;
        }
    }
}
