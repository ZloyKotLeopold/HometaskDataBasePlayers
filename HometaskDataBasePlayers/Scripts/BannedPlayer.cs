using System;

namespace HometaskDataBasePlayers.Scripts
{
    public class BannedPlayer
    {
        private Player _player;

        private bool TryGetPlayer(PlayerDatabaseManager databaseManager, int id)
        {
            if (databaseManager.ReadOnlyAllPlayers.TryGetValue(id, out _player))
                return true;

            Console.WriteLine("Такого игрока нет.");
            return false;
        }

        public void PlayerGiveBan(PlayerDatabaseManager databaseManager, int id)
        {
            if (TryGetPlayer(databaseManager, id))
                _player.GiveBanPlayer();
        }

        public void PlayerRemoveBan(PlayerDatabaseManager databaseManager, int id)
        {
            if (TryGetPlayer(databaseManager, id))
                _player.RemoveBanPlayer();
        }
    }
}
