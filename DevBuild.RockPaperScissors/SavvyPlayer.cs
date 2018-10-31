using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RockPaperScissors {
    public class SavvyPlayer : Player {
        private new static readonly string[] possibleNames = { "Bobby" };

        public SavvyPlayer() : base() {

        }

        public override Roshambo GenerateRoshambo() {
            Random r = new Random();

            //pick a random number to determine whether or not we'll choose by chance or attempt to counter-pick the player
            // currently a 1-in-3 chance we'll counter-pick the player
            var methodSelector = new Random().Next(0, 65535)%3;
            if (methodSelector % 3 == 0 && (Program.PlayerObject?.RockPaperScissorsChoice != Roshambo.NotSelected)) {
                Console.WriteLine("I won't lie to you, opponent cheated");
                RockPaperScissorsChoice = GenerateRoshambo(Program.PlayerObject.RockPaperScissorsChoice);
            }
            else {
                RockPaperScissorsChoice = (Roshambo)(ROSHAMBO_STARTING_OFFSET + r.Next(0, 65535) % 3);
            }
            return RockPaperScissorsChoice;
        }

        public Roshambo GenerateRoshambo(Roshambo playerPick) {
            return Player.CounterTo[playerPick];
        }

        public override string[] GetPossibleNames() => possibleNames;


    }
}
