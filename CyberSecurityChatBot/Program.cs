using System;

namespace CyberSecurityChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start the chatbot interaction
            Chatbot.StartChat();

            // Display a friendly exit message from CYRA
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n★ CYRA says goodbye! Thanks for chatting — stay cyber-safe!");
            Console.WriteLine("Press any key to power me down... ★");
            Console.ResetColor();

            // Prevent the console from closing immediately after the chatbot ends
            Console.ReadKey();
        }
    }
}
