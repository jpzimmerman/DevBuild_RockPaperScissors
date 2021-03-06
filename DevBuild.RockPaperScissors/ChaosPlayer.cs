﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.RockPaperScissors {
    class ChaosPlayer : Player {
        private new static readonly string[] possibleNames = { "Providence", "Destiny", "Fate" };

        public ChaosPlayer() : base() {
        }

        public override Roshambo GenerateRoshambo() {
            Random r = new Random();
            RockPaperScissorsChoice = (Roshambo)(ROSHAMBO_STARTING_OFFSET + r.Next(0, 65535)%3);
            return RockPaperScissorsChoice;
        }

        public override string[] GetPossibleNames() => possibleNames;
    }
}
