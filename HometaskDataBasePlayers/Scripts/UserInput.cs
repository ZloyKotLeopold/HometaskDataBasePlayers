using System;
using System.Xml.Linq;

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
            int criateRandomPlayer = 1;
            int criateMinePlayer = 2;
            int giveBanPlayer = 3;
            int removeBanPlayer = 4;
            int removePlayer = 5;
            int exitProgram = 6;

            Console.WriteLine(
                $"{criateRandomPlayer} - Сгенерировать рандомных персонажей.\n" +
                $"{criateMinePlayer} - Создать персонажа cамому.\n" +
                $"{giveBanPlayer} - Забанить игрока.\n" +
                $"{removeBanPlayer} - Снять бан с игрока.\n" +
                $"{removePlayer} - Удалить игрока.\n" +
                $"{exitProgram} - Выйти из программы.\n");

            string userInput = Console.ReadLine();
            uint numberInput;
            uint maxNumberInput = 6;
            uint maxLevel = 100;

            if (CheckUserInput(userInput, maxNumberInput, out numberInput))
            {
                maxNumberInput = uint.MaxValue;

                if (numberInput == criateRandomPlayer)
                {
                    QuantityPlayers = (int)ClearAndGetUIntInput("Сколько персонажей вы хотите создать?", maxNumberInput, out numberInput);
                    return;
                }
                if (numberInput == criateMinePlayer)
                {
                    maxNumberInput = maxLevel;
                    Level = (int)ClearAndGetUIntInput($"Введите уровень персонажа не болеее {maxLevel}.", maxNumberInput, out numberInput);
                    Name = GetUserInput("Введите имя персонажжа.");
                }
                if (numberInput == giveBanPlayer)
                    GiveBanId = (int)ClearAndGetUIntInput("Введите ID персонажа которого вы хотите забанить.", maxNumberInput, out numberInput);
                if ((numberInput == removeBanPlayer))
                    RemoveBanId = (int)ClearAndGetUIntInput("Введите ID персонажа которого вы хотите разбанить.", maxNumberInput, out numberInput);
                if ((numberInput == removePlayer))
                    RemovePlayerId = (int)ClearAndGetUIntInput("Введите ID персонажа которого вы хотите удалить.", maxNumberInput, out numberInput);
                if ((numberInput == exitProgram))
                    IsExit = false;
            }
        }

        private uint ClearAndGetUIntInput(string message, uint maxNumberInput, out uint numberInput)
        {
            Console.Clear();
            GetUserInput(message, maxNumberInput, out numberInput);
            return numberInput;
        }

        private void GetUserInput(string messenge, uint maxNumberInput, out uint numberInput)
        {
            while (true)
            {
                Console.WriteLine(messenge);
                string userInput = Console.ReadLine();

                if (CheckUserInput(userInput, maxNumberInput, out numberInput))
                    return;
            }
        }


        private string GetUserInput(string messenge)
        {
            Console.WriteLine(messenge);
            while (true)
            {
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                    return userInput;
                else
                    Console.WriteLine("Пожалуйста, введите имя.");
            }
        }

        private bool CheckUserInput(string userInput, uint maxNumberInput, out uint numberInput)
        {
            bool isCorrect = uint.TryParse(userInput, out numberInput);
            if (isCorrect && numberInput <= maxNumberInput)
                return true;
            else
            {
                Console.WriteLine("Вы ввели неверное значение.");
                userInput = Console.ReadLine();
                isCorrect = CheckUserInput(userInput, maxNumberInput, out numberInput); //рекурсия стэк не переполнит так как пользовательский ввод.
                return isCorrect;
            }
        }
    }
}