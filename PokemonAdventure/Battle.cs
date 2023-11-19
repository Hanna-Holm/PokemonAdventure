using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    internal class Battle
    {
        private Trainer player;
        private Trainer rival;

        public Battle(Trainer player)
        {
            this.player = player;
            CreateEnemy();
        }

        private void CreateEnemy()
        {
            rival = new Trainer();
        }
    }
}
