using System;
using System.Threading;

namespace CyberSecurityChatBot
{
    class Utils
    {
        // Prompts the user for their name and clears the screen after
        public static string GetUserName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();
            return name;
        }

        // Displays centered text with optional decorative border
        public static void DisplayCenteredText(string text, bool withBorder = false)
        {
            int width = Console.WindowWidth;
            string centered = text.PadLeft((width / 2) + (text.Length / 2));

            if (withBorder)
            {
                string line = new string('═', width);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(line);
                Console.WriteLine(centered);
                Console.WriteLine(line);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(centered);
            }
        }

        // Formats and types out a response with a title
        public static void DisplayResponseFormatted(string title, string response)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.ResetColor();

            TypeOut("\nHere's information about " + title + ":\n" + response);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('_', Console.WindowWidth));
            Console.ResetColor();
        }

        // Shows the default list of topic options
        public static void DisplayOptions()
        {
            string[] options =
            {
                "1. Cybersecurity Basics",
                "2. Strong Passwords",
                "3. Phishing Attacks",
                "4. Safe Browsing",
                "5. Social Engineering",
                "6. Exit Chatbot"
            };

            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (string option in options)
            {
                Console.WriteLine(option);
            }
            Console.ResetColor();
        }

        // Shows a follow-up prompt centered with dividers
        public static void DisplayCenteredAssistMessage()
        {
            string line = new string('═', Console.WindowWidth);
            string message = "CAN I ASSIST WITH ANYTHING ELSE?";
            string centered = message.PadLeft((Console.WindowWidth / 2) + (message.Length / 2));

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(line);
            Console.WriteLine(centered);
            Console.WriteLine(line);
            Console.ResetColor();
        }

        // Draws a decorative pink divider
        public static void PrintPinkDivider()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.ResetColor();
        }

        // Shows a warning message in yellow
        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
        }

        // Simulates typing character-by-character (used for personal replies)
        public static void TypeOut(string message, int delay = 25)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        // Displays a random motivational/cyber tip tagline
        public static void DisplayRandomTagline()
        {
            string[] taglines = new string[]
            {
                "\U0001F510 A safe password is a happy password!",
                "\U0001F4A1 CYRA Tip: If in doubt, throw it out (especially sketchy emails).",
                "\U0001F9E0 Think before you click!",
                "\u2728 Stay safe, stay cyber smart!",
                "\U0001F451 Rule your digital kingdom wisely."
            };

            Random random = new Random();
            string line = taglines[random.Next(taglines.Length)];

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n" + line);
            Console.ResetColor();
        }
    }
}
