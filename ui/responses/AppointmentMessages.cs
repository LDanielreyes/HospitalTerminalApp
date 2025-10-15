using System;

namespace HospitalApp.ui.responses
{
    public static class AppointmentMessages
    {
        public static void AppointmentCreated(string id)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAppointment {id} created successfully!");
            Console.ResetColor();
        }

        public static void AppointmentNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nAppointment not found. Please enter a valid ID.");
            Console.ResetColor();
        }

        public static void InvalidDate()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid date format. Use yyyy-MM-dd HH:mm.");
            Console.ResetColor();
        }

        public static void DateCollision()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Another appointment already exists at that date and time.");
            Console.ResetColor();
        }

        public static void InvalidState()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid state entered.");
            Console.ResetColor();
        }

        public static void StateUpdated(string newState)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Appointment state updated to '{newState}'.");
            Console.ResetColor();
        }

        public static void InvalidDiagnosis()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid diagnosis input.");
            Console.ResetColor();
        }

        public static void DiagnosisUpdated()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Diagnosis successfully updated.");
            Console.ResetColor();
        }

        public static void NoAppointments()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nNo appointments found for this patient.");
            Console.ResetColor();
        }

        public static void NoPendingAppointments()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThere are no pending appointments at the moment.");
            Console.ResetColor();
        }

        public static void AppointmentAssigned(string id, string doctorName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAppointment {id} has been successfully assigned to Dr. {doctorName}.");
            Console.ResetColor();
        }

        public static void GeneralError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError: {message}");
            Console.ResetColor();
        }
    }
}
