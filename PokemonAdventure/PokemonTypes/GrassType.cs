
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
                new DecreaseAccuracyMove("Sand attack", 2),
                new AttackMove("Petal dance", 90),
                new DecreaseAttackMove("Growl", 10),
                new AttackMove("Vine whip", 100),
                new DecreaseDefenceMove("Leer", 10)
            };
        public GrassType()
        {
            TypeName = "Grass";
        }
    }
}
