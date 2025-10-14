using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.models
{
    public class Patient:Person
    {
        public string? Tel { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public Patient(

        string Id,
        string FirstName,
        string LastName,
        byte Age,
        string Document,
        string Tel,
        string Address,
        string Password)

        : base(Id, FirstName, LastName, Age, Document)
        {
            this.Tel = Tel;
            this.Address = Address;
            this.Password = Password;
        }
    }
}