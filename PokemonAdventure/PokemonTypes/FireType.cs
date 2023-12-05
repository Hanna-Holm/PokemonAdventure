

using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class FireType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new DecreaseAccuracyMove("Sand attack", 2),
                new AttackMove("Fire punch", 100),
                new DecreaseAttackMove("Growl", 10),
                new AttackMove("Ember", 110),
                new DecreaseDefenceMove("Leer", 10)
            };
        public FireType() => TypeName = "Fire";
    }
}
