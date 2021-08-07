using HRS.Interfaces;
using HRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private HRSContext _context;
        private DbSet<Employee> table;
        public EmployeeService()
        {
            _context = new HRSContext();
            table = _context.Set<Employee>();
        }

        

        public IEnumerable<Employee> GetById(int id)
        {
            return (IEnumerable<Employee>)table.Find(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return table.ToList();
        }
        public string delete(Employee obj)
        {
            throw new NotImplementedException();
        }

        public string insert(Employee obj)
        {
            try
            {
                table.Add(obj);
                
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

            return "";
        }

       

        public string update(Employee obj)
        {
            try
            {
                table.Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

            return "";
        }
        public string savechanges()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

            return "";
        }
    }
}
