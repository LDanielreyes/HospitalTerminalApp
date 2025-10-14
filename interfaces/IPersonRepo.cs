using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApp.models;

namespace HospitalApp.interfaces
{
public interface IPersonRepo<I> where I : Person
{
    void Add(I person);
    void ShowAll();
    I? Search(string document);
    void Delete(string document);
}

}