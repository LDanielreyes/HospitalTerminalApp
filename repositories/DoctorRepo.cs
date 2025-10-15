using System;
using System.Collections.Generic;
using System.Linq;
using HospitalApp.models;
using HospitalApp.repositories.interfaces;

namespace HospitalApp.repositories
{
    public class DoctorRepo : IDoctorRepo
    {
        private static DoctorRepo? _instance;
        private List<Doctor> Doctors { get; set; }

        private DoctorRepo()
        {
            Doctors = new List<Doctor>
            {
                new Doctor("Juan", "Pérez", 45, "100100100", "Cardiology"),
                new Doctor("María", "Gómez", 38, "200200200", "Pediatrics"),
                new Doctor("Carlos", "Ramírez", 50, "300300300", "General Surgery"),
                new Doctor("Laura", "Santos", 33, "400400400", "Dermatology"),
                new Doctor("Andrés", "Lozano", 41, "500500500", "Neurology")
            };
        }

        public static DoctorRepo Instance
        {
            get
            {
                _instance ??= new DoctorRepo();
                return _instance;
            }
        }

        public List<Doctor> GetDoctors() => Doctors;

        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null) throw new ArgumentNullException(nameof(doctor));
            Doctors.Add(doctor);
        }

        public Doctor? GetDoctorByDocument(string document)
        {
            return Doctors.FirstOrDefault(d => d.Document == document);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            var existing = GetDoctorByDocument(doctor.Document);
            if (existing != null)
            {
                var index = Doctors.IndexOf(existing);
                Doctors[index] = doctor;
            }
        }

        public void DeleteDoctor(string document)
        {
            var toDelete = GetDoctorByDocument(document);
            if (toDelete != null)
                Doctors.Remove(toDelete);
        }
    }
}
