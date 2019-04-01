using ECommerce2.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unity;
using WebApplication2.DataEF;
using WebApplication2.DataEF.Repositories;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> prodRepository;
        private readonly IRepository<ProductCategory> prodCategRepo;

        public ProductsController(IRepository<Product> prodRepository, 
                                  IRepository<ProductCategory> prodCategRepo)
        {
            //dbService = new DatabaseService();
            this.prodRepository = prodRepository;
            this.prodCategRepo = prodCategRepo;
        }

        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
            var products = prodRepository.GetAll();
            return View(products.ToList());
        }

        // GET: Products/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = prodRepository.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductCategoryID = new SelectList(prodCategRepo.GetAll(), "ProductCategoryID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Description,Price,ProductCategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                prodRepository.Add(product);
                prodRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategoryID = new SelectList(prodCategRepo.GetAll(), "ProductCategoryID", "Name", product.ProductCategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = prodRepository.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryID = new SelectList(prodCategRepo.GetAll(), "ProductCategoryID", "Name", product.ProductCategoryID);
            ViewBag.IsProductDeleted = product.Deleted;
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Description,Price,ProductCategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                prodRepository.Update(product);
                prodRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.IsProductDeleted = product.Deleted;
            ViewBag.ProductCategoryID = new SelectList(prodCategRepo.GetAll(), "ProductCategoryID", "Name", product.ProductCategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = prodRepository.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.IsProductDeleted = product.Deleted;
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = prodRepository.Find(id);
            product.Deleted = true;
            ViewBag.IsProductDeleted = product.Deleted;

            prodRepository.Delete(id);
            //db.Products.Remove(product);
            prodRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //prodRepository.Dispose();
                //prodCategRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
