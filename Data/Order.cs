using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_FirstPrj.Data
{
    public enum status
    {
        New = 0, Paid = 1, Complete = 2, Canceled = -1
    }

    public class Order
    {
        public Guid invoiceID { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime? shippingDate { get; set; }
        public status status { get; set; }
        public string buyerName { get; set; }
        public string phone { get; set; }


        public ICollection<OrderDetail> orderDetails { get; set; } //Tạo mảng rỗng để ko trả về null
        public Order()
        {
            orderDetails = new List<OrderDetail>();
        }
    }
}
