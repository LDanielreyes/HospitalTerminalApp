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
|7. delete patient               |
|8. update patient               |
|9. Log out                      |
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
                        AppointmentServices.CreateAppointment();
                        break;
                    case "6":
                        AppointmentServices.ShowAllAppointments();
                        break;
                    case "7":
                        PatientServices.DeletePatientTerminal();
                        break;
                    case "8":
                        Console.Clear();
                        System.Console.Write("Write the Id of the patient: USER00");
                        string? Id = Console.ReadLine();
                        string? patientId = $"USER00{Id}";
                        PatientServices.UpdatePatientInfo(patientId);
                        break;
                    case "9":
                        System.Console.WriteLine("Log out");
                        MainMenu.ShowMainMenu();
                        break;
                    default:
                        System.Console.WriteLine("Invalid option");
                        break;
                }
            }while (option != "9");
    }
    }
} 