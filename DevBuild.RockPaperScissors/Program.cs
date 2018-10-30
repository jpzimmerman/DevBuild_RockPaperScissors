using System;
using System.Collections.Generic;
using System.Threading;
using DevBuild.Utilities;

namespace DevBuild.RockPaperScissors {
    public enum Roshambo { Rock = Player.ROSHAMBO_STARTING_OFFSET, Paper, Scissors, NotSelected }
    public enum PlayerType { Player, Opponent }

    class Program {
        public static int PlayerVictories { get; set; }
        public static int OpponentVictories { get; set; }
        public static Player PlayerObject { get; set; } = new RoshamboApp();

        public static string[] roshamboOptions = { "Rock", "Paper", "Scissors" };
        public static string[] opponentSelectionOptions = { "Smart", "Dumb", "Chaos" };

        static void Main(string[] args) {
            Player opposingPlayerObj;
            Console.WriteLine("Welcome to Rock Paper Scissors!");
            PlayerObject.Name = UserInput.PromptUntilValidEntry("Please enter your name: ", InformationType.Name);

            while (true) {
                // Get the player's selection for opposing player type
                // (this will determine which AI we use against the player)
                MenuHandling.PrintMenuOptions(opponentSelectionOptions, menuMode: true, messagePrompt: "Would you like to play against a Smart player, a Dumb player, or a Chaos player? ");
                var userSelection = UserInput.SelectMenuOption(opponentSelectionOptions.Length);

                switch (opponentSelectionOptions[userSelection - 1]) {
                    case "Smart": opposingPlayerObj = new SavvyPlayer(); break;
                    case "Dumb": opposingPlayerObj = new DumbAsARockPlayer(); break;
                    case "Chaos": opposingPlayerObj = new ChaosPlayer(); break;
                    default: opposingPlayerObj = new ChaosPlayer(); break;
                }

                PlayRoshambo(PlayerObject, opposingPlayerObj);

                var yesOrNo = UserInput.GetYesOrNoAnswer("Would you like to play again? (y/n or yes/no) ");
                switch (yesOrNo) {
                    case YesNoAnswer.Yes: continue;
                    case YesNoAnswer.No: return;
                }
            }
        }

        /// <summary>
        /// This method will collect information on whether the player chooses Rock, Paper, or Scissors, and match them against an AI player of their choosing
        /// </summary>
        /// <param name="player">Player object for holding the human player data</param>
        /// <param name="opponent">Player object for holding the opposing AI player data</param>
        public static void PlayRoshambo(Player player, Player opponent) {
            LoopStart:
            MenuHandling.PrintMenuOptions(roshamboOptions, menuMode: true, messagePrompt: "Do you choose Rock, Paper, or Scissors? ");
            var userSelection = UserInput.SelectMenuOption(roshamboOptions.Length);
            player.RockPaperScissorsChoice = (Roshambo)((userSelection - 1) + Player.ROSHAMBO_STARTING_OFFSET);
            if (opponent is SavvyPlayer) { opponent.RockPaperScissorsChoice = opponent.GenerateRoshambo(); }

            Console.WriteLine($"\nYou chose {player.RockPaperScissorsChoice}");
            Console.WriteLine($"{opponent.Name} chose {opponent.RockPaperScissorsChoice}");

            //if players didn't make the same choice, test to see who won. Else, have players choose again
            if (player.RockPaperScissorsChoice != opponent.RockPaperScissorsChoice) {
                var winner = (player.RockPaperScissorsChoice == Player.CounterTo[opponent.RockPaperScissorsChoice] ? PlayerType.Player : PlayerType.Opponent);
                //once we know who won, let's increment our counters
                switch (winner) {
                    case PlayerType.Player: PlayerVictories++; break;
                    case PlayerType.Opponent: OpponentVictories++; break;
                    default: break;
                }
                //now announce the winner
                Console.WriteLine($"{(winner == PlayerType.Player ? player.Name.ToUpper() : opponent.Name.ToUpper())} WINS!");
            }
            else { Console.WriteLine("Tie, SUDDEN DEATH!\n"); goto LoopStart; }
            Console.WriteLine($"Player Victories: {PlayerVictories}, Opponent Victories: {OpponentVictories}\n");
        }

        #region Extra test methods for AI
        public static void SimulationByClass(Player testPlayer) {
            Dictionary<Roshambo, int> choiceCtr =
                                        new Dictionary<Roshambo, int>() {   { Roshambo.Rock, 0 },
                                                                            { Roshambo.Paper, 0 },
                                                                            { Roshambo.Scissors, 0 } };

            while (true) {
                testPlayer.GenerateRoshambo();
                choiceCtr[testPlayer.RockPaperScissorsChoice]++;
                foreach (KeyValuePair<Roshambo, int> c in choiceCtr) {
                    Console.WriteLine($"{c.Key}   :   {c.Value}");
                }
                Thread.Sleep(8);
                Console.Clear();
            }
        }
        #endregion
    }
}