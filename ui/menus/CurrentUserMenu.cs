using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.services;
using HospitalApp.ui.responses;

namespace HospitalApp.ui.menus
{
    public class CurrentUserMenu
    {
        public static void ShowCurrentUserMenu()
        {

            string? option;
            do
            {
                System.Console.WriteLine(@"
.________________________________.
|/////////| User Menu |\\\\\\\\\\|
|================================|
|1. Update my info               |
|2. create Appointment		     |
|3. show my Appointments         |
|4. Log out                      |
.--------------------------------.
            ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        CurrentUserServices.UpdateCurrentUser();
                        break;
                    case "2":
                        AppointmentServices.CreateAppointment();
                        break;
                    case "3":
                        CurrentUserServices.ViewMyAppointments();
                        break;
                    case "4":
                        System.Console.WriteLine("Log out");
                        Messages.Continue();
                        MainMenu.ShowMainMenu();
                        break;
                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }
            } while (option != "4");
        }
    }
}