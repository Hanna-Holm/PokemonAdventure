using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    class AttackMove : Move
    {
        ConsolePrinter printer = new ConsolePrinter();
        Random random = new Random();
        public override string Name { get; init; }
        private int damage;
        int accuracy { get; set; } = 10;
        public bool missedAttack => random.Next(1, accuracy) == 1; 
 

        public AttackMove(string name, int damage)
        {
            Name = name;
            this.damage = damage;
        }
        public AttackMove(string name, int damage, int accuracy)
        {
            Name = name;
            this.damage = damage;
            this.accuracy = accuracy;
        }

        public override void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            base.GetUsedBy(attacker, target);
            if (!missedAttack)
            {
                damage += attacker.Power;
                target.TakeDamage(damage);
                printer.Print($"{attacker.Name} did -{damage} to {target.Name} ");
                printer.Print($"{target.Name}: HP:{target.CurrentHealth}");
            }
            else
            {
                printer.Print($"{attacker.Name} missed {target.Name}");
            }
        }
    }
}
