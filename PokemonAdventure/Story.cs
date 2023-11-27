using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure;

class Story
{
    ConsolePrinter printer = new ConsolePrinter();  
    int pauseInMs = 1000;
    public Trainer player;
    Pokemon startingPokemon;
    Pokemon rivalPokemon;

    public void Begin()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        printer.Print("Welcome to the world of Pokemon.");

        startingPokemon = new Pokemon("Pikachu", new AttackMove("Tackle", 20));

        InitializePlayer(startingPokemon);
        ExplainGame();

        rivalPokemon = new Pokemon("RivalPokemon");
        EnterBattle(player);

        startingPokemon.PokemonStats();
        startingPokemon.ExperiencePoints += 120;
        startingPokemon.PokemonStats();

        startingPokemon.LevelUp();
    }

    private void InitializePlayer(Pokemon startingPokemon)
    {
        player = new Trainer(startingPokemon);
        player.SetName();
        printer.Print($"Welcome {player.Name} to your Pokemon adventure!");
    }

    private void ExplainGame()
    {
        Thread.Sleep(pauseInMs);
        Console.Clear();
        printer.Print("You are now on your journey to become a Pokemon master,");
        printer.Print("to become the greatest Pokemon trainer of them all!");
        Console.ReadKey();
        Console.Clear();
        printer.Print("There are several types of Pokemon - creatures that exists in the wild.");
        printer.Print("Pokemon can also be caught by trainers.");
        printer.Print("You, as a Pokemon trainer, are able to battle other trainers with your Pokemon!");
        Console.ReadKey();
        Console.Clear();
        printer.Print("Winning battles will make your Pokemon grow stronger.");
        printer.Print("To become a Pokemon master, your Pokemon must become strong enough");
        printer.Print("to win against the gym leader.");
        Console.ReadKey();
        Console.Clear();
        printer.Print("You have just got your own Pokemon!");
        printer.Print($"It's name is {player.CapturedPokemon[0].Name}!");
        printer.Print("You now enter the fantastic world of Pokemon...");
        printer.Print("Get ready to begin your adventure!");
        Console.ReadKey();
    }

    /*
    private void PracticeMoves(Attacks move)
    {
        printer.Print("Let's start by practicing the moves and attacks of your new pokemon");
    }
    */

    private void EnterBattle(Trainer player)
    {
        printer.Print("You just met your first rival trainer!");
        printer.Print("It is time for your first battle");
        printer.Print($"You are now up against {rivalPokemon.Name}");
        printer.Print("Attack, attack, attack...");
        printer.Print("Congrats you won your first battle");
    }
}

