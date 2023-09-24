using System;

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

        #region CONSTANTS
        private const int PARAMETER_CRIATRE_RANDOM_PLAYERS = 1;
        private const int PARAMETER_CRIATE_MY_PLAYER = 2;
        private const int PARAMETER_GIVE_BAN = 3;
        private const int PARAMETER_REMOVE_BAN = 4;
        private const int PARAMETER_REMOVE_PLAYER = 5;
        private const int PARAMETER_EXIT_PROGRAM = 6;
        private const string MESSAGE_REMOVE_PLAYER = "Введите ID персонажа которого вы хотите удалить.";
        private const string MESSAGE_REMOVE_BAN = "Введите ID персонажа которого вы хотите разбанить.";
        private const string MESSAGE_GIVE_BAN = "Введите ID персонажа которого вы хотите забанить.";
        private const string MESSAGE_COUNT_CRIATE_PLAYERS = "Сколько персонажей вы хотите создать?";
        private const string MESSAGE_INPUT_LEVEL = "Введите уровень персонажа не болеее";
        private const string MESSAGE_INPUT_NAME = "Введите имя персонажжа.";
        private const string MESSAGE_INPUT_NAME_TRY = "Пожалуйста, введите имя, попыток -";
        private const string MESSAGE_INPUT_TRY_NUMBER = "Вы ввели неверное значение, попыток";
        #endregion

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
                $"{PARAMETER_CRIATRE_RANDOM_PLAYERS} - Сгенерировать рандомных персонажей.\n" +
                $"{PARAMETER_CRIATE_MY_PLAYER} - Создать персонажа cамому.\n" +
                $"{PARAMETER_GIVE_BAN} - Забанить игрока.\n" +
                $"{PARAMETER_REMOVE_BAN} - Снять бан с игрока.\n" +
                $"{PARAMETER_REMOVE_PLAYER} - Удалить игрока.\n" +
                $"{PARAMETER_EXIT_PROGRAM} - Выйти из программы.\n");

            string userInput = Console.ReadLine();
            uint numberInput;
            uint maxNumberInput = 6;
            uint maxLevel = 100;

            if (CheckUserInput(userInput, maxNumberInput, out numberInput))
            {
                maxNumberInput = uint.MaxValue;

                IsExit = (numberInput == PARAMETER_EXIT_PROGRAM) ? false : true;

                RemovePlayerId = (numberInput == PARAMETER_REMOVE_PLAYER) ? (int)ClearAndGetUIntInput(MESSAGE_REMOVE_PLAYER, maxNumberInput) : 0;

                RemoveBanId = (numberInput == PARAMETER_REMOVE_BAN) ? (int)ClearAndGetUIntInput(MESSAGE_REMOVE_BAN, maxNumberInput) : 0;

                GiveBanId = (numberInput == PARAMETER_GIVE_BAN) ? (int)ClearAndGetUIntInput(MESSAGE_GIVE_BAN, maxNumberInput) : 0;

                QuantityPlayers = (numberInput == PARAMETER_CRIATRE_RANDOM_PLAYERS) ? (int)ClearAndGetUIntInput(MESSAGE_COUNT_CRIATE_PLAYERS, maxNumberInput) : 0;

                if (numberInput == PARAMETER_CRIATE_MY_PLAYER)
                    CreateMyPlayer(maxNumberInput, maxLevel);
            }
        }

        #region HELPING_METHODS
        private uint ClearAndGetUIntInput(string message, uint maxNumberInput)
        {
            Console.Clear();
            return GetUserInput(message, maxNumberInput);
        }

        private void CreateMyPlayer(uint maxNumberInput, uint maxLevel)
        {
            maxNumberInput = maxLevel;
            Level = (int)ClearAndGetUIntInput($"{MESSAGE_INPUT_LEVEL} {maxLevel}.", maxNumberInput);
            Name = GetUserInput(MESSAGE_INPUT_NAME);
        }

        private uint GetUserInput(string messenge, uint maxNumberInput)
        {
            uint numberInput = 0;
            bool isCorrect = true;

            while (isCorrect)
            {
                Console.WriteLine(messenge);
                string userInput = Console.ReadLine();

                isCorrect = CheckUserInput(userInput, maxNumberInput, out numberInput) ? false : true;
            }
            return numberInput;
        }

        private string GetUserInput(string messenge)
        {
            int countTry = 10;
            Console.WriteLine(messenge);
            string userInput = "";

            while (countTry > 0)
            {
                countTry--;
                userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                {
                    Console.Clear();
                    return userInput;
                }

                Console.WriteLine($"{MESSAGE_INPUT_NAME_TRY} {countTry}");
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
                    Console.WriteLine($"{MESSAGE_INPUT_TRY_NUMBER} {countTry}");
                    userInput = Console.ReadLine();
                }
            }
            Console.Clear();
            return false;
        }
        #endregion

    }
}