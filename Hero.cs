using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upr_6_OOP_Heroes
{
    // only this program can access this class this Project Heroes this assembly
    internal class Hero
    {
        // hides variable from other classes
        private int _defence = 10;
        private int _attack = 10;
        private int _health = 10;

        public string Name { get; set; }
        public int Attack
        {
            get => _attack;
            set
            {

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Attack), "Attack cannot be less than zero.");
                }
                else if (value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(Attack), "Attack cannot be greater than 100.");
                }
                else
                {
                    _attack = value;
                }


            }
        }
        public int Defence
        {
            get => _defence;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Defence), "Defence cannot be less than zero.");
                }
                else if (value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(Defence), "Defence cannot be greater than 100.");
                }
                else
                {
                    _defence = value;
                }

            }
        }
        public int Health
        {
            get => _health;
            set
            {
                if (value < 0)
                {
                    _health = 0;
                }
                else if (value > 1000)
                {
                    _health = 1000;
                }
                else
                {
                    _health = value;
                }

            }
        }


        public Hero()
        {
            Console.WriteLine("Im default constructor");
        }

        //Custom Contstructor
        public Hero(string name = "No name", int attack = 10, int defence = 2, int health = 25)
        {
            Name = name;
            Attack = attack;
            Defence = defence;
            Health = health;
            Console.WriteLine("Hero has been created" + Name);
        }

        public virtual void CelebrateWin()
        {
            Console.WriteLine($"{Name} is celebrating the victory!");
        }
    }
}
