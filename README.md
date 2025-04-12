# PROG6221 POE - Part 1

This is Part 1 of the Portfolio of Evidence for the PROG6221 module.

## 🔄 CI Status

![CI](https://github.com/Singh-Neha-ST10433945/PROG6221_POE_Part1/actions/workflows/dotnet-desktop.yml/badge.svg)

## 📌 Project Overview

CYRA is a console-based chatbot developed in C# that provides friendly and educational guidance on cybersecurity topics. It responds to user input based on recognized keywords and simulates personality through typing animations, taglines, and friendly language.

---

## 🛠 Features

- Interactive console interface  
- Predefined responses to cybersecurity topics (phishing, safe browsing, etc.)  
- Friendly personality with small talk support  
- Typing animation for realism  
- GitHub Actions Continuous Integration (CI)

---

## 📦 Technologies Used

- C# (.NET Core Console Application)  
- Visual Studio  
- GitHub Actions for CI/CD  
- Git for version control

---

## 🚀 Setup Instructions

To run this project locally:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Singh-Neha-ST10433945/PROG6221_POE_Part1.git
   cd PROG6221_POE_Part1
   ```

2. **Open the solution in Visual Studio**  
   File → Open → Project/Solution → `CyberSecurityChatBot/CyberSecurityChatBot.sln`

3. **Build the solution**  
   Press `Ctrl + Shift + B` or click **Build > Build Solution**

4. **Run the chatbot**  
   Press `F5` or click the green **Start** button

---

## 🧑‍💻 How to Use CYRA

1. After launching, CYRA greets the user and requests their name.
2. The user can ask about:
   - `"phishing"`
   - `"strong passwords"`
   - `"social engineering"`
   - Or type `"help"` or `"menu"` to view topics
3. CYRA will respond with friendly, educational tips.
4. To exit, type:
   - `"exit"`
   - `"bye"`
   - or enter `6`

---

## 📂 Folder Structure

```
📁 CyberSecurityChatBot/
├── ASCIIArt.cs               # Logo and animation
├── AudioPlayer.cs            # Greeting sound
├── Chatbot.cs                # Main chatbot logic
├── ResponseHandlers.cs       # Keyword detection and responses
├── Utils.cs                  # Formatting and helper methods
├── Program.cs                # Entry point
├── greeting.wav              # Welcome sound effect
├── CyberSecurityChatBot.sln  # Visual Studio solution
└── CyberSecurityChatBot.csproj  # Project file
```

---

## 👤 Author

**Neha Singh**  
IIE MSA  
Module: PROG6221  
POE Part 1 – Cybersecurity Chatbot Project
