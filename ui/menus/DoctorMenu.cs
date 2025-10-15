using System;
using HospitalApp.services;

namespace HospitalApp.ui.menus
{
    public class DoctorMenu
    {
        public static void ShowDoctorMenu(string doctorDocument)
        {
            string? option;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"
.________________________________.
|////////| Doctor Menu |\\\\\\\\\|
|================================|
| 1. Take Appointment            |
| 2. Create Appointment          |
| 3. Show All Appointments       |
| 4. Log out                     |
.--------------------------------.
");
                Console.ResetColor();
                Console.Write("Select an option: ");
                option = Console.ReadLine();

                Console.Clear();

                switch (option)
                {
                    case "1":
                        AppointmentServices.TakeAppointment(doctorDocument);
                        break;

                    case "2":
                        AppointmentServices.CreateAppointment();
                        break;

                    case "3":
                        AppointmentServices.ShowAllAppointments();
                        break;

                    case "4":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Logging out...");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ResetColor();
                        break;
                }

                if (option != "4")
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }

            } while (option != "4");
        }
    }
}
