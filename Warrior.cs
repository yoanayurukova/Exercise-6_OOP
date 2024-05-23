using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upr_6_OOP_Heroes
{
    class Warrior : Hero
    {
        public int AdditionalStrength { get; set; }
        public Warrior(string name = "No name", int attack = 10, int defence = 2, int health = 25, int additionalStrenght = 0)
        : base(name, attack, defence, health)
        {
            AdditionalStrength = additionalStrenght;
        }

        public override void CelebrateWin()
        {
            Console.WriteLine($"{Name}, the Warrior, roars triumphantly and raises their weapon in victory!");
        }
    }
}
