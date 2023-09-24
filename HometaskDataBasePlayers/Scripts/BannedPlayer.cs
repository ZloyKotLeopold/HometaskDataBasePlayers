using System;

namespace HometaskDataBasePlayers.Scripts
{
    public class BannedPlayer
    {
        private Player _player;

        private bool TryGetPlayer(PlayerFactory playerFactory, int id)
        {
            if (playerFactory.ReadOnlyPlayers.TryGetValue(id, out _player))
                return true;

            Console.WriteLine("Такого игрока нет.");
            return false;
        }

        public void PlayerGiveBan(PlayerFactory playerFactory, int id)
        {
            if (TryGetPlayer(playerFactory, id))
                _player.GiveBanPlayer();
        }

        public void PlayerRemoveBan(PlayerFactory playerFactory, int id)
        {
            if (TryGetPlayer(playerFactory, id))
                _player.RemoveBanPlayer();
        }
    }
}
