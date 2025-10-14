using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.ui.menus
{
    public class DoctorMenu
    {
        public static void ShowDoctorMenu()
        {
            string? option;
            do
            {
                System.Console.WriteLine(@"
.________________________________.
|////////| Doctor  Menu |\\\\\\\\|
|================================|
|1. Take Appointment             |
|2. create Appointment		     |
|3. show my Appointments         |
|4. Log out                      |
.--------------------------------.
            ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
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
                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }

            } while (option != "4");
        }
    }
}