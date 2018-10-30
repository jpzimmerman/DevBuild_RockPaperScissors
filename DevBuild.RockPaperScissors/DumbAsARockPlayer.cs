using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RockPaperScissors {
    public class DumbAsARockPlayer : Player {

        public override void GenerateRoshambo() {
            RockPaperScissorsChoice = Roshambo.Rock;
        }
    }
}
