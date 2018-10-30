using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RockPaperScissors {
    class RoshamboApp : Player {
        private new static string[] possibleNames = { "Jimbo", "Irene", "Devon", "Jennifer" };

        public RoshamboApp() : base(possibleNames) {
            RockPaperScissorsChoice = Roshambo.NotSelected;

        }
        public override Roshambo GenerateRoshambo() {
            return RockPaperScissorsChoice;
        }
    }
}
