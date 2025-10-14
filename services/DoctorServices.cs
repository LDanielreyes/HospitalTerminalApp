using System;
using System.Linq;
using HospitalApp.models;
using HospitalApp.repositories;
using HospitalApp.ui.responses;

namespace HospitalApp.services
{
    public class DoctorServices
    {
        public static readonly DoctorRepo repo = DoctorRepo.Instance;

        public static bool AddDoctorToList()
        {
            try
            {
                Console.Clear();
                string? FirstName, LastName, Document, Specialty;
                byte Age;

                do
                {
                    Console.Write("First Name: ");
                    FirstName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(FirstName))
                        Messages.RequiredData();
                } while (string.IsNullOrWhiteSpace(FirstName));

                do
                {
                    Console.Write("Last Name: ");
                    LastName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(LastName))
                        Messages.RequiredData();
                } while (string.IsNullOrWhiteSpace(LastName));

                while (true)
                {
                    Console.Write("Age: ");
                    if (byte.TryParse(Console.ReadLine(), out Age))
                        break;
                    else
                    {
                        Messages.RequiredData();
                    }
                }

                do
                {
                    Console.Write("Citizenship Card: ");
                    Document = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Document))
                        Messages.RequiredData();
                } while (string.IsNullOrWhiteSpace(Document));

                do
                {
                    Console.Write("Specialty: ");
                    Specialty = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(Specialty))
                        Messages.RequiredData();
                } while (string.IsNullOrWhiteSpace(Specialty));

                Doctor NewDoctor = new Doctor(FirstName, LastName, Age, Document, Specialty);
                repo.AddDoctor(NewDoctor);

                Messages.SuccessfullyOperation();
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error adding doctor: {ex.Message}");
                Console.ResetColor();
                return false;
            }
        }

        public static bool UpdateDoctorInfo()
        {
            try
            {
                System.Console.Write("Write the Id of the patient: USER00");
                string? patientId = Console.ReadLine();
                string? Id = $"USER00{patientId}";

                var doctor = repo.GetDoctors().FirstOrDefault(doctor => doctor.Id == Id);
                if (doctor == null)
                {
                    Messages.UserNotFound();
                    return false;
                }

                string? change;
                do
                {
                    DoctorMessages.UpdateDoctorsMenu(Id);
                    change = Console.ReadLine();

                    switch (change)
                    {
                        case "1":
                            System.Console.Write("First Name: ");
                            doctor.FirstName = Console.ReadLine();
                            System.Console.Write("Last Name: ");
                            doctor.LastName = Console.ReadLine();
                            break;
                        case "2":
                            System.Console.Write("Age: ");
                            if (byte.TryParse(Console.ReadLine(), out byte NewAge))
                                doctor.Age = NewAge;
                            else
                                Console.WriteLine("Invalid age input.");
                            break;
                        case "3":
                            System.Console.Write("Citizenship Card: ");
                            doctor.Document = Console.ReadLine();
                            break;
                        case "4":
                            System.Console.Write("Specialty: ");
                            doctor.Specialty = Console.ReadLine();
                            break;
                        default:
                            break;
                    }

                } while (change != "4");

                Messages.SuccessfullyOperation();
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error updating doctor: {ex.Message}");
                Console.ResetColor();
                return false;
            }
        }
        public static bool DeleteDoctorTerminal()
        {
            try
            {
                Console.Clear();
                System.Console.Write("Write the Id of the patient: USER00");
                string? patientId = Console.ReadLine();
                string? Id = $"USER00{patientId}";

                var doctor = repo.GetDoctors().FirstOrDefault(d => d.Id == Id);
                if (doctor == null)
                {
                    Messages.UserNotFound();
                    return false;
                }

                var removed = repo.GetDoctors().Remove(doctor);
                if (removed)
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
                Console.WriteLine($"Error deleting doctor: {ex.Message}");
                Console.ResetColor();
                return false;
            }
        }
        public static bool ShowDoctor()
        {
            try
            {
                Console.Clear();
                System.Console.Write("Write the Id of the patient: USER00");
                string? patientId = Console.ReadLine();
                string? Id = $"USER00{patientId}";

                var doctor = repo.GetDoctors().FirstOrDefault(doctor => doctor.Id == Id);
                if (doctor == null)
                {
                    Messages.UserNotFound();
                    return false;
                }

                DoctorMessages.DetailedDoctorInfo(Id);
                Messages.Continue();
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error searching doctor: {ex.Message}");
                Console.ResetColor();
                return false;
            }
        }
        public static bool ShowAllDoctors()
        {
            Console.Clear();
            var doctors = repo.GetDoctors();
            if (doctors == null || doctors.Count == 0)
            {
                System.Console.WriteLine("Doctors list is empty");
                return false;
            }
            else
            {
                DoctorMessages.DoctorGeneralMenu();
                Messages.Continue();
                return true;
            }
        }
    }
}
