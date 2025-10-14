using System;
using System.Linq;
using HospitalApp.models;
using HospitalApp.repositories;
using HospitalApp.ui.responses;

namespace HospitalApp.services
{
    public class AppointmentServices
    {
        private static readonly AppointmentRepo repo = AppointmentRepo.Instance;

        public static bool CreateAppointment()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== CREATE NEW APPOINTMENT ===");
                Console.ResetColor();

                Console.Write("Patient Document: ");
                string? doc = Console.ReadLine();

                Console.Write("Patient Name: ");
                string? patientName = Console.ReadLine();

                Console.Write("Doctor Name: ");
                string? doctorName = Console.ReadLine();

                Console.Write("Doctor Specialty: ");
                string? specialty = Console.ReadLine();

                Console.Write("Symptoms: ");
                string? symptoms = Console.ReadLine();

                Console.Write("Date and Time (yyyy-MM-dd HH:mm): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    AppointmentMessages.InvalidDate();
                    return false;
                }

                if (repo.GetAppointments().Any(a => a.Date == date))
                {
                    AppointmentMessages.DateCollision();
                    return false;
                }

                Appointment newAppointment = new Appointment(
                    Symptoms: symptoms ?? "N/A",
                    Diagnosis: "Pending Diagnosis",
                    State: "Pending",
                    Date: date,
                    DocumentPatient: doc ?? "Unknown",
                    NamePatient: patientName ?? "Unknown",
                    NameDoctor: doctorName ?? "Unknown",
                    Specialty: specialty ?? "General"
                );

                repo.AddAppointment(newAppointment);
                AppointmentMessages.AppointmentCreated(newAppointment.Id!);
                return true;
            }
            catch (Exception ex)
            {
                AppointmentMessages.GeneralError(ex.Message);
                return false;
            }
        }

        public static void UpdateAppointmentState(string appointmentId)
        {
            var appointment = repo.GetAppointments().FirstOrDefault(a => a.Id == appointmentId);

            if (appointment == null)
            {
                AppointmentMessages.AppointmentNotFound();
                return;
            }

            Console.WriteLine($"\nCurrent State: {appointment.State}");
            Console.WriteLine("Available states: Pending, In Progress, Completed, Canceled");
            Console.Write("Enter new state: ");
            string? newState = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newState))
            {
                AppointmentMessages.InvalidState();
                return;
            }

            appointment.State = newState;
            AppointmentMessages.StateUpdated(newState);
        }
        public static void UpdateDiagnosis(string appointmentId)
        {
            var appointment = repo.GetAppointments().FirstOrDefault(a => a.Id == appointmentId);

            if (appointment == null)
            {
                AppointmentMessages.AppointmentNotFound();
                return;
            }

            Console.WriteLine($"\nCurrent Diagnosis: {appointment.Diagnosis}");
            Console.Write("Enter new diagnosis: ");
            string? diagnosis = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(diagnosis))
            {
                AppointmentMessages.InvalidDiagnosis();
                return;
            }

            appointment.Diagnosis = diagnosis;
            AppointmentMessages.DiagnosisUpdated();
        }
        public static void ShowAllAppointments()
        {
            var appointments = repo.GetAppointments();

            if (!appointments.Any())
            {
                AppointmentMessages.NoAppointments();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=== APPOINTMENT LIST ===");
            Console.ResetColor();

            foreach (var a in appointments)
            {
                Console.WriteLine($@"
-----------------------------------
ID: {a.Id}
Patient: {a.NamePatient} ({a.DocumentPatient})
Doctor: {a.NameDoctor} - {a.Specialty}
Date: {a.Date}
State: {a.State}
Diagnosis: {a.Diagnosis}
Symptoms: {a.Symptoms}
-----------------------------------");
            }
        }
    }
}
