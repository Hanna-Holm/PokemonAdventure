using PokemonAdventure.Moves;
using PokemonAdventure.UserInteraction;

namespace PokemonAdventure;

internal class Story
{
    private ConsolePrinter printer = new ConsolePrinter();
    public Trainer player;
    private Pokemon startingPokemon;

    public void Begin()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        printer.Print("Welcome to the world of Pokemon.");

        startingPokemon = new Pokemon("Pikachu", new AttackMove("Tackle", 20));

        InitializePlayer(startingPokemon);
        ExplainGame();
        EnterBattle(player);
    }

    private void InitializePlayer(Pokemon startingPokemon)
    {
        player = new Trainer(startingPokemon);
        player.SetName();
    }

    private void ExplainGame()
    {
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
        printer.Print($"It's name is {player.capturedPokemon[0].Name}!");
        printer.Print("You now enter the fantastic world of Pokemon...");
        printer.Print("Get ready to begin your adventure!");
        Console.ReadKey();
    }

    private void EnterBattle(Trainer player)
    {
        Battle battle = new Battle(player);
    }
}
