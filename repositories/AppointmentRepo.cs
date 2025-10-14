using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.models;

namespace HospitalApp.repositories
{
    public class AppointmentRepo
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
    }
}