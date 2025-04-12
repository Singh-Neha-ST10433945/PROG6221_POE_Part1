using System;
using System.Media;
using System.Threading.Tasks;
using System.IO;

namespace CyberSecurityChatBot
{
    class AudioPlayer
    {
        // Plays a greeting WAV file in the background (non-blocking to main thread)
        public static Task PlayGreetingAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    string path = "Assets/greeting.wav";
                    if (File.Exists(path))
                    {
                        using (SoundPlayer player = new SoundPlayer(path))
                        {
                            player.PlaySync(); // Plays the greeting audio synchronously
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Voice greeting not found. Skipping audio.");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error playing greeting: " + ex.Message);
                    Console.ResetColor();
                }
            });
        }
    }
}
