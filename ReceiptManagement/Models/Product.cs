using System.ComponentModel.DataAnnotations.Schema;

namespace ReceiptManagement.Models
{
    [Table("Products")]
    public class Product
    {
        [Column("Product_ID")]
        public long Id { get; set; }
        public string ProductID { get; set; }
        [Column("ProductName")]
        public string Name { get; set; }
    }
}
