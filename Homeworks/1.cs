using System;
using System.Collections.Generic;

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
        count += 1;
    }

    public string Name
    {
        get { 
            return name; }
    }

    public int Hp
    {
        get { 
            return hp; }
    }

    public int Power
    {
        get { 
            return power; }
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

    public virtual void Attack(Character target)
    {
        Console.WriteLine(Name + " атакует " + target.Name + " на  " + Power + "  урона.");
        target.TakeDamage(Power);
    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
    }

    public bool IsAlive()
    {
        if (hp > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string ToString()
    {
        return Name + " : " + Hp + "HP";
    }

    public override bool Equals(object obj)
    {
        Character other = obj as Character;
        if (other == null)
        {
            return false;
        }
        return name == other.name;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}


class Player : Character
{
    public Player(string name, int hp, int power) : base(name, hp, power)
    { }

    public override void Attack(Character target)
    {
        Console.WriteLine(Name + " атакует " + target.Name + " на " + Power + " урона. ");
        target.TakeDamage(Power);
    }
}

class Enemy : Character
{
    public Enemy(string name, int hp, int power) : base(name, hp, power)
    {}

    public override void Attack(Character target)
    {
        Console.WriteLine(Name + " атакует " + target.Name + " на " + Power + " урона.");
        target.TakeDamage(Power);
    }
}







class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Игрок", 10, 3);
        Console.WriteLine("Создан персонаж: " + player.Name + " (HP: " + player.Hp + ", Урон: " + player.Power + ")");
        Enemy enemy = new Enemy("Враг", 8, 2);
        Console.WriteLine("Создан персонаж: " + enemy.Name + " (HP: " + enemy.Hp + ", Урон: " + enemy.Power + ")");
        List<Character> characters = new List<Character>();
        characters.Add(player);
        characters.Add(enemy);
        Console.WriteLine("Бой начинается!");
        while (player.IsAlive() && enemy.IsAlive())
        {
            characters[0].Attack(characters[1]);
            Console.WriteLine(characters[1]);

            if (!enemy.IsAlive())
            {
                break;
            }
            characters[1].Attack(characters[0]);
        }
        if (player.IsAlive())
        {
            Console.WriteLine("Враг побеждён! Игрок одержал победу!");
    }
}        }
        else
        }
        {
            Console.WriteLine("Игрок побеждён!");
            Console.WriteLine("Враг одержал победу!");

