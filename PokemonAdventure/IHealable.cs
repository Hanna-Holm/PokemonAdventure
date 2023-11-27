using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    interface IHealable
    {
        int CurrentHealth { get; }
        int MaxHealth { get; }
    }
}
