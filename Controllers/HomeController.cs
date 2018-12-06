using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShoppingModule.Controllers
{
    public class HomeController : Controller
    {
        private seshop db = new seshop();
       
        public async Task<ActionResult> Index()
        {
            ViewData["UserProfile"] = Session["UserProfile"];
            return View(await db.SESHOP_Shop_Product.ToListAsync());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewData["UserProfile"] = Session["UserProfile"];
            return View();
        }
    }
}