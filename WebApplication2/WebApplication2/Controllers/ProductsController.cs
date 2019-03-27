using ECommerce2.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DataEF;
using WebApplication2.DataEF.Repositories;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        //private ECommerceEntities db = new ECommerceEntities();
        IRepository<Product> productsDb { get { return DependencyResolver.Current.GetService<IDatabaseService>().ProductRepository; } }
        IRepository<ProductCategory> productsCatDb { get { return DependencyResolver.Current.GetService<IDatabaseService>().ProductCategoryRepository; } }

        // GET: Products
        public ActionResult Index()
        {
            var products = productsDb.GetAll();
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productsDb.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductCategoryID = new SelectList(productsCatDb.GetAll(), "ProductCategoryID", "Name");
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
                productsDb.Add(product);
                productsDb.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategoryID = new SelectList(productsCatDb.GetAll(), "ProductCategoryID", "Name", product.ProductCategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productsDb.Find(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryID = new SelectList(productsCatDb.GetAll(), "ProductCategoryID", "Name", product.ProductCategoryID);
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
                productsDb.Update(product);
                productsDb.Save();
                return RedirectToAction("Index");
            }
            ViewBag.IsProductDeleted = product.Deleted;
            ViewBag.ProductCategoryID = new SelectList(productsCatDb.GetAll(), "ProductCategoryID", "Name", product.ProductCategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productsDb.Find(id.Value);
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
            Product product = productsDb.Find(id);
            product.Deleted = true;
            ViewBag.IsProductDeleted = product.Deleted;

            productsDb.Delete(id);
            //db.Products.Remove(product);
            productsDb.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                productsDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
