using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace HometaskDataBasePlayers.Scripts
{
    public class DrawPlayers
    {
        public void Draw(PlayerDatabaseManager databaseManager)
        {
            Player player;
            Dictionary<int, Player> players = (Dictionary<int, Player>)databaseManager.ReadOnlyAllPlayers;

            int positionX = 0;
            int positionY = 15;

            Console.SetCursorPosition(positionX, positionY);
            if (players != null)
            {
                for (int i = 1; i <= players.Count; i++)
                {
                    players.TryGetValue(i, out player);
                    if (player != null)
                        ShowInfo(player);
                }
            }
        }
        public void ShowInfo(Player player)
        {
            Console.WriteLine(
                $"ID: {player.Id}\n" +
                $"Уровень: {player.Level}\n" +
                $"Имя: {player.Name}\n" +
                $"Наличие бана: {player.IsBanned}\n");
        }
    }
}
