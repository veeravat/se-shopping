using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShoppingModule.Controllers
{
    public interface IHomeController
    {
        Task<ActionResult> Index();
        ActionResult Login();
    }
}