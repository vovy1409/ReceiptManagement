using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceiptManagement.Models
{
    [Table("Receipts")]
    public class Receipt
    {
        [Column("Receipt_ID")]
        public long Id { get; set; }

        public long Customer_ID { get; set; }

        public DateTime ReceiptDate { get; set; }

        [ForeignKey("Customer_ID")]
        public virtual Customer Customer { get; set; }
    }
}
