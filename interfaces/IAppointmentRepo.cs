using System.Collections.Generic;
using HospitalApp.models;

namespace HospitalApp.repositories.interfaces
{
    public interface IAppointmentRepo
    {
        List<Appointment> GetAppointments();
        void AddAppointment(Appointment appointment);
        bool RemoveAppointment(string? id);
    }
}
