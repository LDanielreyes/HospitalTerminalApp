using System.Collections.Generic;
using HospitalApp.models;

namespace HospitalApp.repositories.interfaces
{
    public interface IPatientRepo
    {
        void AddPatient(Patient patient);
        List<Patient> GetPatients();
        Patient? GetPatientByDocument(string document);
        void UpdatePatient(Patient patient);
        void DeletePatient(string document);
    }
}
