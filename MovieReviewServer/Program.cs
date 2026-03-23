using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MovieReview.Data;

class Program
{
    const int CHOICE_LIMIT = 4;

    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        WebApplication app = null!;
        /* OK
            Models: Utente, Film, Attore, Recensione mappati
        */

        /* OK
        [TITOLO] - Server status: ONLINE in verde oppure OFFLINE in rosso a seconda se avviato o no
        - Avvia Server che diventerà Arresta Server quando avviato
        - Info Sistema (oscurato e non selezionabile se il server non e' avviato)
        - Log Sistema (oscurato e non selezionabile se il server non e' avviato)
        - Info Progetto
        - Esci
        */

        /*
            Info sistema: Utenti Registrati, Numero Film nel db, Numero attori nel db, Numero totale recensioni     OK
            Log Sistema: singleton OK, !!fare instance add log nei controller!!
        */
        /*
            Implementare i Controller e le Operation
        */


        bool server_status = false;
        bool confirm_choice = false;
        bool exit = false;
        int choice = 0;

        //NAVIGAZIONE MENU
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







            //CONTROLLO LA SCELTA 
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
                            server_status = false;
                        }
                    }
                    catch(Exception ex)
                    {
                        server_status = false;
                        Console.WriteLine(ex.Message);
                        Console.ReadKey();
                        //gestione errore avvio/arresto
                    }

                    confirm_choice = false;
                    break;

                case 1: //caso info sistema
                    //apre e chiude 
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