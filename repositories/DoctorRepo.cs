using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.models;

namespace HospitalApp.repositories
{
    public class DoctorRepo
    {
        private static DoctorRepo? _instance;
        private readonly List<Doctor> Doctors = [];
        private DoctorRepo()
        {
            Doctors = [];
        }
        public static DoctorRepo? Instance
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
            Doctors.Add(doctor);
        }
        private bool RemoveDoctor(string Document)
        {
            var toRemove = Doctors.FirstOrDefault(doctor => doctor.Document == Document);
            if (toRemove != null)
            {
                Doctors.Remove(toRemove);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}