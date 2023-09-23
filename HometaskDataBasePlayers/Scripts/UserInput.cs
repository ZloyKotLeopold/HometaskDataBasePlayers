using System;
using System.Runtime.Remoting.Messaging;

namespace HometaskDataBasePlayers.Scripts
{
    public class UserInput
    {
        public int GiveBanId { get; private set; }
        public int RemoveBanId { get; private set; }
        public int RemovePlayerId { get; private set; }
        public int Level { get; private set; }
        public string Name { get; private set; }
        public int QuantityPlayers { get; private set; }
        public bool IsExit { get; private set; }

        private const int PARAMETR_CRIATRE_RANDOM_PLAYERS = 1;
        private const int PARAMETR_CRIATE_MY_PLAYER = 2;
        private const int PARAMETR_GIVE_BAN = 3;
        private const int PARAMETR_REMOVE_BAN = 4;
        private const int PARAMETR_REMOVE_PLAYER = 5;
        private const int PARAMETR_EXIT_PROGRAM = 6;
        private const string MASSENGE_REMOVE_PLAYER = "Введите ID персонажа которого вы хотите удалить.";
        private const string MASSENGE_REMOVE_BAN = "Введите ID персонажа которого вы хотите разбанить.";
        private const string MASSENGE_GIVE_BAN = "Введите ID персонажа которого вы хотите забанить.";
        private const string MASSENGE_COUNT_CRIATE_PLAYERS = "Сколько персонажей вы хотите создать?";
        private const string MASSENGE_INPUT_LEVEL = "Введите уровень персонажа не болеее";
        private const string MASSENGE_INPUT_NAME = "Введите имя персонажжа.";

        public UserInput()
        {
            IsExit = true;
        }

        public void Input()
        {
            Console.SetCursorPosition(0, 0);
            Name = "";
            GiveBanId = 0;
            RemoveBanId = 0;
            QuantityPlayers = 0;

            Console.WriteLine(
                $"{PARAMETR_CRIATRE_RANDOM_PLAYERS} - Сгенерировать рандомных персонажей.\n" +
                $"{PARAMETR_CRIATE_MY_PLAYER} - Создать персонажа cамому.\n" +
                $"{PARAMETR_GIVE_BAN} - Забанить игрока.\n" +
                $"{PARAMETR_REMOVE_BAN} - Снять бан с игрока.\n" +
                $"{PARAMETR_REMOVE_PLAYER} - Удалить игрока.\n" +
                $"{PARAMETR_EXIT_PROGRAM} - Выйти из программы.\n");

            string userInput = Console.ReadLine();
            uint numberInput;
            uint maxNumberInput = 6;
            uint maxLevel = 100;

            if (CheckUserInput(userInput, maxNumberInput, out numberInput))
            {
                maxNumberInput = uint.MaxValue;

                IsExit = (numberInput == PARAMETR_EXIT_PROGRAM) ? false : true;

                RemovePlayerId = (numberInput == PARAMETR_REMOVE_PLAYER) ? (int)ClearAndGetUIntInput(MASSENGE_REMOVE_PLAYER, maxNumberInput) : 0;

                RemoveBanId = (numberInput == PARAMETR_REMOVE_BAN) ? (int)ClearAndGetUIntInput(MASSENGE_REMOVE_BAN, maxNumberInput) : 0;

                GiveBanId = (numberInput == PARAMETR_GIVE_BAN) ? (int)ClearAndGetUIntInput(MASSENGE_GIVE_BAN, maxNumberInput) : 0;

                if (numberInput == PARAMETR_CRIATE_MY_PLAYER)
                    CriateMyPlayer(maxNumberInput, maxLevel);

                QuantityPlayers = (numberInput == PARAMETR_CRIATRE_RANDOM_PLAYERS) ? (int)ClearAndGetUIntInput(MASSENGE_COUNT_CRIATE_PLAYERS, maxNumberInput) : 0;
            }
        }

        private uint ClearAndGetUIntInput(string message, uint maxNumberInput)
        {
            Console.Clear();
            return GetUserInput(message, maxNumberInput);
        }

        private void CriateMyPlayer(uint maxNumberInput, uint maxLevel)
        {
            maxNumberInput = maxLevel;
            Level = (int)ClearAndGetUIntInput($"{MASSENGE_INPUT_LEVEL} {maxLevel}.", maxNumberInput);
            Name = GetUserInput(MASSENGE_INPUT_NAME);
        }

        private uint GetUserInput(string messenge, uint maxNumberInput)
        {
            uint numberInput = 0;
            bool isCorrect = true;

            while (isCorrect)
            {
                Console.WriteLine(messenge);
                string userInput = Console.ReadLine();

                if (CheckUserInput(userInput, maxNumberInput, out numberInput))
                {
                    isCorrect = false;
                }
            }
            return numberInput;
        }

        private string GetUserInput(string messenge)
        {
            int countTry = 10;
            Console.WriteLine(messenge);
            string userInput = "";

            for (int i = 0; i <= countTry; countTry--)
            {
                userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                {
                    countTry = 0;
                    Console.Clear();
                    return userInput;
                }

                Console.WriteLine($"Пожалуйста, введите имя, попыток - {countTry}");
            }

            Console.Clear();
            return userInput;
        }

        private bool CheckUserInput(string userInput, uint maxNumberInput, out uint numberInput)
        {
            numberInput = 0;
            int countTry = 10;

            while (countTry > 0)
            {
                countTry--;
                bool isCorrect = uint.TryParse(userInput, out numberInput);

                if (isCorrect && numberInput <= maxNumberInput)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Вы ввели неверное значение, попыток {countTry}");
                    userInput = Console.ReadLine();
                }
            }
            Console.Clear();
            return false;
        }

    }
}