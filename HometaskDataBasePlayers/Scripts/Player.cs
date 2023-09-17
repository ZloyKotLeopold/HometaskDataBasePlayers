using System;

namespace HometaskDataBasePlayers.Scripts
{ 
    public class Player
    {
        public int Id { get; private set; }
        public int Level { get; private set; }
        public string Name { get; private set; }
        private bool _isBanned;

        public Player(int id, int level, string name)
        {
            Id = id;
            Level = level;
            Name = name;
            _isBanned = false;
        }
        public void GiveBanPlayer()
        {
            _isBanned = true;
        }
        public void RemoveBanPlayer()
        {
            _isBanned = false;
        }
        public void ShowInfo()
        {
            Console.WriteLine(
                $"ID: {Id}\n" +
                $"Уровень: {Level}\n" +
                $"Имя: {Name}\n" +
                $"Наличие бана: {_isBanned}\n");
        }
    }
}
