using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApp.models
{
    public class Person
    {
        private static int nextId = 1;
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte Age { get; set; }
        public string? Document { get; set; }

        public Person(string Id, string FirstName, string LastName, byte Age, string Document)
        {
            Id = $"USER00{nextId++}";
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Document = Document;
        }
    }
}