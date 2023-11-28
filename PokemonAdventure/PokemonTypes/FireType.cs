

using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class FireType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Fire punch", 20),
                new AttackMove("Ember", 22),
                new DecreaseAccuracyMove("Sand attack", 2),
                new DecreaseAttackMove("Growl", 3),
                new DecreaseDefenceMove("Leer", 3)
                
            };
        public FireType()
        {
            TypeName = "Fire";
        }
    }
}
