using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RockPaperScissors {
    class RoshamboApp : Player {
        private new static readonly string[] possibleNames = { "Jimbo", "Irene", "Devon", "Jennifer" };

        public RoshamboApp() : base() {
            RockPaperScissorsChoice = Roshambo.NotSelected;

        }
        public override Roshambo GenerateRoshambo() {
            return RockPaperScissorsChoice;
        }

        public override string[] GetPossibleNames() => possibleNames;

    }
}
