using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.ui.menus
{
    public class AdminMenu
    {
        public static void ShowAdminMenu()
        {
            string? option;
            do
            {
                System.Console.WriteLine(@"
.________________________________.
|/////////| Admin Menu |\\\\\\\\\|
|================================|
|1. Add Doctor                   |
|2. Show Doctors                 |
|3. Search Doctor                |
|4. Delete Doctor                |
|5. create Appointment		     |
|6. show Appointments            |
|7. Log out                      |
.--------------------------------.
");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        System.Console.WriteLine("Add Doctor");
                        break;
                    case "2":
                        System.Console.WriteLine("Show Doctors");
                        break;
                    case "3":
                        System.Console.WriteLine("Search Doctor");
                        break;
                    case "4":
                        System.Console.WriteLine("Delete Doctor");
                        break;
                    case "5":
                        System.Console.WriteLine("create Appointment");
                        break;
                    case "6":
                        System.Console.WriteLine("show Appointments");
                        break;
                    case "7":
                        System.Console.WriteLine("Log out"); 
                        break;
                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }
            }while (option != "7");
    }
    }
} 