
using MovieReview.Data;

static class UserInterface
{
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
            Console.Write("                     Stato - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Online");
        }
        else{
            Console.Write("                     Stato - ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Offline");
        }
        Console.WriteLine();
        Console.ResetColor();
    }

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

    public static void MainMenu(int option, bool status)
    {
        Console.Clear();
        LogoAndStatus(status);

        string first_option = status ? "Arresta Server" : "Avvia Server";

        string[] options = new string[]
        {
            first_option,
            "Info Sistema",
            "Log Sistema",
            "Info Progetto",
            "Esci"
        };

        for (int i = 0; i < options.Length; i++)
        {
            if (i == option)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(options[i].PadLeft((Console.WindowWidth + options[i].Length) / 2));
            }
            else if ( (i == 1 || i == 2) && !status)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(options[i].PadLeft((Console.WindowWidth + options[i].Length) / 2));
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine(options[i].PadLeft((Console.WindowWidth + options[i].Length) / 2));
            }
        }

        Console.ResetColor();
    }

    public static void ServerInfo(bool status, MovieReviewDbContext db)
    {
        Console.Clear();
        LogoAndStatus(status);
        bool back_button = false;
        string n_users_text = $"Utenti Registrati: {Operation.GetUserCount(db)}";
        string n_film_text = $"Film: {Operation.GetFilmCount(db)}";
        string n_actors_text = $"Attori: {Operation.GetActorCount(db)}";
        string n_reviews_text = $"Totale Recensioni: {Operation.GetReviewCount(db)}";


        Console.WriteLine(n_users_text.PadLeft((Console.WindowWidth + n_users_text.Length) / 2));
        Console.WriteLine(n_film_text.PadLeft((Console.WindowWidth + n_film_text.Length) / 2));
        Console.WriteLine(n_actors_text.PadLeft((Console.WindowWidth + n_actors_text.Length) / 2));
        Console.WriteLine(n_reviews_text.PadLeft((Console.WindowWidth + n_reviews_text.Length) / 2));

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

    public static void LogList(bool status)
    {
        Console.Clear();
        LogoAndStatus(status);
        bool back_button = false;
        
        LogManager log_manager = LogManager.Instance;
        if(log_manager.LogNumber() == 0)
        {
            string no_logs_text = "Non ci sono log disponibili...\n";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(no_logs_text.PadLeft((Console.WindowWidth + no_logs_text.Length) / 2));
            Console.ResetColor();
            string text_separator = "==============================\n";
            Console.WriteLine(text_separator.PadLeft((Console.WindowWidth + text_separator.Length) / 2));
        }
        else
        {
            log_manager.GetLogs();
            Console.WriteLine();
        }

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

    public static void Error(bool status)
    {
        Console.Clear();
        LogoAndStatus(status);
        bool exit_button = false;
        string error_text = "Errore: verificare le credenziali di accesso al database o le impostazioni del server!";
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error_text.PadLeft((Console.WindowWidth + error_text.Length) / 2));
        Console.ResetColor();

        do
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if(key.Key == ConsoleKey.Enter)
            {
                exit_button = true;
            }
        }while(exit_button == false);
    }
}