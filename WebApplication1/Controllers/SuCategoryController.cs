using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuCategoryController : ControllerBase
    {
        private readonly DataContext dContext;

        public SuCategoryController(DataContext dContext)
        {
            this.dContext = dContext;
        }
        [HttpGet]
        [Route("getAllData")]
        public async Task<IActionResult> GetAllDatas()
        {
            var alldatas = await (from p in dContext.Product
                                  from c in dContext.Category.Where(ca => ca.ProductId == p.id)
                                  select new
                                  {
                                      pid = p.id,
                                      cid = c.Id,
                                      productname = p.name,
                                      productyear = p.productYear,
                                      producttype = p.productType,
                                      categoryname = c.Name,
                                      categorydescription = c.Description,
                                  }).ToListAsync();


            return Ok(alldatas);

        }
    }
}

