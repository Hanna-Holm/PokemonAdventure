using PokemonAdventure.Moves;
using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;

namespace PokemonAdventure
{
    internal class Battle
    {
        private Trainer player { get; init; }
        private Pokemon playerPokemon { get; set; }
        private Pokemon rivalPokemon { get; set; }
        private bool isOver
            => playerPokemon.Health <= 0 || rivalPokemon.Health <= 0;

        private ConsolePrinter printer = new ConsolePrinter();
        private int pauseInMs = 1000;

        public Battle(Trainer player, Trainer rival)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            this.player = player;
            this.playerPokemon = player.capturedPokemon[0];
            this.rivalPokemon = rival.capturedPokemon[0];

            printer.Print("A rival trainer appears and wants to battle!");
            printer.Print($"Rival sends out {rivalPokemon.Name} level {rivalPokemon.Level} and health {rivalPokemon.Health}");
            Thread.Sleep(pauseInMs);
            Console.ReadKey();

            Fight();
            Console.Clear();

            Pokemon winner = CheckWhoWon();
            if (playerPokemon == winner)
            {
                printer.Print($"Congratulations {player.Name}! \nYour Pokemon {playerPokemon.Name} won against {rivalPokemon.Name}!");
                Console.ReadKey();
                Console.Clear();
                playerPokemon.IncreaseExperiencePointsBasedOf(rivalPokemon);
            }
            else
            {
                printer.Print($"{playerPokemon.Name} fainted!");
                printer.Print("You lost!");
                Console.ReadKey();
            }

            playerPokemon.SetStatsBasedOfLevel();
            playerPokemon.RestoreHealth();
        }

        private void Fight()
        {
            printer.Print($"{player.Name} sends out a Pokemon:");
            printer.Print($"{playerPokemon.Name}, go!");
            Thread.Sleep(pauseInMs);
            Console.ReadKey();
            Console.Clear();

            while (!isOver)
            {
                Move move = playerPokemon.ChooseMove();
                playerPokemon.MakeMove(move, rivalPokemon);
                Console.Clear();

                if (isOver)
                {
                    printer.Print($"{rivalPokemon.Name} fainted!");
                    Console.ReadKey();
                    return;
                }

                rivalPokemon.MakeMove(GenerateRivalMove(), playerPokemon);
                Console.Clear();
            }
        }

        private Move GenerateRivalMove()
        {
            Random random = new Random();
            int index = random.Next(0, rivalPokemon.Moves.Count());
            return rivalPokemon.Moves[index];
        }

        private Pokemon CheckWhoWon()
        {
            return playerPokemon.Health <= 0 ? rivalPokemon : playerPokemon;
        }
    }
}