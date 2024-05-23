using System;
using System.Threading;

namespace Upr_6_OOP_Heroes
{
    class Battle
    {
        private static int nextId = 0;
        private readonly int _id;
        private int countRounds = 0;
        private static readonly Random rnd = new Random();

        public Battle()
        {
            _id = nextId++;
            Console.WriteLine($"Battle {_id} starts");
        }

        public void StartBattle(Hero hero1, Hero hero2)
        {
            while (hero1.Health > 0 && hero2.Health > 0)
            {
                int whoIsFirst = GetWhoIsFirst();

                if (whoIsFirst < 5)
                {
                    PerformAttack(hero1, hero2);
                    if (hero2.Health <= 0) break;
                    PerformAttack(hero2, hero1);
                }
                else
                {
                    PerformAttack(hero2, hero1);
                    if (hero1.Health <= 0) break;
                    PerformAttack(hero1, hero2);
                }

                Thread.Sleep(1000);
            }

            if (hero1.Health <= 0 && hero2.Health > hero1.Health)
            {
                hero2.CelebrateWin();
                Console.WriteLine($"{hero2.Name} wins!");
            }
            else if (hero2.Health <= 0 && hero1.Health > hero2.Health)
            {
                hero1.CelebrateWin();
                Console.WriteLine($"{hero1.Name} wins!");
            }
            else
            {
                Console.WriteLine("The battle continues!");
            }
        }

        private void PerformAttack(Hero attacker, Hero defender)
        {
            int damage = 0;

            if (attacker is Sorcer sorcer)
            {
                if (sorcer.Luck > rnd.Next(1, 21))
                {
                    damage = defender.Health / 2;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{sorcer.Name}'s luck activates! They deal {damage} damage by taking half of {defender.Name}'s health.");
                    Console.ResetColor();
                }
                else
                {
                    damage = GetAttackResult(attacker.Attack, defender.Defence);
                }
            }
            else if (attacker is Warrior warrior)
            {
                countRounds++;
                damage = GetAttackResult(attacker.Attack, defender.Defence);
                if (countRounds % 5 == 0)
                {
                    damage += warrior.AdditionalStrength;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{warrior.Name}'s additional strength activates! They deal {damage} damage.");
                    Console.ResetColor();
                }
            }
            else
            {
                damage = GetAttackResult(attacker.Attack, defender.Defence);
            }

            if (damage > 0)
            {
                defender.Health -= damage;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{attacker.Name} attacks {defender.Name} for {damage} damage.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{defender.Name}'s remaining health: {defender.Health}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{attacker.Name} attacks {defender.Name} but is blocked. {defender.Name}'s remaining health: {defender.Health}");
            }
            Console.ResetColor();
        }

        private int GetAttackResult(int attack, int defence)
        {
            Thread.Sleep(2000);
            int randomAttackMomentum = GetRandomMomentum();
            int randomDefenceMomentum = GetRandomMomentum();
            int realAttack = attack + randomAttackMomentum;
            int realDefence = defence + randomDefenceMomentum;
            return realAttack - realDefence;
        }

        private int GetWhoIsFirst()
        {
            return rnd.Next(0, 10);
        }

        private int GetRandomMomentum()
        {
            return rnd.Next(-10, 10);
        }
    }
}
