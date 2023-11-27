using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
namespace PokemonAdventure
{
    class Attacks : IMove
    {
        Random random = new Random();
        Printer printer = new Printer();
        public string MoveName { get; set; }
        public int Damage { get; set; }
        public List<IMove> Moves { get; set; }
        int Accuracy { get; set; } = 10;
        public bool missedAttack => random.Next(1, Accuracy) == 1; 

        public Attacks(string moveName, int damage, int accuracy)
        {
            this.MoveName = moveName;
            this.Damage = damage; // 14
            this.Accuracy = accuracy;
            Moves.Add(this);
        }
        
        public void MakeAttack(Pokemon attacker, Pokemon target)
        { 
            if (!missedAttack)
            {
                target.TakeDamage(attacker, target);
                printer.Print($"{target.Name} -{attacker.Damage}");
                printer.Print($"{target.Name}: HP:{target.CurrentHealth}");
            }
            else
            {
                printer.Print($"{attacker.Name} missed {target.Name}");
                printer.Print($"{target.Name} -0 HP"); 
            }
        }
    }
}
*/
