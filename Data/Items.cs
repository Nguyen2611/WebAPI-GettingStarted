using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_FirstPrj.Data
{
    [Table("Items")]
    public class Items
    {
        [Key]
        public Guid ISBN { get; set; }
        [Required]
        [MaxLength(100)]
        public string name { get; set; }
        public string description { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double price { get; set; }
        public byte discount { get; set; }
        public Guid? categoryId { get; set; }
        [ForeignKey("categoryId")]
        public Category category { get; set; } //Tạo mối qh giữa Item và Category

        public ICollection<OrderDetail> orderDetails { get; set; }
        public Items() //Tạo mảng rỗng để ko trả về null 
        {
            orderDetails = new List<OrderDetail>();
        }
    }
}
