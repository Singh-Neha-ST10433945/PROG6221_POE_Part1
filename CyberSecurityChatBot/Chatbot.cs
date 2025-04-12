using System;
using System.Threading.Tasks;

namespace CyberSecurityChatBot
{
    class Chatbot
    {
        // Main method to start chatbot interaction
        public static void StartChat()
        {
            // Show intro animation and play voice greeting
            Task audioTask = AudioPlayer.PlayGreetingAsync();
            ASCIIArt.DisplayTitleScreen(audioTask);

            // Display welcome message
            StartGreetingSequence();
            string name = Utils.GetUserName();
            Utils.DisplayCenteredText($"Hi {name}, it’s great to have you here! \U0001F60A", true);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What would you like to chat about today?");
            Console.ResetColor();

            bool menuShown = false; // Tracks if the help menu has been displayed

            // Begin main chat loop
            while (true)
            {
                Console.Write("\nYour message: ");
                string userInput = Console.ReadLine().Trim().ToLower();

                // Check for exit commands
                if (HandleExit(userInput, name)) break;

                // Prevent number selection before menu is shown
                if (int.TryParse(userInput, out _) && !menuShown)
                {
                    Utils.Warn("Hey! Try typing a keyword like 'phishing' or 'passwords' first.");
                    continue;
                }

                // Get chatbot response
                Tuple<string, string, bool> result = ResponseHandlers.GetResponse(userInput);
                string title = result.Item1;
                string response = result.Item2;
                bool isPersonal = result.Item3;

                // Unlock number options if help/menu was just shown
                if (title == "Topics You Can Ask About")
                    menuShown = true;

                if (!string.IsNullOrEmpty(response))
                {
                    if (isPersonal)
                        Utils.TypeOut(response); // Friendly reply
                    else
                        Utils.DisplayResponseFormatted(title, response); // Educational reply

                    Utils.DisplayRandomTagline(); // Cyber tip
                    Utils.DisplayCenteredAssistMessage(); // Ask for more help
                }
                else
                {
                    // Fallback: show menu options
                    Utils.Warn("Hmm, I didn't catch that. Maybe try one of these options:");
                    Utils.DisplayOptions();
                    menuShown = true;

                    Utils.PrintPinkDivider();
                    Console.Write("Choose a number or keyword: ");
                    userInput = Console.ReadLine().Trim().ToLower();
                    Utils.PrintPinkDivider();

                    if (HandleExit(userInput, name)) break;

                    result = ResponseHandlers.GetResponse(userInput);
                    title = result.Item1;
                    response = result.Item2;
                    isPersonal = result.Item3;

                    if (title == "Topics You Can Ask About")
                        menuShown = true;

                    if (!string.IsNullOrEmpty(response))
                    {
                        if (isPersonal)
                            Utils.TypeOut(response);
                        else
                            Utils.DisplayResponseFormatted(title, response);

                        Utils.DisplayRandomTagline();
                        Utils.DisplayCenteredAssistMessage();
                    }
                    else
                    {
                        Utils.Warn("Still didn't get that. Let's try again!");
                    }
                }
            }
        }

        // Introductory greeting sequence
        private static void StartGreetingSequence()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Hi there! \U0001F338 My name is CYRA — short for Cybersecurity Awareness Assistant!");
            Console.WriteLine("‘Cyra’ also means SUN, which is perfect because I’m here to shine some light on online safety \U0001F4BB\u2728");
            Console.WriteLine("Let’s team up to rule your digital world securely. What's your name?");
            Console.ResetColor();
        }

        // Handles graceful chatbot exit
        private static bool HandleExit(string input, string name)
        {
            if (input == "exit" || input.Contains("bye") || input == "6")
            {
                string farewell = $"TAKE CARE, {name.ToUpper()}! STAY SAFE ONLINE. ★";
                string line = new string('═', Console.WindowWidth);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n" + line);
                Console.WriteLine(farewell.PadLeft((Console.WindowWidth / 2) + (farewell.Length / 2)));
                Console.WriteLine(line);
                Console.ResetColor();
                return true;
            }
            return false;
        }
    }
}
