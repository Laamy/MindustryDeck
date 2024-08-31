using System;
using System.Diagnostics;
using System.IO;
using System.Management.Instrumentation;

class MindustryClient
{
    // C:\Users\yeemi\AppData\Roaming\Mindustry
    public static DirectoryInfo MindustryConfig =
        new DirectoryInfo(
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Mindustry"
            )
        );

    public static DirectoryInfo DeckConfig =
        new DirectoryInfo(
            Path.Combine(
                MindustryConfig.FullName,
                ".deck"
            )
        );

    public static void InitDeck()
    {
        Directory.CreateDirectory(DeckConfig.FullName); // create folder

        Directory.CreateDirectory(Path.Combine(DeckConfig.FullName, "Profiles")); // create profiles folder
    }

    public static void CheckSetup()
    {
        // Check if the client is setup correctly (for now i'll just assume they've moved the install into the data folder if it exists already)
        if (!Directory.Exists("Data"))
        {
            Directory.CreateDirectory("Data");

            Console.WriteLine("Please move your mindustry install into the Data folder next to mindustry deck");
            Console.ReadKey();

            Process.GetCurrentProcess().Kill();
        }

        // create the game data directory if it doesnt already exist & the desk folder
        if (!Directory.Exists(MindustryConfig.FullName))
        {
            Directory.CreateDirectory(MindustryConfig.FullName); // the game should create everything we want inside of here

            InitDeck();
        }
        else if (Directory.Exists(DeckConfig.FullName))
            InitDeck();
    }
}