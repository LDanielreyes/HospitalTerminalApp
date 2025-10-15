using System;
using System.Collections.Generic;
using System.Linq;
using HospitalApp.models;
using HospitalApp.repositories.interfaces;

namespace HospitalApp.repositories
{
    public class PatientRepo : IPatientRepo
    {
        private static PatientRepo? _instance;
        private List<Patient> Patients { get; set; }

        private PatientRepo()
        {
            Patients = new List<Patient>();
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
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            Patients.Add(patient);
        }

        public Patient? GetPatientByDocument(string document)
        {
            return Patients.FirstOrDefault(p => p.Document == document);
        }

        public void UpdatePatient(Patient patient)
        {
            var existing = GetPatientByDocument(patient.Document);
            if (existing != null)
            {
                var index = Patients.IndexOf(existing);
                Patients[index] = patient;
            }
        }

        public void DeletePatient(string document)
        {
            var toDelete = GetPatientByDocument(document);
            if (toDelete != null)
                Patients.Remove(toDelete);
        }
    }
}
