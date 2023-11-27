using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PokemonAdventure
{
    class Pokemon : IDamageable, IHealable, ILevelable
    {
        ConsolePrinter printer = new ConsolePrinter();
        
        public string Name { get; set; }
        public int MaxHealth
        {
            get => Level * 10;
        }
        public int CurrentHealth { get; set; }
        public int ExperiencePoints { get; set; } //XP = Default 0
        public List<Move> Moves { get; set; }
        public string MoveName { get; set; }
        public int Power => Level * 1/2;
        public int Defence
        {
            get => Level * 2;
            set { }
        }
        public int Level { get; set; }
        public int LevelThreshold => Level * 20;
        public bool ShouldLevelUp => ExperiencePoints >= LevelThreshold;
        public Pokemon(string name)
        {
            this.Name = name;
            Level = 5;
            Heal(MaxHealth);
        }
        public Pokemon(string name, Move moves)
        {
            this.Name = name;
            Level = 5;
            Heal(MaxHealth);
            Moves.Add(moves);
        }
        public Pokemon(string name, int level, Move moves) //rival pokemons + boss pokemon 
        {
            this.Name = name;
            this.Level = level;
            Heal(MaxHealth);
            Moves.Add(moves);
            
        }
        public void TakeDamage(int damage)
        {
            this.CurrentHealth -= damage; 
        }
        public void Heal(int maxhealth)
        {
            CurrentHealth = maxhealth; 
        }
        public void LevelUp() // make level up stats 
        {
            while(ShouldLevelUp)
            {
                Level++;
            }
            printer.Print($"{Name} leveled up!");
            printer.Print($"{Name} has reached level {Level}");
            PokemonStats();
        }

        public void PokemonStats()
        {
            printer.Print($"{Name}: HP:{CurrentHealth}/{MaxHealth} XP:{ExperiencePoints}/{LevelThreshold} Level:{Level}");
        }
    }
}
