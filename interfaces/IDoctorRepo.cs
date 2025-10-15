using System.Collections.Generic;
using HospitalApp.models;

namespace HospitalApp.repositories.interfaces
{
    public interface IDoctorRepo
    {
        void AddDoctor(Doctor doctor);
        List<Doctor> GetDoctors();
        Doctor? GetDoctorByDocument(string document);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(string document);
    }
}
