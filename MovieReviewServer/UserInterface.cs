using System.Drawing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

static class UserInterface
{
    public static void ProjectInfo(bool status)
    {
        Console.Clear();
        LogoAndStatus(status);
        bool back_button = false;

        string project_name = "Nome progetto: MovieReviewBL";
        Console.WriteLine(project_name.PadLeft((Console.WindowWidth + project_name.Length) / 2));
        string description = "Descrizione: Permette agli utenti di registrarsi per votare dei film";
        Console.WriteLine(description.PadLeft((Console.WindowWidth + description.Length) / 2));


        string authors = "Autori: Vito Bondanese, Marco Lanzillotta";
        Console.WriteLine(authors.PadLeft((Console.WindowWidth + authors.Length) / 2));

        
        string technologies = "Tecnologie usate: C#, EntityFramework, ASP.NET, MySQL";
        Console.WriteLine(technologies.PadLeft((Console.WindowWidth + technologies.Length) / 2));

        string back = "Indietro";
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(back.PadLeft((Console.WindowWidth + back.Length) / 2));
        Console.ResetColor();

        do
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if(key.Key == ConsoleKey.Enter)
            {
                back_button = true;
            }
        }while(back_button == false);
    }

    private static void LogoAndStatus(bool status)
    {
        string[] logo = new string[]
        {
                @" ___  ___           _        ______           _                  _____                          ",
                @" |  \/  |          (_)       | ___ \         (_)                /  ___|                         ",
                @" | .  . | _____   ___  ___   | |_/ /_____   ___  _____      __  \ `--.  ___ _ ____   _____ _ __ ",
                @" | |\/| |/ _ \ \ / / |/ _ \  |    // _ \ \ / / |/ _ \ \ /\ / /   `--. \/ _ \ '__\ \ / / _ \ '__|",
                @" | |  | | (_) \ V /| |  __/  | |\ \  __/\ V /| |  __/\ V  V /   /\__/ /  __/ |   \ V /  __/ |   ",
                @" \_|  |_/\___/ \_/ |_|\___|  \_| \_\___| \_/ |_|\___| \_/\_/    \____/ \___|_|    \_/ \___|_|  "
        };

        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (string logo_row in logo)
        {
            Console.WriteLine(logo_row.PadLeft((Console.WindowWidth + logo_row.Length) / 2));
        }
        Console.ResetColor();





        if(status == true)
        {
            Console.Write("                     Stato Server - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Online");
        }
        else{
            Console.Write("                     Stato Server - ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Offline");
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    public static void MainMenu(int option, bool status)
    {
        Console.Clear();
        LogoAndStatus(status);

        string first_option = status ? "Arresta Server" : "Avvia Server";

        string[] options = new string[]
        {
            first_option,
            "Info Sistema",
            "Info Progetto",
            "Esci"
        };

        int width = Console.WindowWidth;

        for (int i = 0; i < options.Length; i++)
        {
            if (i == option)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(options[i].PadLeft((width + options[i].Length) / 2));
            }
            else if (i == 1 && !status)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(options[i].PadLeft((width + options[i].Length) / 2));
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine(options[i].PadLeft((width + options[i].Length) / 2));
            }
        }

        Console.ResetColor();
    }
}