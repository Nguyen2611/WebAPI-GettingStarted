using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_FirstPrj.Data;

namespace WebAPI_FirstPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _context;
        public static List<Category> listCategory = new List<Data.Category>();

        //Inject MyDbContext
        public CategoryController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(listCategory);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            var category = listCategory.SingleOrDefault(s => s.categoryId == Guid.Parse(id));
            if(category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        [Authorize]
        public IActionResult createCategory(Data.Category category)
        {
            try
            {
                var category1 = new Category
                {
                    categoryId = Guid.NewGuid(),
                    categoryName = category.categoryName,
                };
                listCategory.Add(category1);
                return Ok(new
                {
                    Success = true,
                    Data = listCategory,
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateById(string id, Data.Category category)
        {
            var category1 = listCategory.SingleOrDefault(s => s.categoryId == Guid.Parse(id));
            if (category1 == null)
                return NotFound();
            category1.categoryName = category.categoryName;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            var category1 = listCategory.SingleOrDefault(s => s.categoryId == Guid.Parse(id));
            if (category1 == null)
                return NotFound();
            listCategory.Remove(category1);
            _context.SaveChanges();
            return Ok();
        }
    }
}
