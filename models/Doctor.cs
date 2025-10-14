using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace HospitalApp.models
{
    public class Doctor: Person
    {
        public string? Specialty { get; set; }
        public Doctor(

        string Id,
        string FirstName,
        string LastName,
        byte Age,
        string Document,
        string Specialty)
        : base(Id, FirstName, LastName, Age, Document)
        {
          this.Specialty = Specialty;  
        }
    }
}