

using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class FlyingType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Gust", 80),
                new DecreaseAccuracyMove("Sand attack", 2),
                new AttackMove("Wing attack", 90),
                new DecreaseAttackMove("Growl", 10),
                new AttackMove("Peck", 100),
                new DecreaseDefenceMove("Leer", 10)
            };
        public FlyingType()
        {
            TypeName = "Flying";
        }
    }
}
