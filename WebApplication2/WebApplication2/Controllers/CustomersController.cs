using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce2.Data.Common;
using WebApplication2.DataEF;

namespace WebApplication2.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IRepository<Customer> csRepository;
        private IRepository<Countrye> countryRepo;
        private IRepository<Citye> cityRepo;

        public CustomersController(IRepository<Customer> csRepository,
                                   IRepository<Citye> cityRepo,
                                   IRepository<Countrye> countryRepo)
        {
            this.csRepository = csRepository;
            this.cityRepo = cityRepo;
            this.countryRepo = countryRepo;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = csRepository.GetAll();
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = csRepository.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(cityRepo.GetAll(), "CityID", "Name");
            ViewBag.CountryID = new SelectList(countryRepo.GetAll(), "CountryID", "CountryName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Name,LastName,Mail,Adress,CityID,CountryID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                csRepository.Add(customer);
                csRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(cityRepo.GetAll(), "CityID", "Name", customer.CityID);
            ViewBag.CountryID = new SelectList(countryRepo.GetAll(), "CountryID", "CountryName", customer.CountryID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = csRepository.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(cityRepo.GetAll() , "CityID", "Name", customer.CityID);
            ViewBag.CountryID = new SelectList(countryRepo.GetAll(), "CountryID", "CountryName", customer.CountryID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Name,LastName,Mail,Adress,CityID,CountryID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                csRepository.Update(customer);
                csRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(cityRepo.GetAll(), "CityID", "Name", customer.CityID);
            ViewBag.CountryID = new SelectList(countryRepo.GetAll(), "CountryID", "CountryName", customer.CountryID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = csRepository.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            csRepository.Delete(id);
            csRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
