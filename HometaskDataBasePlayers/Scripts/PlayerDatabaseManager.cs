using System.Collections.Generic;

namespace HometaskDataBasePlayers.Scripts
{
    public class PlayerDatabaseManager
    {
        public PlayerFactory PlayerFactory { get; private set; }
        private Dictionary<int, Player> _allPlayers;

        public IReadOnlyDictionary<int, Player> ReadOnlyAllPlayers => _allPlayers;

        public PlayerDatabaseManager()
        {
            PlayerFactory = new PlayerFactory();
            _allPlayers = new Dictionary<int, Player>();
        }

        public void AddPlayer(int level, string name)
        {
            PlayerFactory.BuildNewPlayer.SetLevel(level);
            PlayerFactory.BuildNewPlayer.SetName(name);
            Player player = PlayerFactory.BuildNewPlayer.Build();

            if (_allPlayers.ContainsKey(player.Id)) 
                _allPlayers.Add(PlayerFactory.ReadOnlyPlayers.Count + 1, player);
            else
                _allPlayers.Add(player.Id, player);
        }     

        public void RemovePlayer(int id) => _allPlayers.Remove(id);

        public void InicializationPlayers() => _allPlayers = (Dictionary<int, Player>)PlayerFactory.ReadOnlyPlayers;
    }
}
