using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.services;

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
                        DoctorServices.AddDoctorToList();
                        break;
                    case "2":
                        DoctorServices.ShowAllDoctors();
                        break;
                    case "3":
                        DoctorServices.ShowDoctor();
                        break;
                    case "4":
                        DoctorServices.DeleteDoctorTerminal();
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