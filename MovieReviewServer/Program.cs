using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MovieReview.Data;
using MovieReview.Services;

class Program
{
    const int CHOICE_LIMIT = 4;

    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        WebApplication app;

        bool server_status = false;
        bool confirm_choice = false;
        bool exit = false;
        int choice = 0;

        //Check iniziale se il server è avviabile
        try
        {
            app = Server.Start(args);
            Server.Stop(app);
        }
        catch (Exception)
        {
            UserInterface.Error(server_status);
            return;
        }
        

        //Menù di navigazione
        do
        {
            UserInterface.MainMenu(choice, server_status);
            while (confirm_choice == false)
            {
                ConsoleKeyInfo tasto = Console.ReadKey(true);

                switch (tasto.Key)
                {
                    case ConsoleKey.DownArrow:
                        if(choice + 1 <= CHOICE_LIMIT)
                        {
                            if(server_status == false && choice == 0)
                            {
                                choice = choice + 3;
                            }
                            else
                            {
                                choice++;
                            }
                            UserInterface.MainMenu(choice, server_status);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if( (choice - 1) >= 0)
                        {
                            if(server_status == false && choice == 3)
                            {
                                choice = choice - 3;
                            }
                            else
                            {
                                choice--;
                            }
                            UserInterface.MainMenu(choice, server_status);
                        }
                        break;
                    case ConsoleKey.Enter:
                        confirm_choice = true;
                        break;
                }
            }







            //Controllo la scelta post conferma
            switch (choice)
            {
                case 0: //Caso avvia o arresta server
                    try
                    {
                        if(server_status == false)
                        {
                            app = Server.Start(args);
                            server_status = true;
                        }
                        else
                        {
                            Server.Stop(app);
                            LogManager.Instance.ClearLogs();
                            server_status = false;
                        }
                    }
                    catch (Exception)
                    {
                        server_status = false;
                        exit = true;
                        UserInterface.Error(server_status);
                    }

                    confirm_choice = false;
                    break;

                case 1: //caso info sistema
                    using (var scope = app.Services.CreateScope())
                    {
                        var tempDb = scope.ServiceProvider.GetRequiredService<MovieReviewDbContext>();
                        UserInterface.ServerInfo(server_status, tempDb);
                    }
                    confirm_choice = false;
                    break;

                case 2: //caso log sistema
                    UserInterface.LogList(server_status);
                    confirm_choice = false;
                    break;

                case 3: //caso info progetto
                    UserInterface.ProjectInfo(server_status);
                    confirm_choice = false;
                    break;
                case 4:  //caso esci
                    exit = true;
                    break;
            }
        }while(exit == false);
    }
}