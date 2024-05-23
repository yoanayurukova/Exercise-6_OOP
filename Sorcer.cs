using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upr_6_OOP_Heroes
{
    internal class Sorcer : Hero
    {
        public int Luck { get; set; }

        public Sorcer(string name = "No name", int attack = 10, int defence = 2, int health = 25, int luck = 0)
        : base(name, attack, defence, health)
        {
            Luck = luck;
        }

        public override void CelebrateWin()
        {
            Console.WriteLine($"{Name}, the Sorcerer, conjures a grand magical display in celebration!");
        }
    }
}
