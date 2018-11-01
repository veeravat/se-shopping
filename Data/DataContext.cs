using Microsoft.EntityFrameworkCore;
using seshopping.Models;

namespace seshopping.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ShopMember> ShopMembers { get; set; }
        public DbSet<ShopOrder> ShopOrder { get; set; }
        public DbSet<ShopOrderItem> ShopOrderItem { get; set; }
        public DbSet<ShopOrderPayment> ShopOrderPayment { get; set; }
        public DbSet<Product> Product { get; set; }
        
        // public DbSet<news> news { get; set; }



    }
}