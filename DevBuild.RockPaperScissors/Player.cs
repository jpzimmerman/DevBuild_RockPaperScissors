using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RockPaperScissors {
    public abstract class Player {

        // Let's use this dictionary as a matrix to keep track of counter moves, 
        //then use it to counter-pick players
        // Listen, AI has to cheat every once in a while...
        protected readonly static Dictionary<Roshambo, Roshambo> CounterTo = 
            new Dictionary<Roshambo, Roshambo>() { { Roshambo.Rock,     Roshambo.Paper },
                                                   { Roshambo.Paper,    Roshambo.Scissors },
                                                   { Roshambo.Scissors, Roshambo.Rock}  };
        protected string Name { get; set; }
        protected Roshambo RockPaperScissorsChoice { get; set; }

        public abstract void GenerateRoshambo();

    }
}
