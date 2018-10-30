using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RockPaperScissors {
    public class DumbAsARockPlayer : Player {
        private new static string[] possibleNames = { "Basalt", "Obsidian", "Pluton", "Siltstone", "Gabbro"};

        public DumbAsARockPlayer() : base(possibleNames) {
        }

        public override Roshambo GenerateRoshambo() {
            RockPaperScissorsChoice = Roshambo.Rock;
            return RockPaperScissorsChoice;
        }
    }
}
