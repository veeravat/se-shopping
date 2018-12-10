using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShoppingModule.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        private seshop db = new seshop();
       
        public async Task<ActionResult> Index()
        {
            ViewData["UserProfile"] = Session["UserProfile"];
            return View(await db.SESHOP_Shop_Product.ToListAsync());
        }

        public ActionResult Login()
        {
            ViewData["UserProfile"] = Session["UserProfile"];
            return View();
        }
    }
}