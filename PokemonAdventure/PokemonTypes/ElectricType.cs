using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class ElectricType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Thunder shock", 100),
                new AttackMove("Bolt strike", 100),
                new AttackMove("Spark", 90),
                new DecreaseAccuracyMove("Sand attack", 2),
                new AttackMove("Volt tackle", 120),
                new AttackMove("Thunder wave", 110),
                new DecreaseAccuracyMove("Sand attack", 2),
                new DecreaseDefenceMove("Leer", 10),
                new DecreaseAttackMove("Growl", 10)
            };

        public ElectricType()
        {
            TypeName = "Electric";
        }
    }
}
