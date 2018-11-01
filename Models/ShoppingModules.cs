using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seshopping.Models
{
    public class ShoppingModules
    {

    }
    [Table("SESHOP_Shop_member")]
    public class ShopMember
    {
        [Key]
        public int memberID { get; set; }
        public string memberName { get; set; }
        public string memberTel { get; set; }
        public string memberEmail { get; set; }
        public string password { get; set; }
        public string address { get; set; }
    }
    [Table("SESHOP_Shop_Order")]
    public class ShopOrder
    {
        [Key]
        public int orderID { get; set; }
        public ShopMember memberID { get; set; }
        public List<ShopOrderItem> orderItemID { get; set; }
        public string orderStatus { get; set; }

    }
    [Table("SESHOP_Shop_Order_Item")]
    public class ShopOrderItem
    {
        [Key]
        public int orderItemID { get; set; }
        public Product productID { get; set; }
        public int qty { get; set; }

    }
    [Table("SESHOP_Shop_Order_Payment")]
    public class ShopOrderPayment
    {
        [Key]public int paymentID { get; set; }
        public ShopOrder orderID { get; set; }
        public string channel { get; set; }
        public string payment_ref { get; set; }
    }

}