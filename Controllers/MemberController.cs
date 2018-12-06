using ShoppingModule.DTOS;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShoppingModule.Controllers
{
    public class MemberController : Controller
    {
        private seshop db = new seshop();

        // GET: Member
        public async Task<ActionResult> Index()
        {
            return View(await db.SESHOP_Shop_member.ToListAsync());
        }

        // GET: Member/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESHOP_Shop_member sESHOP_Shop_member = await db.SESHOP_Shop_member.FindAsync(id);
            if (sESHOP_Shop_member == null)
            {
                return HttpNotFound();
            }
            return View(sESHOP_Shop_member);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet, ActionName("logout")]
        public ActionResult Logout()
        {
            Session["UserProfile"] = null;
            Session["Order"] = null;
            return RedirectToAction("index", "home");

        }

        [HttpGet, ActionName("register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("register")]
        public async Task<ActionResult> AddRegister(MemberRegisterDtos registerData)
        {
            var check = await db.SESHOP_Shop_member
                .Where(x => x.memberEmail == registerData.email)
                .FirstOrDefaultAsync();

            if (check != null)
            {
                return Json(new
                {
                    status = false
                });
            }
            var member = new SESHOP_Shop_member();
            member.memberName = registerData.memberName;
            member.password = registerData.password;
            member.memberEmail = registerData.email;
            member.address = registerData.address;
            member.memberTel = registerData.memberTel;
            db.SESHOP_Shop_member.Add(member);
            await db.SaveChangesAsync();
            return Json(new
            {
                status = true
            });
        }
        [HttpPost, ActionName("login")]
        public async Task<ActionResult> Login(MemberLoginDtos logindata)
        {
            bool statusMsg = false;
            SESHOP_Shop_member member = await db.SESHOP_Shop_member
                .Where(x => logindata.email == x.memberEmail)
                .Where(x => logindata.password == x.password)
                .FirstOrDefaultAsync();
            if (member != null)
            {
                Session["UserProfile"] = member;
                statusMsg = true;
            }
            return Json(new
            {
                status = statusMsg,
                email = logindata.email,
                password = logindata.password
            });
        }

        // POST: Member/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "memberID,memberName,memberTel,memberEmail,password,address")] SESHOP_Shop_member sESHOP_Shop_member)
        {
            if (ModelState.IsValid)
            {
                db.SESHOP_Shop_member.Add(sESHOP_Shop_member);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sESHOP_Shop_member);
        }

        // GET: Member/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESHOP_Shop_member sESHOP_Shop_member = await db.SESHOP_Shop_member.FindAsync(id);
            if (sESHOP_Shop_member == null)
            {
                return HttpNotFound();
            }
            return View(sESHOP_Shop_member);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "memberID,memberName,memberTel,memberEmail,password,address")] SESHOP_Shop_member sESHOP_Shop_member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sESHOP_Shop_member).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sESHOP_Shop_member);
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
