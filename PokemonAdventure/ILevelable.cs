using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    interface ILevelable
    {
        int Level { get; set; }
        int ExperiencePoints { get; set; }
        int LevelThreshold { get; }
        bool ShouldLevelUp { get; }
        void LevelUp();
    }
}
