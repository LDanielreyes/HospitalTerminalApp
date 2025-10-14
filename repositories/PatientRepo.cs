using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.models;

namespace HospitalApp.repositories
{
    public class PatientRepo
{
        private static PatientRepo? _instance;
        private List<Patient> Patients { get; set; }

        private PatientRepo()
        {
            Patients = [];
        }

        public static PatientRepo Instance
        {
            get
            {
                _instance ??= new PatientRepo();

                return _instance;
            }
        }

        public List<Patient> GetPatients() => Patients;

        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
        }

        public bool DeletePatient(string Document)
        {
            var toDelete = Patients.FirstOrDefault(patient => patient.Document == Document);
            if (toDelete != null)
            {
                Patients.Remove(toDelete);
                return true;
            }
            return false;
        }

    }
}