using PokemonAdventure.Moves;
using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;
using PokemonAdventure.PokemonTypes;

namespace PokemonAdventure
{
    internal class Story
    {
        private ConsolePrinter printer = new ConsolePrinter();
        private Validator validator = new Validator();
        private AllPokemon world = new AllPokemon();
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

            startingPokemon = PokemonGenerator.GeneratePokemon(world);
            InitializePlayer(startingPokemon);
            ExplainGame();
            Console.Clear();
            Training();
        }

        private void InitializePlayer(Pokemon startingPokemon)
        {
            player = new Trainer(startingPokemon);
            player.SetName();
            Console.Clear();
            printer.Print($"{player.Name} your Pokemon adventure begins now!");
            Console.ReadKey();
        }

        private void ExplainGame()
        {
            Console.Clear();
            printer.Print("You are now on your journey to become a Pokemon master,");
            printer.Print("the greatest Pokemon trainer of them all!");
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
            printer.Print($"{startingPokemon.Name} is of {startingPokemon.Type.TypeName} type, level {startingPokemon.Level} with HP {startingPokemon.CurrentHealth}");
            Console.ReadKey();
            Console.Clear();
            printer.Print("You are now entering the fantastic world of Pokemon...");
            printer.Print("Get ready to begin your adventure!");
            Console.ReadKey();
        }
        public void Training()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            printer.LoadingScene();
            Console.Clear();
            Trainer rival = GenerateRival();
            Battle battle = new Battle(player, rival);
            printer.Print("[ Scene opens on a grassy area where the player is seen training their Pokemon. ]");
            printer.Print("[ Suddenly, a rival trainer appears, eager for a battle. ]");
            printer.Print("Time to show them what you got!");
            Console.ReadKey();
            battle.Fight();
            Console.Clear();

            PathAfterBattle();
            Console.Clear();
        }

        private Trainer GenerateRival()
        {
            Pokemon rivalPokemon = PokemonGenerator.GeneratePokemon(world, startingPokemon);
            rivalPokemon.Name = "Rival " + rivalPokemon.Name;
            return new Trainer(rivalPokemon);
        }

        public void PathAfterBattle()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            printer.LoadingScene();
            Console.Clear();
            printer.Print("Do you want to keep on training or meet the gym leader?\n");
            Console.WriteLine("1. Keep on training");
            Console.WriteLine("2. Battle against the gym leader!");

            bool isValid = false;
            int numberOfMovesAvailable = 2;
            string choice = Console.ReadLine();

            /*
            do
            {
                choice = Console.ReadLine();
                isValid = validator.CheckIfValidNumber(choice, numberOfMovesAvailable);
            } while (!isValid);
            */

            if (choice == "1")
            {
                Training();
            }
            else if (choice == "2")
            {
                GymLeaderBattle();
            }
        }
        private Trainer GenerateGymLeader()
        {
            Pokemon rivalPokemon = PokemonGenerator.GenerateGymLeaderPokemon(world);
            rivalPokemon.Accuracy += 2; 
            rivalPokemon.Name = "Leader " + rivalPokemon.Name;
            return new Trainer(rivalPokemon);
        }

        private void GymLeaderBattle()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            printer.LoadingScene();
            Console.Clear(); 
            Trainer rival = GenerateGymLeader();
            Battle battle = new Battle(player, rival);
            printer.Print("[ Gym leader walks in to the arena ].");
            printer.Print("[ The crowd is going wild! ].");
            Console.ReadKey();
            Console.Clear();
            printer.Print(" - Welcome, challenger! I've been waiting for this moment.");
            printer.Print(" - Your journey has led you here, but do you have what it takes to face me, the Gym Leader?");
            printer.Print(" - Prepare yourself, for I'll show you the true strength of a Gym Leader!");
            Console.ReadKey();
            Console.Clear();
            printer.Print("Ladies and gentlemen!");
            printer.Print($"We're about to witness an epic showdown between the challenger {player.Name} and the esteemed Gym Leader!");
            Console.ReadKey();
            battle.Fight();
            Console.Clear();

            if (battle.playerPokemon == battle.Winner) // Does the same if-statement 2 times maybe we could remove it 
            {
                EndGameScene();
            }
            else
            {
                printer.Print("You are not yet strong enough to beat the gym leader.");
                printer.Print("Go back to train your Pokemon!");
                Console.Clear();
                Console.ReadKey();
                Training();
            }
        }

        private void EndGameScene()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            printer.LoadingScene();
            Console.Clear();
            printer.Print("You've proven yourself to be an exceptional trainer.");
            printer.Print("Your determination and bond with your Pokemon are truly remarkable.");
            Console.ReadKey();
            Console.Clear();
            printer.Print("As a symbol of your achievement, I present you with this trophy.");
            printer.Print("You are now recognized as the ultimate Pokemon Trainer in our region.");
            Console.ReadKey();
            Console.Clear();
            printer.Print($"And so, the journey of {player.Name} \n ");
            printer.Print("- the ultimate Pokemon Trainer - \n");
            printer.Print("comes to an end.");
            Console.ReadKey();
            Console.Clear();
            printer.Print("Their passion, dedication, and the unbreakable bond with their Pokemon");
            printer.Print("have made them a legend in the Pokemon world.");
            Console.WriteLine(); 
            printer.Print("The end");
            Console.ReadKey();
            Console.Clear();
            printer.LoadingScene();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine(@"


    ██████╗░░█████╗░██╗░░██╗███████╗██╗░░░██╗░█████╗░███╗░░██╗
    ██╔══██╗██╔══██╗██║░██╔╝██╔════╝███░░███║██╔══██╗████╗░██║
    ██████╔╝██║░░██║█████═╝░█████╗░░██╔██╝██║██║░░██║██╔██╗██║
    ██╔═══╝░██║░░██║██╔═██╗░██╔══╝░░██║░░░██║██║░░██║██║╚████║
    ██║░░░░░╚█████╔╝██║░╚██╗███████╗██║░░░██║╚█████╔╝██║░╚███║
    ╚═╝░░░░░░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░░╚═╝░╚════╝░╚═╝░░╚══╝
            
          A text-based adventure based on a classic.




            ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t Press any key to close this window. . .");
            Console.ReadKey();
        }
    }
}

