using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class NormalType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Scratch", 90),
                new AttackMove("Bite", 110),
                new DecreaseAccuracyMove("Sand attack", 2),
                new DecreaseAttackMove("Growl", 10),
                new DecreaseDefenceMove("Leer", 10)
                
            };
        public NormalType() => TypeName = "Normal";
    }
}
