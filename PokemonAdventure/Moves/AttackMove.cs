using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;

namespace PokemonAdventure.Moves
{
    internal class AttackMove : Move
    {
        public override string Name { get; init; }
        private int damage { get; set; }

        public AttackMove(string name, int damage)
        {
            Name = name;
            this.damage = damage;
        }

        public override void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            base.GetUsedBy(attacker, target);
            int totalDamage = (this.damage + attacker.Power - target.Defence) / 5;
            target.TakeDamage(totalDamage);
            printer.Print($"{attacker.Name} made {totalDamage} damage to {target.Name}, who now has {target.Health} health left.");
            Thread.Sleep(pauseInMs);
        }
    }
}