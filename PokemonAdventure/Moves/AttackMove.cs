using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;
using System.Diagnostics.CodeAnalysis;

namespace PokemonAdventure.Moves
{
    // 1. Concept: Class inheritance 
    // 2. How? AttackMove inherits from Move which is another class. This way you get both code reuse and sybtype polymortphism. 
    // It inheritcs both members and typs of the superclass Move. 
    // 3. Why? To inherit properties as well as the method GetUsedBy.
    // This creates structure in the code allowing for better readability as well as reusability of code. 
    internal class AttackMove : Move
    {
        public required override string Name { get; init; }
        private int damage { get; set; }
        public override string Description => "Physical damage";

        [SetsRequiredMembers]
        public AttackMove(string name, int damage)
        {
            this.Name = name;
            this.damage = damage;
        }

        public override void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            base.GetUsedBy(attacker, target);
            int totalDamage = (this.damage + attacker.Power - target.Defence) / 5;
            target.TakeDamage(totalDamage);
            printer.Print($"{attacker.Name} made {totalDamage} damage to {target.Name}, who now has {target.CurrentHealth} health left.");
            Thread.Sleep(pauseInMs);
        }
    }
}