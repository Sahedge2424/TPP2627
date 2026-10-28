using System;
namespace Game2810
{
    class Character
    {
        private string name;
        private int hp;
        private int power;
        private static int count = 0;
        public Character(string name, int hp, int power)
        {
            this.name = name;
            this.hp = hp;
            this.power = power;
            count = count + 1;
        }

        public static int HowMany()
        {
            return count;
        }

        public static bool IsValidStats(int hp, int power)
        {
            if (hp > 0 && power > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Attack(Character target)
        {
            Console.WriteLine(name + " атакует " + target.name + "а на " + power + " урона.");
            target.hp = target.hp - power;
        }

        public void GetStatus()
        {
            Console.WriteLine(name + ":" + hp + "hp");
        }
    }

    class Player : Character
    {
        public Player(string name, int hp, int power) : base(name, hp, power)
        {}
    }

    class Enemy : Character
    {
        public Enemy(string name, int hp, int power) : base(name, hp, power)
        {}
    }

    class Program
    {
        static void Main()
        {
            Player player = new Player("Игрок", 67, 124);
            Enemy enemy = new Enemy("Враг", 333, 24);
            player.GetStatus();
            enemy.GetStatus();
            Console.WriteLine("Создано персонажей:" + Character.HowMany());
            Console.WriteLine("Проверка: " + Character.IsValidStats(67, 124));
        }
    }
}
