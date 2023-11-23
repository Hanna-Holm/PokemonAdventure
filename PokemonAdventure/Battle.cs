using PokemonAdventure.Moves;
using PokemonAdventure.UserInteraction;
namespace PokemonAdventure;

internal class Battle
{
    private Trainer player { get; init; }
    private Trainer rival { get; set; }
    private Pokemon currentPokemon { get; set; }
    private Pokemon rivalPokemon { get; set; }
    private bool isOver 
        => currentPokemon.Health <= 0 || rivalPokemon.Health <= 0;

    private ConsolePrinter printer = new ConsolePrinter();
    private int pauseInMs = 1000;

    public Battle(Trainer player)
    {
        this.player = player;
        this.currentPokemon = player.capturedPokemon[0];

        CreateEnemy();
        Fight();
    }

    private void CreateEnemy()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        this.rivalPokemon = new Pokemon("Meowth", new AttackMove("Tackle", 15));
        this.rival = new Trainer(rivalPokemon);

        printer.Print("A rival trainer appears and wants to battle!");
        Console.ReadKey();
    }
    
    private void Fight()
    {
        printer.Print("You send out your Pokemon:");
        printer.Print($"{currentPokemon.Name}, go!");
        Thread.Sleep(pauseInMs);
        Console.ReadKey();

        Move move = currentPokemon.ChooseMove();
        currentPokemon.MakeMove(move, rivalPokemon);
    }

    
}
