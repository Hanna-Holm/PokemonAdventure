﻿using PokemonAdventure.Moves;
using PokemonAdventure.PokemonTypes;
using PokemonAdventure.UserInteraction;

namespace PokemonAdventure.PokemonSpecifier
{
    internal class Pokemon : ILevelable, IHealable, IDamageable, IPokemonType
    {
        public string Name { get; set; }
        public IPokemonType Type { get; init; }
        public string TypeName { get; }
        public int ExperiencePoints { get; set; } = 0;
        private int levelFactor = 10;
        public int Level { get; set; } = 5;
        public int LevelThreshold => Level * 10;
        public bool ShouldLevelUp
            => ExperiencePoints >= LevelThreshold;
        private int currentHealth;
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (value < 0)
                    currentHealth = 0;
                else
                    currentHealth = value;
            }
        }
        private int maxHealth { get; set; }

        // 1. Concept: Encapsulation
        // 2: How? We are hiding the backing field power by using the access modifier private.
        //    Access to the private power field is only possible inside this class itself.
        //    We ensure that the power is never set to an invalid state from outside this class
        //    by having logic in the public Power property, and having the backing field private.
        // 3. Why? The property Power is part of the public interface that we can interact with from outside this class,
        //    and we ensure that the power cannot be set to an invalid state from outside this class.
        //    We cannot set the private power from outside this class, only through the public property
        //    that contains the logic.
        private int power;
        public int Power 
        {
            get => power;
            set
            {
                if (value < 0)
                    power = 0;
                else
                    power = value;
            }
        }

        //public int Speed { get; set; } = 25;
        //public int Accuracy { get; set; } = 3;
        private int defence = 25;
        public int Defence
        {
            get => defence;
            set
            {
                if (value < 0)
                    defence = 0;
                else
                    defence = value;
            }
        }

        public List<Move> TypeSpecificMoves { get; set; }
        public List<Move> Moves { get; private set; } = new List<Move> { };

        private Validator validator = new Validator();
        private ConsolePrinter printer = new ConsolePrinter();
        private int pauseInMs = 1000;

        public Pokemon(string name, IPokemonType type)
        {
            this.Name = name;
            this.Type = type;
            SetStatsBasedOfLevel();
            RestoreHealth();
            GenerateMoves(4);
        }

        // 1. Concept: Constructor overload
        // 2. How? We define two different constructors in this class, one the that takes the parameters
        //    string name and IPokemonType, and one that takes the parameters string name, IPokemonType type and int Level
        // 3. Why? This enables object construction is two different ways. We can create new objects of this class
        //    by calling either one of these two constructors. This makes the creation of objects more flexible.

        // 1. Concept: Constructor chaining
        // 2. How? We use the syntax : this() in the second constructor. The keyword this refers to the same class.
        //    and we pass on the parameters needed in the first constructor which in this case is name and type. 
        //    The way this works is that when creating a new object by calling this second constructor,
        //    the chained constructor is called first with name and type, and after that this constructor with three parameters
        //    that called the chained constructor is executed.
        // 3. Why? This enables code reuse, and avoids code duplication, as we can run the code from the chained constructor first
        //    and therefore do not need to write the same code twice.
        public Pokemon(string name, IPokemonType type, int Level) : this(name, type)
        {
            this.Level = Level;
            SetStatsBasedOfLevel();
            RestoreHealth();
        }

        public void GenerateMoves(int numberOfMoves)
        {
            int random = new Random().Next(0, Type.TypeSpecificMoves.Count - numberOfMoves);

            for (int i = 0; i < numberOfMoves; i++)
            {
                Moves.Add(Type.TypeSpecificMoves[random]);
                random++;
            }
        }

        public void LearnNewMove(Move newMove)
        {
            this.Moves.Add(newMove);
        }

        public Move ChooseMove()
        {

            bool isValid = false;
            int numberOfMovesAvailable = this.Moves.Count;
            string choice = "";

            do
            {
                printer.Print("Choose attack:\n");

                for (int i = 0; i < numberOfMovesAvailable; i++)
                {
                    Console.WriteLine($"{i + 1}. {this.Moves[i].Name}");
                }
                choice = Console.ReadLine();
                isValid = validator.CheckIfValidNumber(choice, numberOfMovesAvailable);
            } while (!isValid);

            int moveNumber = int.Parse(choice);
            return this.Moves[moveNumber - 1];
        }

        public void MakeMove(Move move, Pokemon target)
        {
            // 1. Concept: Subtype-polymorfism
            // 2. How? The method GetUsedBy gets invoked on the run-time type of move.
            //    A Move can be any type derived from the abstract Move class.
            //    For example the concrete classes AttackMove or DecreaseDefenceMove
            //    which both have their own implementation of the GetUsedBy method.
            //    Which method is called is determined in run-time depending on the
            //    run-time type, which is whatever type of Move that is sent in as 
            //    an argument to this MakeMove method.
            // 3. Why? This enables dynamic dispatch which means that the method that
            //    gets invoked depends on what the run-time type of move is.
            //    The GetUsedBy method is invoked on the run-time type.
            //    This is an example of subtype-polymorphism where we can write general
            //    code that can be used for all subtypes.
            //    The method GetUsedBy is called on whatever type the move is at run-time,
            //    which means that we do not need to write several if-statements to decide
            //    what method should be invoked, we can replace conditional with polymorphism.
            move.GetUsedBy(this, target);
            Console.ReadKey();
        }

        public void TakeDamage(int damage)
        {
            this.CurrentHealth -= damage;
        }

        public void IncreaseExperiencePointsBasedOf(Pokemon defeated)
        {
            this.ExperiencePoints += defeated.Level * levelFactor;
            printer.Print($"{this.Name} gained {ExperiencePoints} XP!");
            
            if (this.ShouldLevelUp)
            {
                while (this.ShouldLevelUp)
                {
                    LevelUp();
                }
                this.ExperiencePoints = 0;
            }
            else
                printer.Print($"Current XP count: {this.ExperiencePoints}. You need {LevelThreshold - this.ExperiencePoints} more to level up.");

            Console.ReadKey();
        }

        public void SetStatsBasedOfLevel()
        {
            this.maxHealth = GetMaxHealthForLevel(this.Level);
            this.Power = GetPowerForLevel(this.Level);
            this.Defence = GetDefenceForLevel(this.Level);
        }

        public void LevelUp()
        {
            Level++;
            printer.Print($"{this.Name} grew to level {this.Level}!");
            Thread.Sleep(pauseInMs);

            SetStatsBasedOfLevel();
            PrintNewLevelStats();
        }

        public void PrintNewLevelStats()
        {
            printer.Print($"Stats for {this.Name}:\n");
            Console.WriteLine($"Max HP: {this.maxHealth} (+{maxHealth - GetMaxHealthForLevel(this.Level - 1)})");
            Console.WriteLine($"Attack: {this.Power} (+{Power - GetPowerForLevel(this.Level - 1)})");
            Console.WriteLine($"Defence: {this.Defence} (+{Defence - GetDefenceForLevel(this.Level - 1)})");
        }

        public void PrintStats(Pokemon pokemon)
        {
            printer.Print($"{Name}: HP: {CurrentHealth}/{maxHealth} XP: {ExperiencePoints}/{LevelThreshold}\n");
        }

        public void RestoreHealth()
        {
            CurrentHealth = maxHealth;
        }

        public int GetMaxHealthForLevel(int level)
            => level * 20;

        public int GetPowerForLevel(int level)
            => level * 6;
        public int GetDefenceForLevel(int level)
            => level * 5;

    }
}