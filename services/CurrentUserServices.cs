using System;
using System.Linq;
using HospitalApp.models;
using HospitalApp.repositories;
using HospitalApp.ui.menus;
using HospitalApp.ui.responses;

namespace HospitalApp.services
{
    public class CurrentUserServices
    {
        private static readonly PatientRepo repo = PatientRepo.Instance;
        private static readonly DoctorRepo doctorRepo = DoctorRepo.Instance;
        private static Patient? currentUser;

        public static void Login()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("LOG IN");
                Console.Write("Citizenship Card: ");
                string? document = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(document))
                {
                    Messages.UserNotFound();
                    return;
                }

                // Admin hardcoded (como ya tenías)
                if (document == "987654321")
                {
                    AdminMenu.ShowAdminMenu();
                    return;
                }

                Console.Write("Password: ");
                string? password = Console.ReadLine();

                // 1) Buscar si es doctor por documento
                var foundDoctor = doctorRepo.GetDoctors().FirstOrDefault(d => d.Document == document);
                if (foundDoctor != null)
                {
                    DoctorMenu.ShowDoctorMenu(foundDoctor.Document!);
                    return;
                }

                // 2) Si no es doctor, buscar paciente
                var foundUser = repo.GetPatients().FirstOrDefault(patient =>
                    patient.Document == document && patient.Password == password);

                if (foundUser == null)
                {
                    Messages.UserNotFound();
                    return;
                }

                currentUser = foundUser;
                CurrentUserMenu.ShowCurrentUserMenu();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error during login: {ex.Message}");
                Console.ResetColor();
            }
        }

        public static string? GetCurrentUserId()
        {
            return currentUser?.Id;
        }

        public static void UpdateCurrentUser()
        {
            string? patientId = GetCurrentUserId();
            PatientServices.UpdatePatientInfo(patientId);
        }

        public static void ViewMyAppointments()
        {
            try
            {
                if (currentUser == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must be logged in to view your appointments.");
                    Console.ResetColor();
                    return;
                }

                var appointmentRepo = AppointmentRepo.Instance;
                var myAppointments = appointmentRepo
                    .GetAppointments()
                    .Where(appointment => appointment.DocumentPatient == currentUser.Document)
                    .ToList();

                if (!myAppointments.Any())
                {
                    AppointmentMessages.NoAppointments();
                    return;
                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n=== APPOINTMENTS FOR {currentUser.FirstName} {currentUser.LastName} ===\n");
                Console.ResetColor();

                foreach (var appointment in myAppointments)
                {
                    Console.WriteLine($@"
----------------------------------------
ID: {appointment.Id}
Doctor: {appointment.NameDoctor} ({appointment.Specialty})
Date: {appointment.Date}
State: {appointment.State}
Diagnosis: {appointment.Diagnosis}
Symptoms: {appointment.Symptoms}
----------------------------------------");
                }
            }
            catch (Exception ex)
            {
                AppointmentMessages.GeneralError(ex.Message);
            }
        }
    }
}
