using HRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRS.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Employee> GetById(int id);
        string insert (Employee obj);
        string update(Employee obj);
        string delete(Employee obj);
        string savechanges();


    }
}
