

using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class FireType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Fire punch", 100),
                new AttackMove("Ember", 110),
                new DecreaseAttackMove("Growl", 10),
                new DecreaseDefenceMove("Leer", 10),
                new DecreaseAccuracyMove("Sand attack", 2)
            };
        public FireType()
        {
            TypeName = "Fire";
        }
    }
}
