using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal interface IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves { get; }
    }
}
