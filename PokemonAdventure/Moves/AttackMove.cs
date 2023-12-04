using PokemonAdventure.PokemonSpecifier;
using System.Diagnostics.CodeAnalysis;

namespace PokemonAdventure.Moves
{
    internal class AttackMove : Move
    {
        /* 
           1. Concept: Class inheritance 
           2. How? AttackMove inherits from Move which is another class. AttackMove is-a subclass of Move.
              It inherits both members and type of the superclass Move. This way you get both code reuse and sybtype polymorphism. 
           3. Why? To inherit public and protected properties as well as the public and protected methods from the base class.
              This also enables subtype-polymorphism and the use of dynamic dispath: to be able to dynamically dispatch which method gets called 
              in run-time, when invoking the GetUsedBy method on an object of any derived type of the base class Move in run-time.
              Inheritance allows subtype-polymorphism as well as reusability of code, and it also creates structure in the code 
              allowing for better readability. 
        */
        public required override string Name { get; init; }
        private int damage { get; set; }
        public override string Description => "Physical damage";

        [SetsRequiredMembers]
        public AttackMove(string name, int damage)
        {
            Name = name;
            this.damage = damage;
        }

        public override void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            PrintUsingMessage(attacker);

            bool missedAttack = new Random().Next(1, attacker.Accuracy) == 1;
            if (missedAttack)
            {
                PrintAndPause($"{attacker.Name} missed the attack!");
                return;
            }

            int totalDamage = (this.damage + attacker.Power - target.Defence) / 5;
            target.TakeDamage(totalDamage);
            PrintAndPause($"{attacker.Name} made {totalDamage} damage to {target.Name}, who now has {target.CurrentHealth} health left.");
        }
    }
}