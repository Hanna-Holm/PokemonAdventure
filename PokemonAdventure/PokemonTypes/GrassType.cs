
using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class GrassType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Razor leaf", 110),
                new AttackMove("Petal dance", 90),
                new AttackMove("Vine whip", 100),
                new DecreaseAccuracyMove("Sand attack", 2),
                new DecreaseAttackMove("Growl", 10),
                new DecreaseDefenceMove("Leer", 10)
            };
        public GrassType()
        {
            TypeName = "Grass";
        }
    }
}
