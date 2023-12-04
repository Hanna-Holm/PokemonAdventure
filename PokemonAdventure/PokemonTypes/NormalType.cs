using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class NormalType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new DecreaseAccuracyMove("Sand attack", 2),
                new AttackMove("Bite", 110),
                new AttackMove("Scratch", 90),
                new DecreaseAttackMove("Growl", 10),
                new DecreaseDefenceMove("Leer", 10)
            };
        public NormalType()
        {
            TypeName = "Normal";
        }
    }
}
