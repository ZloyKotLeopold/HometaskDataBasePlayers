using HometaskDataBasePlayers.Scripts;

namespace HometaskDataBasePlayers
{
    internal class Program
    {
        private const int NO_ACTION = 0;

        static void Main()
        {
            UserInput input = new UserInput();
            BannedPlayer banned = new BannedPlayer();
            DrawPlayers drowPlayers = new DrawPlayers();
            PlayerDatabaseManager playerDatabaseManager = new PlayerDatabaseManager();

            while (input.IsExit)
            {
                input.Input();

                if (input.QuantityPlayers != NO_ACTION)
                {
                    playerDatabaseManager.PlayerFactory.FillingDataBase(input.QuantityPlayers);
                    playerDatabaseManager.InicializationPlayers();
                }

                if (!string.IsNullOrEmpty(input.Name))
                {
                    playerDatabaseManager.AddPlayer(input.Level, input.Name);
                }

                if (input.GiveBanId != NO_ACTION)
                    banned.PlayerGiveBan(playerDatabaseManager, input.GiveBanId);

                if (input.RemoveBanId != NO_ACTION)
                    banned.PlayerRemoveBan(playerDatabaseManager, input.RemoveBanId);

                if (input.RemovePlayerId != NO_ACTION)
                    playerDatabaseManager.RemovePlayer(input.RemovePlayerId);

                drowPlayers.Draw(playerDatabaseManager);
            }
        }
    }
}
