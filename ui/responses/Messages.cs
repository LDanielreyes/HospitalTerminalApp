using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.repositories;

namespace HospitalApp.ui.responses
{
   public class Messages
    {
        private static readonly PatientRepo patientRepo = PatientRepo.Instance;
        private static readonly DoctorRepo doctorRepo = DoctorRepo.Instance;
        private static readonly AppointmentRepo appointmentRepo = AppointmentRepo.Instance;

        public static void UserNotFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
._________________________________.
|                                 |
|         user not found.         |   
|_________________________________|
        ");
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void RequiredData()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine(@"
._________________________________.
|                                 |
|          required date          |   
|_________________________________|
          ");
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void SuccessfullyOperation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(@"
._________________________________.
|                                 |
|     Successfully Operation.     |   
|_________________________________|
          ");
            Console.ResetColor();
            Console.ReadLine();
        }
        public static void DetailedPatientInfo(string patientId)
        {
            var patient = patientRepo.GetPatients().FirstOrDefault(patient => patient.Id == patientId);
            System.Console.WriteLine($@"
._________________________________.
|                                 |
    ID: {patient.Id}
    Name: {patient.FirstName} {patient.LastName}        
    Age: {patient.Age}
    Citizenship Card: {patient.Document}
    Password: {patient.Password}
    Telephone: {patient.Tel}
    Address: {patient.Address}
|_________________________________|");
        }
        public static void UpdatePatientsMenu(string PatientId)
        {
            var patient = patientRepo.GetPatients().FirstOrDefault(patient => patient.Id == PatientId);
            System.Console.WriteLine($@"
._________________________________.
|                                 |

    ID: {patient.Id}
    Name: {patient.FirstName} {patient.LastName}        
    Age: {patient.Age}
    Citizenship Card: {patient.Document}
    Email: {patient.Email}
    Password: {patient.Password}
    Telephone: {patient.Tel}
    Address: {patient.Address}

-----------------------------------
    1.Name
    2.Age
    3.Citizenship Card
    4.Email
    5.Password
    6.Telephone
    7.Address
    8.Exit  
|_________________________________|
What information do you want to change?
            ");
        }
        public static void UserGeneralMenu()
        {

            foreach (var patient in patientRepo.GetPatients())
            {
                System.Console.WriteLine($@"
._________________________________.
|                                 |
|   ID: {patient.Id}
|   Name: {patient.FirstName} {patient.LastName}
|   Age: {patient.Age}
|_________________________________|");
            }
        }
        public static void Continue()
        {
            System.Console.WriteLine("Press enter to Continue");
            Console.ReadLine();
        }
    }
}