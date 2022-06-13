using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_FirstPrj.Data
{
    public class OrderDetail
    {
        public Guid ISBN { get; set; }
        public Guid invoiceID { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public byte discount { get; set; }

        //relationship
        public Order order { get; set; }
        public Items item { get; set; }
    }
}
