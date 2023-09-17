using HometaskDataBasePlayers.Scripts;

namespace HometaskDataBasePlayers
{
    internal class Program
    {
        private const int NoAction = 0;

        static void Main()
        {
            UserInput input = new UserInput();
            PlayerFactory playerFactory = new PlayerFactory();
            BannedPlayer banned = new BannedPlayer();
            DrawPlayers drowPlayers = new DrawPlayers();

            while (input.IsExit)
            {
                input.Input();

                if (input.QuantityPlayers != NoAction)
                    playerFactory.FillingDataBase(input.QuantityPlayers);

                if (!string.IsNullOrEmpty(input.Name))
                {
                    playerFactory.PlayerManeger.AddPlayer(input.Level, input.Name);
                    playerFactory.InicializationPlayers();
                }

                if (input.GiveBanId != NoAction)
                    banned.ManagePlayerBan(playerFactory, input.GiveBanId, true);

                if (input.RemoveBanId != NoAction)
                    banned.ManagePlayerBan(playerFactory, input.RemoveBanId, false);

                if (input.RemovePlayerId != NoAction)
                    playerFactory.PlayerManeger.RemovePlayer(input.RemovePlayerId);

                drowPlayers.Draw(playerFactory);
            }
        }
    }
}
