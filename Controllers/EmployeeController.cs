using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Project2PHE.Services;
using Project2PHE.DTOs.Employee;
using Project2PHE.Repositories;
using Project2PHE.Contexts;
using Project2PHE.Models;

namespace Project2PHE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeServices _employeeServices;

        public EmployeeController()
        {
            _employeeServices = new EmployeeServices(new EmployeeRepository(new RegisterDbContext()));
        }

        // GET: Employee
        public ActionResult Index()
        {
            var employeeDtos = _employeeServices.GetAllEmployee();
            var employees = employeeDtos.Select(dto => (Employee)dto).ToList();
            return View(employees);
        }


        // GET: Employee/Details/5
        public ActionResult Details(string id)
        {
            var employee = _employeeServices.GetEmployeeByGuid(id);
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(NewEmployeeDTO employeeDto)
        {
            try
            {
                _employeeServices.CreateEmployee(employeeDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            var employee = _employeeServices.GetEmployeeByGuid(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, EmployeeDTO employeeDto)
        {
            try
            {
                _employeeServices.UpdateEmployee(employeeDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(string id)
        {
            var employee = _employeeServices.GetEmployeeByGuid(id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                _employeeServices.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
