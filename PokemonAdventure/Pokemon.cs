using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    internal class Pokemon
    {
        public string Name { get; init; }

        public Pokemon(string name)
        {
            Name = name;
        }
    }
}
