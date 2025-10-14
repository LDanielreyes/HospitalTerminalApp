using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.models;

namespace HospitalApp.interfaces
{
    public interface IDoctorRepo
    {
        void CreateAppointment(Appointment appointment);
        void UpdateAppointment(string appointmentId, string newState);
    }
}
