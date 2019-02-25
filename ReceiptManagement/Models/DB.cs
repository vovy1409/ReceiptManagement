using Microsoft.EntityFrameworkCore;

namespace ReceiptManagement.Models
{
    public class DB:DbContext
    {
        public DB(DbContextOptions<DB> options)
            :base(options)
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Receipt_Item> Receipt_Items { get; set; }
    }
}
