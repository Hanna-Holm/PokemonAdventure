﻿using PokemonAdventure.Moves;
using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;
using System.Reflection.Emit;
using System.Xml.Linq;
using System.Reflection;

namespace PokemonAdventure
{
    internal class Battle
    {
        private Trainer player { get; init; }
        private Trainer rival { get; init; }
        private Pokemon playerPokemon { get; set; }
        private Pokemon rivalPokemon { get; set; }
        public Pokemon Winner
        {
            get => playerPokemon.CurrentHealth <= 0 ? rivalPokemon : playerPokemon; 
            set { }
        }
        private bool isOver
            => playerPokemon.CurrentHealth <= 0 || rivalPokemon.CurrentHealth <= 0;

        private ConsolePrinter printer = new ConsolePrinter();
        private int pauseInMs = 1000;

        public Battle(Trainer player, Trainer rival)
        {
            this.player = player;
            this.rival = rival;
            this.playerPokemon = player.capturedPokemon[0];
            this.rivalPokemon = rival.capturedPokemon[0];
        }

        public void Fight()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            printer.Print("[ Enters battle! ]");
            Console.ReadKey();
            Console.Clear();

            printer.Print($"Rival sends out {rivalPokemon.Name} level {rivalPokemon.Level} and health {rivalPokemon.CurrentHealth}");
            Thread.Sleep(pauseInMs);
            Console.ReadKey();

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

                if (isOver) break;

                rivalPokemon.MakeMove(GenerateRivalMove(), playerPokemon);
                Console.Clear();

                if (isOver) break;

                playerPokemon.PrintStats(playerPokemon);
                rivalPokemon.PrintStats(rivalPokemon);
            }
            printer.Print($"{rivalPokemon.Name} fainted!");
            Console.ReadKey();
            Console.Clear(); 

            CheckWhoWon();
            playerPokemon.SetStatsBasedOfLevel();
            rivalPokemon.RestoreHealth();
        }

        private Move GenerateRivalMove()
        {
            Random random = new Random();
            int index = random.Next(0, rivalPokemon.Moves.Count());
            return rivalPokemon.Moves[index];
        }

        public void ExecuteEndofBattleConsequence()
        {
            Pokemon winner = playerPokemon.CurrentHealth <= 0 ? rivalPokemon : playerPokemon;

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
    }
}