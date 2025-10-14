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
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Patient(

        string FirstName,
        string LastName,
        byte Age,
        string Document,
        string Tel,
        string Address,
        string Email,
        string Password)

        : base(FirstName, LastName, Age, Document)
        {
            this.Tel = Tel;
            this.Address = Address;
            this.Email = Email;
            this.Password = Password;
        }
    }
}