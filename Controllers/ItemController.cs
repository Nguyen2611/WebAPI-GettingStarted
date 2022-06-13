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
    public class ItemController : ControllerBase
    {
        public static List<Item> listItem = new List<Item>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(listItem);
        }

        [HttpGet("{ISBN}")]
        public IActionResult GetAll(string ISBN)
        {
            try
            {
                //LINQ [Object] Query
                var item = listItem.SingleOrDefault(s => s.ISBN == Guid.Parse(ISBN)); //Có thì trả về 1 object, ko có thì trả null
                if (item == null)
                {
                    return NotFound(); //trả về lỗi 404
                }
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult Create(ItemVM itemVM)
        {
            var item = new Item
            {
                ISBN = Guid.NewGuid(),
                name = itemVM.name,
                price = itemVM.price,
            };
            listItem.Add(item);
            return Ok(new { 
                Success = true,
                Data = listItem,
            });
        }

        [HttpPut("{id}")]
        public IActionResult editItem(string id,Item edtiedItem)
        {
            try
            {
                var item = listItem.SingleOrDefault(s => s.ISBN == Guid.Parse(id));
                if (item == null)
                    return NotFound();

                if (id != item.ISBN.ToString())
                    return BadRequest();
                //Updape
                item.name = edtiedItem.name;
                item.price = edtiedItem.price;
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteItem(string id)
        {
            try
            {
                var item = listItem.SingleOrDefault(s => s.ISBN == Guid.Parse(id));
                if (item == null)
                    return NotFound();
                listItem.Remove(item);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
