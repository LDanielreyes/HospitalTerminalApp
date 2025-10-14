using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.models
{
    public class Appointment
    {
        private static int nextId = 1;
        public string? Id { get; set; }
        public string? Symptoms { get; set; }
        public string? Diagnosis { get; set; }
        public string? State { get; set; }
        public DateTime Date { get; set; }
        public string? DocumentPatient { get; set; }
        public string? NamePatient { get; set; }
        public string? NameDoctor { get; set; }
        public string? Specialty { get; set; }
        public Appointment(
        string Symptoms, 
        string Diagnosis, 
        string State, DateTime Date, 
        string DocumentPatient, 
        string NamePatient, 
        string NameDoctor, 
        string Specialty)
        {
            
            Id = $"APT00{nextId++}";
            this.Symptoms = Symptoms;
            this.Diagnosis = Diagnosis;
            this.State = State;
            this.Date = Date;
            this.DocumentPatient = DocumentPatient;
            this.NamePatient = NamePatient;
            this.NameDoctor = NameDoctor;
            this.Specialty = Specialty;
        }

    }
}