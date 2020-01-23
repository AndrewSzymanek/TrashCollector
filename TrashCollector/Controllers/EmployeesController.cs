using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            Employee employeeLoggedIn = db.Employees.Where(c => c.ApplicationId == userId).SingleOrDefault();
            return View(employeeLoggedIn);
        }
        public ActionResult CustomersIndex()
        {
            DayOfWeek todayDay = DateTime.Today.DayOfWeek;
            string userId = User.Identity.GetUserId();
            Employee employeeInDb = db.Employees.Where(e => e.ApplicationId == userId).Single();
            List<Customer> customersInZip = db.Customers.Where(c => c.zipCode == employeeInDb.zipCode).ToList();
            List<Customer> customersInZipOnDay = customersInZip.Where(c => c.pickupDay == todayDay.ToString()).ToList();
            return View("CustomersIndex", customersInZipOnDay);
        }

        public ActionResult DayIndex(string day)
        {
            string userId = User.Identity.GetUserId();
            Employee employeeInDb = db.Employees.Where(e => e.ApplicationId == userId).Single();
            List<Customer> customersInZip = db.Customers.Where(c => c.zipCode == employeeInDb.zipCode).ToList();
            List<Customer> customersInZipOnDay = customersInZip.Where(c => c.pickupDay == day).ToList();
            return View("DayIndex", customersInZipOnDay);
        }

        public ActionResult UpdateBalance()
        {
            

            return View();
        }
      

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View("Details", employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var employeeLoggedIn = User.Identity.GetUserId();
                employee.ApplicationId = employeeLoggedIn;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", "Employees", employee.id);
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            var customerToEdit = db.Customers.Where(c => c.id == id).SingleOrDefault();
            return View(customerToEdit);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            var customerToEdit = db.Customers.Where(c => c.id == id).SingleOrDefault();
            customerToEdit.isCompleted = customer.isCompleted;
            if (customerToEdit.isCompleted == true)
            {
                customerToEdit.balance += 10.0;
                db.SaveChanges();
                return RedirectToAction("Index", "Employees");
            }
           return RedirectToAction("Index", "Employees");
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
