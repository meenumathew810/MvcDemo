using MVCSampledb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSampledb.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            AdvancedSQlEntities DbContext = new AdvancedSQlEntities();
            DbContext.Employees.Add(employee);
            DbContext.SaveChanges();

            return View();
        }

        public ActionResult Details()
        {
            AdvancedSQlEntities DbContext = new AdvancedSQlEntities();

            return View(DbContext.Employees.ToList());

            
        }

        public ActionResult Display()
        {
            AdvancedSQlEntities DbContext = new AdvancedSQlEntities();

            return View(DbContext.Employees.ToList());
        }
      
        public ActionResult Edit(int Id)
       {
            AdvancedSQlEntities DbContext = new AdvancedSQlEntities();
            //Employee employee = DbContext.Employees.Where(c => c.EmpId == Id).FirstOrDefault();
            Employee employee = new Employee();
            employee = DbContext.Employees.Find(Id);

            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            AdvancedSQlEntities DbContext = new AdvancedSQlEntities();
            var emp=(from c in DbContext.Employees where c.EmpId == employee.EmpId select c).FirstOrDefault();
            emp.EmpName = employee.EmpName;
            DbContext.SaveChanges();
            return RedirectToAction("Details", "Employee");
        }
        
        public ActionResult Delete(int Id)
        {
            try
            {
                AdvancedSQlEntities DbContext = new AdvancedSQlEntities();
                // Employee employee = new Employee();

                // employee = DbContext.Employees.Find(Id);
                Employee employee = DbContext.Employees.Where(c => c.EmpId == Id).FirstOrDefault();
                DbContext.Employees.Remove(employee);
                DbContext.SaveChanges();
                return RedirectToAction("Details", "Employee");
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

    }
}