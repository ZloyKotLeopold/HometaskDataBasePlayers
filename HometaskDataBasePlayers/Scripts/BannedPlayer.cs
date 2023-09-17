using System;

namespace HometaskDataBasePlayers.Scripts
{
    public class BannedPlayer
    {
        private Player _player;
        public void ManagePlayerBan(PlayerFactory playerFactory, int id, bool isBanned)
        {
            if (isBanned)
            {
                if (playerFactory.Players.TryGetValue(id, out _player))
                {
                    _player.GiveBanPlayer();
                    playerFactory.PlayerManeger.AddPlayer(_player);
                }
                else
                    Console.WriteLine("Такого игрока нет.");
            }
            else
            {
                if (playerFactory.Players.TryGetValue(id, out _player))
                    _player.RemoveBanPlayer();
                else
                    Console.WriteLine("Такого игрока нет.");
            }
        }

    }
}
