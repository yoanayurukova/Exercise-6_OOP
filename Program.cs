using System;

namespace Upr_6_OOP_Heroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Battle Begins!");

            // Create two heroes
            Sorcer hero1 = new Sorcer(name:"Padme", attack: 8, defence: 14, health: 100 , luck:5);
            Warrior hero2 = new Warrior(name: "Beast", attack: 17, defence: 8, health: 100 , additionalStrenght:20);

            // Start the battle
            Battle battle1 = new Battle();
            battle1.StartBattle(hero1, hero2);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Battle Ends!");
        }
    }
}
