using System.Collections.Generic;

namespace HometaskDataBasePlayers.Scripts
{
    public class PlayerDatabaseManager
    {
        private PlayerBuilder _newPlayer;
        private Dictionary<int, Player> AllPlayers;

        public IReadOnlyDictionary<int, Player> ReadOnlyAllPlayers => AllPlayers;

        public PlayerDatabaseManager()
        {
            AllPlayers = new Dictionary<int, Player>();
            _newPlayer = new PlayerBuilder();
        }

        public void AddPlayer(int level, string name)
        {
            _newPlayer.SetLevel(level);
            _newPlayer.SetName(name);
            Player player = _newPlayer.Build();
            AllPlayers.Add(player.Id, player);
        }
        public void AddPlayer(Player player)
        {
            if (AllPlayers.ContainsKey(player.Id))
            {
                RemovePlayer(player.Id);
                AllPlayers.Add(player.Id, player);
            }
        }

        public void RemovePlayer(int id) => AllPlayers.Remove(id);
    }
}
