using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext dContext;

        public ProductController(DataContext dContext)
        {
            this.dContext = dContext;
        }
        [HttpPost]
        [Route("addData")]
        public async Task<ActionResult<Product>> CreateData()
        {
            var product = new Product
            {
                 name = "Porsche",
                 productType = "Sport",
                 productYear = "2015",

            };

            var category = new Category
            {
                Product = product,
                ProductId = product.id,
                Name = "casual",
                Description = "race car"
            };
            var subCategory = new SubCategory
            {
                Product = product,
                ProductId = product.id,
                Name = "Hyper",
                Description = "Expensive"
            };
            dContext.Add(category);
            dContext.Add(subCategory);
            dContext.SaveChanges();

            return Ok("Data is added");
        }
        [HttpGet]
        [Route("getAllData")]
        public async Task<IActionResult> GetAllDatas()
        {
            var alldatas = await (from p in dContext.Product
                                  from c in dContext.Category.Where(ca => ca.ProductId == p.id)
                                  from s in dContext.SubCategory.Where(sc => sc.ProductId == p.id)
                                  select new
                                  {
                                      pid = p.id,
                                      cid = c.Id,
                                      productname = p.name,
                                      productyear = p.productYear,
                                      producttype = p.productType,
                                      categoryname = c.Name,
                                      categorydescription = c.Description,
                                      subCategoryName = s.Name,
                                      subCategoryDescription = s.Description
                                  }).ToListAsync();


            return Ok(alldatas);

        }
        [HttpPut]
        [Route("updateData")]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var updateProduct = dContext.Product.FirstOrDefault(p => p.id.Equals(id));
            {
                updateProduct.productYear = "1950";
               
                await dContext.SaveChangesAsync();
            }
            return NoContent();

        }
        [HttpDelete]
        [Route("deleteData")]
        public async Task<IActionResult>  DeleteProduct(int id)
        {
            var deleteProduct = dContext.Product.FirstOrDefault(p => p.id.Equals(id));
            {
                dContext.Remove(deleteProduct);
                await dContext.SaveChangesAsync().ConfigureAwait(false);
            }
            return NoContent();

        }
    }
}
