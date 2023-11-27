using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure.Moves
{
    internal class DecreaseAccuracyMove : Move
    {
        public override string Name 
        { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        public override string Description { get; } = "Lowers target accuracy";
    }
}
