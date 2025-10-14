using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.models;

namespace HospitalApp.interfaces
{
public interface ICurrentUserRepo
{
    void CreateAppointment(Appointment appointment);
    void UpdateInfo(Patient currentPatient);
    void ShowMyAppointments(string patientDocument);
}

}