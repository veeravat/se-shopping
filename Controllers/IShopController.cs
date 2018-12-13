using System.Threading.Tasks;
using System.Web.Mvc;
using ShoppingModule.DTOS;

namespace ShoppingModule.Controllers
{
    public interface IShopController
    {
        Task<ActionResult> Cart(CartDto cartItem);
        ActionResult Create();
        Task<ActionResult> Create([Bind(Include = "productID,productName,productPrice")] SESHOP_Shop_Product sESHOP_Shop_Product);
        Task<ActionResult> Delete(int? id);
        Task<ActionResult> DeleteConfirmed(int id);
        Task<ActionResult> Details(int? id);
        Task<ActionResult> Edit(int? id);
        Task<ActionResult> Edit([Bind(Include = "productID,productName,productPrice")] SESHOP_Shop_Product sESHOP_Shop_Product);
        ActionResult getCart();
        Task<ActionResult> getHistory();
        Task<ActionResult> Index();
        Task<ActionResult> payment(PaymentDto payDetail);
    }
}