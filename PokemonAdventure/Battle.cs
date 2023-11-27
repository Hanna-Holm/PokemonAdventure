using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    class Battle
    {
        private Trainer player { get; init; }
        private Trainer rival { get; set; }
        private Pokemon currentPokemon { get; set; }
        private Pokemon rivalPokemon { get; set; }
        private bool isOver
            => currentPokemon.CurrentHealth <= 0 || rivalPokemon.CurrentHealth <= 0;

        private ConsolePrinter printer = new ConsolePrinter();
        private int pauseInMs = 1000;

        public Battle(Trainer player)
        {
            this.player = player;
            this.currentPokemon = player.CapturedPokemon[0];

            CreateEnemy();
            Fight();
            printer.Print("The winner is ...");
        }

        private void CreateEnemy()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            this.rivalPokemon = new Pokemon("Meowth", new AttackMove("Tackle", 15));
            this.rival = new Trainer(rivalPokemon);

            printer.Print("A rival trainer appears and wants to battle!");
            printer.Print($"Rival sends out {rivalPokemon.Name} level {rivalPokemon.Level} and health {rivalPokemon.CurrentHealth}");
            Thread.Sleep(pauseInMs);
            Console.ReadKey();
        }

        private void Fight()
        {
            printer.Print("You send out your Pokemon:");
            printer.Print($"{currentPokemon.Name}, go!");
            Thread.Sleep(pauseInMs);
            Console.ReadKey();

            while (!isOver)
            {
                Move move = currentPokemon.ChooseMove();
                currentPokemon.MakeMove(move, rivalPokemon);

                if (isOver)
                {
                    printer.Print("Battle is over.");
                    return;
                }

                rivalPokemon.MakeMove(GenerateRivalMove(), currentPokemon);
            }
        }

        private Move GenerateRivalMove()
        {
            List<Move> availableMoves = new List<Move>();

            foreach (Move move in rivalPokemon.Moves)
            {
                availableMoves.Add(move);
            }

            Random random = new Random();
            int index = random.Next(0, availableMoves.Count());
            return availableMoves[index];
        }
    }
}
