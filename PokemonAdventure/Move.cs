using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    abstract class Move
    {
        protected virtual int pauseInMs { get; set; } = 1000;
        protected ConsolePrinter printer = new ConsolePrinter();
        public abstract string Name { get; init; }
        public virtual void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            printer.Print($"{attacker.Name} used {Name}!");
            Thread.Sleep(pauseInMs);
        }
    }
}
