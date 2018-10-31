using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RockPaperScissors {
    public abstract class Player {
        public const int ROSHAMBO_STARTING_OFFSET = 200;

        // Let's use this dictionary as a matrix to keep track of counter moves, 
        // then let the AI use it to counter-pick players
        // Listen, AI has to cheat every once in a while...
        public static readonly Dictionary<Roshambo, Roshambo> CounterTo = 
            new Dictionary<Roshambo, Roshambo>() { { Roshambo.Rock,     Roshambo.Paper },
                                                   { Roshambo.Paper,    Roshambo.Scissors },
                                                   { Roshambo.Scissors, Roshambo.Rock}  };
        public string Name { get; set; }
        public Roshambo RockPaperScissorsChoice { get; set; }
        public string[] possibleNames = { "default1", "default2", "default3" };

        public Player() {
            var selectionIndex = new Random().Next(0, GetPossibleNames().Length);
            Name = GetPossibleNames()[selectionIndex];
            RockPaperScissorsChoice = GenerateRoshambo();
        }

        public abstract Roshambo GenerateRoshambo();

        public abstract string[] GetPossibleNames();

    }
}