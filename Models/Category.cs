using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_FirstPrj.Data
{
    public class CategoryVM
    {
        [Required]
        [MaxLength(50)]
        public string categoryName { get; set; }
    }

    public class Category : CategoryVM
    {
        public Guid categoryId { get; set; }
    }
}
