using PokemonAdventure.Moves;
using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;
using PokemonAdventure.PokemonTypes;

namespace PokemonAdventure
{
    internal class Story
    {
        private ConsolePrinter printer = new ConsolePrinter();
        private PokemonWorld world = new PokemonWorld();
        private PokemonGenerator PokemonGenerator = new PokemonGenerator();
        public Trainer player;
        private List<Pokemon> availablePokemon;
        private Pokemon startingPokemon;

        public void Begin()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            printer.Print("Welcome to the world of Pokemon.");

            startingPokemon = PokemonGenerator.GenerateStartingPokemon(world);
            InitializePlayer(startingPokemon);
            ExplainGame();

            Trainer rival = GenerateRival();
            Battle battle = new Battle(player, rival);
            Console.Clear();
            ShouldRunBossBattle();
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
            printer.Print($"You have received a starting Pokemon called {startingPokemon.Name}");
            printer.Print($"It's a {startingPokemon.Type.TypeName} type at level {startingPokemon.Level} and health {startingPokemon.Health}");
            Console.ReadKey();
            Console.Clear();
            printer.Print("You now enter the fantastic world of Pokemon...");
            printer.Print("Get ready to begin your adventure!");
            Console.ReadKey();
        }

        private Trainer GenerateRival()
        {
            Pokemon rivalPokemon = PokemonGenerator.GenerateRivalPokemon(world, startingPokemon);
            return new Trainer(rivalPokemon);
        }

        private void ShouldRunBossBattle()
        {
            printer.Print("Do you want to meet the gym leader now or keep on training?\n");
            Console.WriteLine("1. Keep on training");
            Console.WriteLine("2. Battle against the gym leader!");
        }
    }
}