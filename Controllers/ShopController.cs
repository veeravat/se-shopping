using ShoppingModule.DTOS;
using ShoppingModule.Services;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShoppingModule.Controllers
{
    public class ShopController : Controller, IShopController
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
            ViewData["UserProfile"] = Session["UserProfile"];
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

        //[HttpGet, ActionName("cart")]
        public ActionResult getCart()
        {
            ViewData["UserProfile"] = Session["UserProfile"];
            ViewData["Order"] = Session["Order"];
            return View();
        }

        public async Task<ActionResult> getHistory()
        {

            if (Session["UserProfile"] == null)
            {
                return RedirectToAction("index", "home");
            }

            ViewData["UserProfile"] = Session["UserProfile"];
            ViewData["Order"] = Session["Order"];
            var Smember = Session["UserProfile"] as SESHOP_Shop_member;
            var orderHistory = await db.SESHOP_Shop_Order
                .Where(x => x.SESHOP_Shop_member.memberID == Smember.memberID)
                .ToListAsync();

            return View(orderHistory);
        }
        [HttpPost, ActionName("payment")]
        public async Task<ActionResult> payment(PaymentDto payDetail)
        {
            //Random ref number from fake card
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            var refer = new string(Enumerable.Repeat(chars, 20)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var payment = new SESHOP_Shop_Order_Payment();
            payment.channel = payDetail.cardNumber;
            payment.payment_ref = refer;

            var Smember = Session["UserProfile"] as SESHOP_Shop_member;
            var Sorder = Session["Order"] as SESHOP_Shop_Order;

            var member = await db.SESHOP_Shop_member.FindAsync(Smember.memberID);
            var order = new SESHOP_Shop_Order();
            foreach (var product in Sorder.SESHOP_Shop_Order_Item)
            {

                var productItem = await db.SESHOP_Shop_Product.FindAsync(product.SESHOP_Shop_Product.productID);

                var orderItem = new SESHOP_Shop_Order_Item();
                orderItem.productID1 = productItem.productID;
                orderItem.qty = product.qty;

                order.SESHOP_Shop_Order_Item.Add(orderItem);
            }

            order.orderStatus = "paymentComplete";
            order.SESHOP_Shop_member = member;
            db.SESHOP_Shop_Order.Add(order);

            payment.SESHOP_Shop_Order = order;

            db.SESHOP_Shop_Order_Payment.Add(payment);

            await db.SaveChangesAsync();

            bool isSend = false;
            StringBuilder msgBody = new StringBuilder();
            msgBody.AppendLine("Hello, " + member.memberName);
            msgBody.AppendLine("Your Order #" + order.orderID + " has complete!!");
            msgBody.AppendLine("Click here to check shipping status");
            msgBody.AppendLine("https://seshopping.azurewebsites.net/history");
            IEmail EmailClient = new Email();
            isSend = await EmailClient.SendMailO365(member.memberEmail, "Your Order #" + order.orderID + " has complete!!", msgBody.ToString());

            Session["Order"] = null;
            return Json(new
            {
                status = isSend
            });
        }

        [HttpPost, ActionName("cart")]
        public async Task<ActionResult> Cart(CartDto cartItem)
        {

            if (Session["Order"] == null)
            {
                Session["Order"] = new SESHOP_Shop_Order();
            }
            var order = Session["Order"] as SESHOP_Shop_Order;

            var product = await db.SESHOP_Shop_Product.FindAsync(cartItem.productID);

            var orderItem = new SESHOP_Shop_Order_Item();
            orderItem.SESHOP_Shop_Product = product;
            orderItem.qty = cartItem.qty;

            //var existed = order.SESHOP_Shop_Order_Item
            //    .Where(x => x.SESHOP_Shop_Product.productID == cartItem.productID)
            //    .First();
            //if (existed != null)
            //{

            //}
            order.SESHOP_Shop_Order_Item.Add(orderItem);

            Session["Order"] = order;
            return Json(new
            {
                status = true
            });

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
