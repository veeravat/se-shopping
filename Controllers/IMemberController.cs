using System.Threading.Tasks;
using System.Web.Mvc;
using ShoppingModule.DTOS;

namespace ShoppingModule.Controllers
{
    public interface IMemberController
    {
        Task<ActionResult> AddRegister(MemberRegisterDtos registerData);
        ActionResult Create();
        Task<ActionResult> Create([Bind(Include = "memberID,memberName,memberTel,memberEmail,password,address")] SESHOP_Shop_member sESHOP_Shop_member);
        Task<ActionResult> Details(int? id);
        Task<ActionResult> Edit(int? id);
        Task<ActionResult> Edit([Bind(Include = "memberID,memberName,memberTel,memberEmail,password,address")] SESHOP_Shop_member sESHOP_Shop_member);
        Task<ActionResult> Index();
        Task<ActionResult> Login(MemberLoginDtos logindata);
        ActionResult Logout();
        ActionResult Register();
    }
}