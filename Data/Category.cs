using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_FirstPrj.Data
{
    public class Categories
    {
        [Key]
        public Guid categoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string categoryName { get; set;}

        //tạo mỗi qh người lại giữa Category và Items
        public virtual ICollection<Items> items { get; set; }
    }
}
