using System;
using System.Threading.Tasks;

namespace CyberSecurityChatBot
{
    class Chatbot
    {
        // Starts the chatbot interaction sequence
        public static void StartChat()
        {
            // Play the greeting audio and show an animated loading screen
            Task audioTask = AudioPlayer.PlayGreetingAsync();
            ASCIIArt.DisplayTitleScreen(audioTask);

            // Greet the user and ask for their name
            StartGreetingSequence();
            string name = Utils.GetUserName();
            Utils.DisplayCenteredText($"Hi {name}, it’s great to have you here! 😊", true);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What would you like to chat about today?");
            Console.ResetColor();

            // Flag to control whether number-based menu selection is allowed
            bool menuShown = false;

            // Begin chatbot conversation loop
            while (true)
            {
                Console.Write("\nYour message: ");
                string userInput = Console.ReadLine().Trim().ToLower();

                // Exit if user says goodbye or types "exit"
                if (HandleExit(userInput, name)) break;

                // Prevent users from choosing menu numbers before seeing the menu
                if (int.TryParse(userInput, out _) && !menuShown)
                {
                    Utils.Warn("Hey! Try typing a keyword like 'phishing' or 'passwords' first.");
                    continue;
                }

                // Get the chatbot's response based on user input
                var result = ResponseHandlers.GetResponse(userInput);
                string title = result.Item1;
                string response = result.Item2;
                bool isPersonal = result.Item3;

                // Once the help/menu is shown, allow number-based selection
                if (title == "Topics You Can Ask About")
                    menuShown = true;

                // If a valid response is returned, display it
                if (!string.IsNullOrEmpty(response))
                {
                    if (isPersonal)
                        Utils.TypeOut(response); // Use typing animation for personal responses
                    else
                        Utils.DisplayResponseFormatted(title, response); // Use formatted layout for topic responses

                    Utils.DisplayRandomTagline(); // Show a random motivational tip
                    Utils.DisplayCenteredAssistMessage(); // Ask the user if they need more help
                }
                else
                {
                    // If input isn't recognized, fallback to showing help options
                    Utils.Warn("Hmm, I didn't catch that. Maybe try one of these options:");
                    Utils.DisplayOptions();
                    menuShown = true;

                    // Give the user a second chance to select a topic
                    Utils.PrintPinkDivider();
                    Console.Write("Choose a number or keyword: ");
                    userInput = Console.ReadLine().Trim().ToLower();
                    Utils.PrintPinkDivider();

                    // Exit if they choose to quit
                    if (HandleExit(userInput, name)) break;

                    // Try to respond again after fallback
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
                        // Still nothing matched — prompt them to retry
                        Utils.Warn("Still didn't get that. Let's try again!");
                    }
                }
            }
        }

        // Displays the opening message and asks the user for their name
        private static void StartGreetingSequence()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Hi there! 🌸 My name is CYRA — short for Cybersecurity Awareness Assistant!");
            Console.WriteLine("‘Cyra’ also means SUN, which is perfect because I’m here to shine some light on online safety 💻✨");
            Console.WriteLine("Let’s team up to rule your digital world securely. What's your name?");
            Console.ResetColor();
        }

        // Handles logic for when the user wants to exit
        private static bool HandleExit(string input, string name)
        {
            if (input == "exit" || input.Contains("bye") || input == "6")
            {
                // Display a centered farewell message
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
