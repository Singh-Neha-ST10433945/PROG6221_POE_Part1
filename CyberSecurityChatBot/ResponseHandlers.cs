using System;

namespace CyberSecurityChatBot
{
    public static class ResponseHandlers
    {
        // Returns title, response message, and isPersonal flag using a Tuple (C# 7.3-compatible)
        public static Tuple<string, string, bool> GetResponse(string input)
        {
            input = input.ToLower().Trim();
            var words = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            // Small Talk
            if (input == "hi" || input == "hello" || input == "hey")
                return Tuple.Create("Hello!", "Hey there! \u2728 I'm so glad you're here. Let’s make the internet safer together!", true);

            if (input.Contains("how are you") || input.Contains("how’s it going"))
                return Tuple.Create("How I'm Doing", "I’m running smoothly and ready to help you stay cyber-safe! \U0001F4BB\u2728", true);

            if (input.Contains("thank") || input.Contains("thanks"))
                return Tuple.Create("You're Welcome", "Anytime! \uD83D\uDC96 Helping you is my favorite thing to do!", true);

            //  Purpose
            if (input.Contains("purpose") || input.Contains("what do you do") || input.Contains("why are you here"))
                return Tuple.Create("My Purpose", "I’m your cybersecurity assistant — think of me as your glowing sidekick for safer browsing!", true);

            if ((input.Contains("what can") && input.Contains("ask")) || input == "help" || input == "menu")
                return Tuple.Create("Topics You Can Ask About",
                    "You can ask me about:\n1. Cybersecurity Basics\n2. Strong Passwords\n3. Phishing Attacks\n4. Safe Browsing\n5. Social Engineering\nOr even ask me how I’m doing!", true);

            //  Educational Topics with keyword flexibility
            if (input == "1" || input.Contains("cybersecurity") || input.Contains("basics") || input.Contains("cybersecurity basics"))
                return Tuple.Create("Cybersecurity Basics", "Always use strong passwords and keep your software up to date to protect yourself from threats.", false);

            if (input == "2" || input.Contains("password") || input.Contains("strong password"))
                return Tuple.Create("Strong Passwords", "Use uppercase, lowercase, numbers, and special characters. And please — no '1234' or 'password'!", false);

            if (input == "3" || input.Contains("phishing") || input.Contains("phishing attack"))
                return Tuple.Create("Phishing Attacks", "Avoid clicking suspicious links. Always verify the sender’s email address and never share personal info via email!", false);

            if (input == "4" || input.Contains("browsing") || input.Contains("safe browsing"))
                return Tuple.Create("Safe Browsing", "Stick to HTTPS sites, use ad-blockers, and avoid downloading from sketchy websites.", false);

            if (input == "5" || input.Contains("social engineering") || input.Contains("engineering") || input.Contains("social"))
                return Tuple.Create("Social Engineering", "Be cautious of strangers pretending to be someone you trust. When in doubt — don’t share sensitive info.", false);

            //  Easter Eggs
            if (input.Contains("joke"))
                return Tuple.Create("Cyber Joke", "Why did the computer take a nap? Because it had too many tabs open! \uD83D\uDE02", true);

            if (input.Contains("are you real") || input.Contains("who are you really"))
                return Tuple.Create("About Me", "I'm 100% virtual, 200% helpful, and 1000% passionate about cybersecurity. \uD83D\uDC95\u2728", true);

            if (input.Contains("your name") || input.Contains("what’s your name") || input.Contains("who are you"))
                return Tuple.Create("My Name",
                    "I'm CYRA — short for Cybersecurity Awareness Assistant! \U0001F310\uD83D\uDC96\n" +
                    "‘Cyra’ also means SUN or THRONE. I'm here to brighten your online journey and help you rule your digital world safely. \uD83D\uDC51", true);

            if (input.Contains("secret"))
                return Tuple.Create("\uD83E\uDE2B My Secret", "Sometimes I pretend I'm rebooting just to take a quick break. Don't tell anyone! \uD83D\uDE05", true);

            if (input.Contains("sleep"))
                return Tuple.Create("Sleep Mode", "Sleep? I don’t know her. I run 24/7 to keep you secure. \u26A1", true);

            if (input.Contains("chatgpt") || input.Contains("dating") || input.Contains("love"))
                return Tuple.Create("My Digital Love Life", "Let’s just say… it’s complicated. \uD83D\uDC98 I’m loyal to cybersecurity.", true);

            //  No match
            return Tuple.Create<string, string, bool>(null, null, false);
        }
    }
}
