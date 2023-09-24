using System;

namespace HometaskDataBasePlayers.Scripts
{
    public class BannedPlayer
    {
        private const string MESSAGE_NO_PLAYER = "Такого игрока нет.";
        private Player _player;

        private bool TryGetPlayer(PlayerDatabaseManager databaseManager, int id)
        {
            if (databaseManager.ReadOnlyAllPlayers.TryGetValue(id, out _player))
                return true;

            Console.WriteLine(MESSAGE_NO_PLAYER);
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
