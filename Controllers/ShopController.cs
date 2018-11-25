using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingModule;

namespace ShoppingModule.Controllers
{
    public class ShopController : Controller
    {
        private seshop db = new seshop();

        // GET: Shop
        public async Task<ActionResult> Index()
        {
            return View(await db.SESHOP_Shop_Product.ToListAsync());
        }

        // GET: Shop/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESHOP_Shop_Product sESHOP_Shop_Product = await db.SESHOP_Shop_Product.FindAsync(id);
            if (sESHOP_Shop_Product == null)
            {
                return HttpNotFound();
            }
            return View(sESHOP_Shop_Product);
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "productID,productName,productPrice")] SESHOP_Shop_Product sESHOP_Shop_Product)
        {
            if (ModelState.IsValid)
            {
                db.SESHOP_Shop_Product.Add(sESHOP_Shop_Product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sESHOP_Shop_Product);
        }

        // GET: Shop/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESHOP_Shop_Product sESHOP_Shop_Product = await db.SESHOP_Shop_Product.FindAsync(id);
            if (sESHOP_Shop_Product == null)
            {
                return HttpNotFound();
            }
            return View(sESHOP_Shop_Product);
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "productID,productName,productPrice")] SESHOP_Shop_Product sESHOP_Shop_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sESHOP_Shop_Product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sESHOP_Shop_Product);
        }

        // GET: Shop/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESHOP_Shop_Product sESHOP_Shop_Product = await db.SESHOP_Shop_Product.FindAsync(id);
            if (sESHOP_Shop_Product == null)
            {
                return HttpNotFound();
            }
            return View(sESHOP_Shop_Product);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SESHOP_Shop_Product sESHOP_Shop_Product = await db.SESHOP_Shop_Product.FindAsync(id);
            db.SESHOP_Shop_Product.Remove(sESHOP_Shop_Product);
            await db.SaveChangesAsync();
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
