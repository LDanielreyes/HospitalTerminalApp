using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.models;
using HospitalApp.repositories.interfaces;

namespace HospitalApp.repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private static AppointmentRepo? _instance;
        private List<Appointment> Appointments { get; set; }

        private AppointmentRepo()
        {
            Appointments = [];
        }
        public static AppointmentRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppointmentRepo();
                }
                return _instance;
            }
        }
        public List<Appointment> GetAppointments() => Appointments;
        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }
        public bool RemoveAppointment(string? Id)
        {
            var toRemove = Appointments.FirstOrDefault(appointment => appointment.Id == Id);
            if (toRemove != null)
            {
                Appointments.Remove(toRemove);
                return true;
            }
            return false;
        }
    }
}