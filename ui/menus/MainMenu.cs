using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.services;

namespace HospitalApp.ui.menus
{
    public class MainMenu
    {
        public static void ShowMainMenu()
        {
                        System.Console.WriteLine(@"
.________________________________.
|/////////| Main Menu |\\\\\\\\\\|
|================================|
|1. Log in                       |
|2. Register                     |
|3. Exit                         |
.--------------------------------.
            ");
            string? option;
            do
            {
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        CurrentUserServices.Login();
                        break;
                    case "2":
                        PatientServices.AddPatientToList();
                        break;
                    case "3":
                        System.Console.WriteLine("Exit");
                        break;
                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }
            } while (option != "3");
        }
    }
}