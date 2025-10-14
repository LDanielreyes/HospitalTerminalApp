using System;
using HospitalApp.models;
using HospitalApp.repositories;
using HospitalApp.ui.responses;

namespace HospitalApp.services
{
    public class PatientServices
    {
        public static readonly PatientRepo repo = PatientRepo.Instance;

        public static bool AddPatientToList()
        {
            try
            {
                Console.Clear();
                string? FirstName, LastName, Document, Email, Password, Tel, Address;
                byte Age;
                do
                {
                    Console.Write("First Name: ");
                    FirstName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(FirstName))
                    {
                        Messages.RequiredData();
                    }
                } while (string.IsNullOrWhiteSpace(FirstName));

                do
                {
                    Console.Write("Last Name: ");
                    LastName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(LastName))
                    {
                        Messages.RequiredData();
                    }
                } while (string.IsNullOrWhiteSpace(LastName));

                while (true)
                {
                    Console.Write("Age: ");
                    if (byte.TryParse(Console.ReadLine(), out Age))
                        break;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid age. Please enter a valid number.");
                        Console.ResetColor();
                    }
                }

                do
                {
                    Console.Write("Citizenship Card: ");
                    Document = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Document))
                    {
                        Messages.RequiredData();
                    }
                } while (string.IsNullOrWhiteSpace(Document));

                do
                {
                    Console.Write("Email: ");
                    Email = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(Email))
                    {
                        Messages.RequiredData();
                        continue;
                    }

                    if (!Email.EndsWith("@gmail.com"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid email. It must end with '@gmail.com'.");
                        Console.ResetColor();
                        Email = null;
                    }

                } while (string.IsNullOrWhiteSpace(Email));

                do
                {
                    Console.Write("Password: ");
                    Password = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Password))
                    {
                        Messages.RequiredData();
                    }
                } while (string.IsNullOrWhiteSpace(Password));

                Console.Write("Telephone: ");
                Tel = Console.ReadLine();

                Console.Write("Address: ");
                Address = Console.ReadLine();

                Patient NewPatient = new Patient(FirstName, LastName, Age, Document, Tel, Address, Email, Password);
                repo.AddPatient(NewPatient);

                Messages.SuccessfullyOperation();
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error adding patient: {ex.Message}");
                Console.ResetColor();
                return false;
            }
        }

        public static bool UpdatePatientInfo()
        {
            try
            {
                System.Console.Write("Write the Id of the patient: USER00");
                string? Id = Console.ReadLine();
                string? patientId = $"USER00{Id}";

                var patient = repo.GetPatients().FirstOrDefault(p => p.Id == patientId);
                if (patient == null)
                {
                    Messages.UserNotFound();
                    return false;
                }

                string? change;
                do
                {
                    Messages.UpdatePatientsMenu(patientId);
                    change = Console.ReadLine();

                    switch (change)
                    {
                        case "1":
                            System.Console.Write("First Name: ");
                            patient.FirstName = Console.ReadLine();
                            System.Console.Write("Last Name: ");
                            patient.LastName = Console.ReadLine();
                            break;
                        case "2":
                            System.Console.Write("Age: ");
                            if (byte.TryParse(Console.ReadLine(), out byte NewAge))
                                patient.Age = NewAge;
                            else
                                Console.WriteLine("Invalid age input.");
                            break;
                        case "3":
                            System.Console.Write("Citizenship Card: ");
                            patient.Document = Console.ReadLine();
                            break;
                        case "4":
                            System.Console.Write("Email: ");
                            patient.Email = Console.ReadLine();
                            break;
                        case "5":
                            System.Console.Write("Password: ");
                            patient.Password = Console.ReadLine();
                            break;
                        case "6":
                            System.Console.Write("Telephone: ");
                            patient.Tel = Console.ReadLine();
                            break;
                        case "7":
                            System.Console.Write("Address: ");
                            patient.Address = Console.ReadLine();
                            break;
                        default:
                            break;
                    }

                } while (change != "7");

                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error updating patient: {ex.Message}");
                Console.ResetColor();
                return false;
            }
        }

        public static bool DeletePatientTerminal()
        {
            try
            {
                Console.Clear();
                System.Console.Write("Write the Id of the patient: USER00");
                string? Id = Console.ReadLine();
                string? patientId = $"USER00{Id}";

                var patient = repo.GetPatients().FirstOrDefault(p => p.Id == patientId);
                if (patient == null)
                {
                    Messages.UserNotFound();
                    return false;
                }

                if (repo.DeletePatient(patientId))
                {
                    Messages.SuccessfullyOperation();
                    return true;
                }
                else
                {
                    Messages.UserNotFound();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error deleting patient: {ex.Message}");
                Console.ResetColor();
                return false;
            }
        }
        public static bool ShowPatients()
        {
            try
            {
                Console.Clear();
                System.Console.Write("Write the Id of the patient: USER00");
                string? Id = Console.ReadLine();
                string? patientId = $"USER00{Id}";

                var patient = repo.GetPatients().FirstOrDefault(patient => patient.Id == patientId);
                if (patient == null)
                {
                    Messages.UserNotFound();
                    return false;
                }

                Messages.DetailedPatientInfo(patientId);
                Messages.Continue();
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error searching patient: {ex.Message}");
                Console.ResetColor();
                return false;
            }
        }

        public static bool ShowAllPatients()
        {
            Console.Clear();
            var patients = repo.GetPatients();
            if (patients == null || patients.Count == 0)
            {
                System.Console.WriteLine("Patients list is empty");
                return false;
            }
            else
            {
                Messages.UserGeneralMenu();
                Messages.Continue();
                return true;
            }
        }
    }
}
