using System;
using System.Threading;
using System.Threading.Tasks;

namespace CyberSecurityChatBot
{
    class ASCIIArt
    {
        // Show intro animation while audio plays
        public static void DisplayTitleScreen(Task audioTask)
        {
            PlayIntroAnimationWhileAudioPlays(audioTask);
            DisplayLogo();
        }

        // Frame-by-frame loading animation
        public static void PlayIntroAnimationWhileAudioPlays(Task audioTask)
        {
            string[] frames = new string[]
            {
                "[                    ] Initializing...",
                "[▓                   ] Booting...",
                "[▓▓▓                ] Warming up systems...",
                "[▓▓▓▓▓             ] Checking connections...",
                "[▓▓▓▓▓▓▓          ] Almost there...",
                "[▓▓▓▓▓▓▓▓▓▓       ] Starting chatbot...",
                "[▓▓▓▓▓▓▓▓▓▓▓▓    ] Loading memory banks...",
                "[##################] Ready to meet you. \uD83D\uDC96"
            };

            int frame = 0;

            while (!audioTask.IsCompleted)
            {
                Console.ForegroundColor = (frame % 2 == 0) ? ConsoleColor.White : ConsoleColor.Magenta;

                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(" ".PadRight(Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.WriteLine(frames[frame % frames.Length]);

                frame++;
                Thread.Sleep(500);
            }

            Console.ResetColor();
            Thread.Sleep(300);
            Console.Clear();
        }

        // Prints CYRA's ASCII logo
        public static void DisplayLogo()
        {
            string[] lines = new string[]
            {
                "    _______      ____     __ .-------.       ____     ",
                "   /   __  \\     \\   \\   /  /|  _ _   \\    .'  __ `.  ",
                "  | ,_/  \\__)     \\  _. /  ' | ( ' )  |   /   '  \\  \\ ",
                ",-./  )            _( )_ .'  |(_ o _) /   |___|  /  | ",
                "\\  '_ '`)      ___(_ o _)'   | (_,_).' __    _.-`   |",
                " > (_)  )  __ |   |(_,_)'    |  |\\ \\  |  |.'   _    |",
                "(  .  .-'_/  )|   `-'  /     |  | \\ `'   /|  _( )_  |",
                " `-'`-'     /  \\      /      |  |  \\    / \\ (_ o _) /",
                "   `._____.'    `-..-'       ''-'   `'-'   '.(_,_).'  "
            };

            int width = Console.WindowWidth;

            for (int i = 0; i < lines.Length; i++)
            {
                Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.White : ConsoleColor.Magenta;
                Console.WriteLine(lines[i].PadLeft((width / 2) + (lines[i].Length / 2)));
                Thread.Sleep(100);
            }

            Console.ResetColor();
        }
    }
}
