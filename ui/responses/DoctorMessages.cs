using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.repositories;

namespace HospitalApp.ui.responses
{
    public class DoctorMessages
    {
        private static readonly DoctorRepo doctorRepo = DoctorRepo.Instance;
        public static void DetailedDoctorInfo(string Id)
        {
            var doctor = doctorRepo.GetDoctors().FirstOrDefault(doctor => doctor.Id == Id);
            System.Console.WriteLine($@"
._________________________________.
|                                 |
    ID: {doctor.Id}
    Name: {doctor.FirstName} {doctor.LastName}        
    Age: {doctor.Age}
    Citizenship Card: {doctor.Document}
    Specialty: {doctor.Specialty}
|_________________________________|");
        }
        public static void UpdateDoctorsMenu(string Id)
        {
            var doctorRepo = DoctorRepo.Instance;
            var doctor = doctorRepo.GetDoctors().FirstOrDefault(doctor => doctor.Id == Id);

            if (doctor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor not found.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($@"
._________________________________.
|                                 |

    ID: {doctor.Id}
    Name: {doctor.FirstName} {doctor.LastName}        
    Age: {doctor.Age}
    Citizenship Card: {doctor.Document}
    Specialty: {doctor.Specialty}

-----------------------------------
    1. Name
    2. Age
    3. Citizenship Card
    4. Specialty
    5. Exit
|_________________________________|
What information do you want to change?
        ");
            Console.ResetColor();
        }
        public static void DoctorGeneralMenu()
        {

            foreach (var doctor in doctorRepo.GetDoctors())
            {
                System.Console.WriteLine($@"
._________________________________.
|                                 |
|   ID: {doctor.Id}
|   Name: {doctor.FirstName} {doctor.LastName}
|   Specialty: {doctor.Specialty}
|_________________________________|");
            }
        }
    }
}