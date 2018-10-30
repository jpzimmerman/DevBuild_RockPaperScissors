﻿using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBuild.Utilities
{
    public enum YesNoAnswer { No = 0, Yes = 1, AnswerNotGiven = 2, } //for convention's sake, let's make sure Yes = 1 and No = 0;
    
    class UserInput
    {
        /// <summary>
        /// This function prompts the user to type "y", "yes", "n", or "no" to provide a yes-or-no answer. Function stays in a loop until 
        /// user enters something we recognize as a yes or no answer.
        /// </summary>
        /// <returns>A yes-or-no answer enum set to Yes, No, or Answer Not Given. </returns>
        public static YesNoAnswer GetYesOrNoAnswer(string questionPrompt)
        {
            YesNoAnswer tmp = YesNoAnswer.AnswerNotGiven;
            string userResponse = "";

            while ( userResponse != "y" && userResponse != "yes" && 
                    userResponse != "n" && userResponse != "no")
            {
                Console.Write(questionPrompt);
                userResponse = Console.ReadLine().Trim().ToLower();
            }
            switch (userResponse)
            {
                case "y":
                case "yes": tmp = YesNoAnswer.Yes; break;
                case "n":
                case "no":  tmp = YesNoAnswer.No; break;
                default: tmp = YesNoAnswer.AnswerNotGiven; break;
            }
            return tmp;
        }

        public static string PromptUntilValidEntry(string message, params InformationType[] inputValidationFilters) {
            string response = "";
        LoopStart:
            Console.Write(message);
            while (String.IsNullOrEmpty(response)) {
                response = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(response)) {
                    Console.Write(message);
                    continue;
                }
                foreach (InformationType infoType in inputValidationFilters) {
                    if (!Validation.ValidateInfo(infoType, response)) {
                        response = "";
                        goto LoopStart;
                    }
                }
            }
            return response;
        }

        public static void PromptUntilValidEntry(string message, out string response, params InformationType[] inputValidationFilters)
        {
            response = "";
            LoopStart:
            Console.Write(message);
            while (String.IsNullOrEmpty(response))
            {
                response = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(response))
                {
                    Console.Write(message);
                    continue;
                }
                foreach (InformationType infoType in inputValidationFilters)
                {
                    if (!Validation.ValidateInfo(infoType, response))
                    {
                        response = "";
                        goto LoopStart;
                    }
                }
            }
            return;
        }

        public static uint SelectMenuOption(int numberOfOptions) {
            uint userSelection = 0;
            string userEntry = "";

            while (!uint.TryParse(userEntry, out userSelection) ||
                    userSelection < 0 ||
                    userSelection > numberOfOptions) {
                PromptUntilValidEntry($"Please enter a selection, 1-{numberOfOptions}: ", out userEntry, InformationType.Numeric);
            }
            return userSelection;
        }
    }


}
