using System;

class Program
{
    const int CHOICE_LIMIT = 3;

    public static void Main()
    {
        Console.CursorVisible = false;
        /* OK
            Models: Utente, Film, Attore, Recensione mappati
        */

        /* OK
        [TITOLO] - Server status: ONLINE in verde oppure OFFLINE in rosso a seconda se avviato o no
        - Avvia Server che diventerà Arresta Server quando avviato
        - Info Sistema (oscurato e non selezionabile se il server non e' avviato)
        - Info Progetto
        - Esci
        */




        bool server_status = false;
    
        

        bool confirm_choice = false;
        bool exit = false;
        int choice = 0;



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
                                choice = choice + 2;
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
                            if(server_status == false && choice == 2)
                            {
                                choice = choice - 2;
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

            switch (choice)
            {
                case 0:

                    confirm_choice = false;
                    break;
                case 1:

                    confirm_choice = false;
                    break;
                case 2:
                    UserInterface.ProjectInfo(server_status);
                    confirm_choice = false;
                    break;
                case 3:
                    exit = true;
                    break;
                
            }
        }while(exit == false);







    }
}