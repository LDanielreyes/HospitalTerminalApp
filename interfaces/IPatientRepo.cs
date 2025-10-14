using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.models;

namespace HospitalApp.interfaces
{
public interface IPatientRepo : IPersonRepo<Patient>
{
    void UpdateContactInfo(string document, string newAddress, string newTel);
}

}