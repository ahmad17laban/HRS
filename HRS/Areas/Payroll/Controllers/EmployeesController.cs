using HRS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using HRS.Models;

namespace HRS.Areas.Payroll.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        public IActionResult Index()
        {
            dynamic expObj = new ExpandoObject();
            expObj.employeelist = _employeeService.GetEmployees();
            return View(expObj);
        }

        public IActionResult _list()
        {
            return PartialView();
        }

        public IActionResult Edit(int id)
        {

            dynamic expObj = new ExpandoObject();
            expObj.employeeDetail = _employeeService.GetById(id);
            return View(expObj);
        }
        public IActionResult Save(Employee postedData)
        {
            string err = "";
            if (postedData.EmpId > 0)
            {
                err = _employeeService.update(postedData);
                if (string.IsNullOrEmpty(err))
                {
                    _employeeService.savechanges();
                }
                
                
            }
            else
            {
                err = _employeeService.insert(postedData);
                if (string.IsNullOrEmpty(err))
                {
                    _employeeService.savechanges();
                }

            }

            return Json(new { err=err });
        }
    }
}
