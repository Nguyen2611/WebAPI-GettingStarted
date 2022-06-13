using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_FirstPrj.Data
{
    public class ItemVM
    {
        public string name { get; set; }
        
        public double price { get; set; }
    }

    public class Item : ItemVM
    {
        public Guid ISBN { get; set; }
    } 
}
