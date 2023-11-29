using PokemonAdventure.Moves;
using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;
using PokemonAdventure.PokemonTypes;

namespace PokemonAdventure
{
    internal class Story
    {
        private ConsolePrinter printer = new ConsolePrinter();
        private AllPokemon world = new AllPokemon();
        private PokemonGenerator PokemonGenerator = new PokemonGenerator();
        public Trainer player;
        private Pokemon startingPokemon;
        private int pauseInMs = 1000;

        public void Begin()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            printer.Print("Welcome to the world of Pokemon.");

            startingPokemon = PokemonGenerator.GeneratePokemon(world);
            startingPokemon.SetStatsBasedOfLevel();
            startingPokemon.RestoreHealth();
            InitializePlayer(startingPokemon);
            ExplainGame();
            BattleAgainstTrainer();

            Console.Clear();
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
            printer.Print($"{startingPokemon.Name} is of {startingPokemon.Type.TypeName} type, level {startingPokemon.Level} with HP {startingPokemon.CurrentHealth}");
            Console.ReadKey();
            Console.Clear();
            printer.Print("You are now entering the fantastic world of Pokemon...");
            printer.Print("Get ready to begin your adventure!");
            Console.ReadKey();
        }

        private Trainer GenerateRival()
        {
            Pokemon rivalPokemon = PokemonGenerator.GeneratePokemon(world, startingPokemon);
            rivalPokemon.SetStatsBasedOfLevel();
            rivalPokemon.RestoreHealth();
            rivalPokemon.Name = "Rival " + rivalPokemon.Name;
            return new Trainer(rivalPokemon);
        }

        private void BattleAgainstTrainer()
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
            battle.ExecuteEndofBattleConsequence();
            Console.Clear();
            ChoosePathAfterBattle();
            Console.Clear();
        }

        private void ChoosePathAfterBattle()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            printer.LoadingScene();
            Console.Clear();

            bool validChoice = false;
            do
            {
                printer.Print("Do you want to keep on training or meet the gym leader?\n");
                Console.WriteLine("1. Keep on training");
                Console.WriteLine("2. Battle against the gym leader!");

                ConsoleKeyInfo choice = Console.ReadKey();
                string action = choice.KeyChar.ToString();

                if (action == "1")
                {
                    validChoice = true;
                    BattleAgainstTrainer();
                }
                else if (action == "2")
                {
                    validChoice = true;
                    GymLeaderBattle();
                }
                else
                {
                    printer.Print("Please enter a valid number.");
                }
            } while (!validChoice);
        }
        private Trainer GenerateGymLeader()
        {
            Pokemon gymLeaderPokemon = PokemonGenerator.GenerateGymLeaderPokemon(world);
            gymLeaderPokemon.SetStatsBasedOfLevel();
            gymLeaderPokemon.RestoreHealth();
            gymLeaderPokemon.Name = "Leader " + gymLeaderPokemon.Name;
            return new Trainer(gymLeaderPokemon);
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
            printer.Print("- Ladies and gentlemen!");
            printer.Print($"- We're about to witness an epic showdown between the challenger {player.Name} and the esteemed Gym Leader!");
            Console.ReadKey();
            battle.Fight();
            Console.Clear();

            if (battle.playerPokemon == battle.Winner)
            {
                battle.ExecuteEndofBattleConsequence();
                EndGameScene();
            }
            else
            {
                printer.Print("You are not yet strong enough to beat the gym leader.");
                printer.Print("Go back to train your Pokemon!");
                Console.Clear();
                Console.ReadKey();
                BattleAgainstTrainer();
            }
        }

        private void EndGameScene()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            printer.LoadingScene();
            Console.Clear();
            printer.Print("- You've proven yourself to be an exceptional trainer.");
            printer.Print("- Your determination and bond with your Pokemon are truly remarkable.");
            Console.ReadKey();
            Console.Clear();
            printer.Print("- You are now recognized as the ultimate Pokemon Trainer in our region.");
            printer.Print("- As a symbol of your achievement, I present you with this badge.");
            Console.ReadKey();
            Console.Clear();
            printer.Print($"{player.Name} received a badge!\n ");
            Thread.Sleep(pauseInMs);
            Console.ReadKey();
            Console.Clear(); 
            printer.Print($"And so, the journey of {player.Name} \n ");
            printer.Print("- the ultimate Pokemon Trainer - \n");
            printer.Print("comes to an end.");
            Console.ReadKey();
            Console.Clear();
            printer.Print("Their passion, dedication, and the unbreakable bond with their Pokemon");
            printer.Print("have made them a legend in the Pokemon world.\n");
            printer.Print(" ~ * ~ The end ~ * ~ ");
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
        }
    }
}
