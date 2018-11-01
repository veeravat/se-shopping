using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seshopping.Models
{
    public class WarehouseModule
    {
        
    }

    [Table("SESHOP_Shop_Product")]
    public class Product
    {
        [Key]public int productID { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
    }
}