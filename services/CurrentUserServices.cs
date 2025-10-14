using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.models;
using HospitalApp.repositories;
using HospitalApp.ui.menus;
using HospitalApp.ui.responses;

namespace HospitalApp.services
{
    public class CurrentUserServices
    {
        private static readonly PatientRepo repo = PatientRepo.Instance;
        public static void Login()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("");
                Console.Write("Citizenship Card: ");
                string? document = Console.ReadLine();

                if (document == "987654321")
                {
                    AdminMenu.ShowAdminMenu();
                    return;
                }

                Console.Write("Password: ");
                string? password = Console.ReadLine();

                var currentUser = repo.GetPatients().FirstOrDefault(patient =>
                    patient.Document == document && patient.Password == password);

                if (currentUser == null)
                {
                    Messages.UserNotFound();
                    return;
                }

                CurrentUserMenu.ShowCurrentUserMenu();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error during login: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}