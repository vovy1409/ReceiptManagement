using System.ComponentModel.DataAnnotations.Schema;

namespace ReceiptManagement.Models
{
    [Table("Customers")]
    public class Customer
    {
        //khi đặt tên biến khác tên cột trong database thì map lại bằng từ khóa column
        [Column("Customer_ID")]
        public long Id { get; set; }

        public string CustomerID { get; set; }
        [Column("CustomerName")]
        public string Name { get; set; }
        [Column("CustomerAddress")]
        public string Address { get; set; }
    }
}
