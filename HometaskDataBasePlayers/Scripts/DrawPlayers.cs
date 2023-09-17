using System;
using System.Collections.Generic;

namespace HometaskDataBasePlayers.Scripts
{
    public class DrawPlayers
    {
        public void Draw(PlayerFactory factory)
        {
            Player player;

            Dictionary<int, Player> players = factory.Players;

            int positionX = 0;
            int positionY = 15;

            Console.SetCursorPosition(positionX, positionY);
            if (players != null)
            {
                for (int i = 1; i <= players.Count; i++)
                {
                    players.TryGetValue(i, out player);
                    if (player != null)
                        player.ShowInfo();
                }
            }
        }
    }
}
