using Fiorello.Data;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.ContentModel;

namespace Fiorello.Controllers
{
    public class CartController : Controller
    {


        private readonly AppDbContext _context;

        private readonly IHttpContextAccessor _accessor;

        public CartController(AppDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }


        public async Task<IActionResult> Index()
        {
            List<BasketDetailVM> basketList = new();

            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
                List<BasketVM> basketDatas= JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
                foreach (var item in basketDatas)
                {
                    var dbProduct = await _context.Products.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == item.Id);
                    
                    
                    if(dbProduct != null)
                    {
                        BasketDetailVM basketDetail = new()
                        {
                            Id = dbProduct.Id,
                            Name = dbProduct.Name,
                            Image = dbProduct.Images.Where(m => m.IsMain).FirstOrDefault().Image,
                            Count = item.Count,
                            Price = dbProduct.Price,
                            TotalPrice = dbProduct.Price * item.Count,
                        };

                        basketList.Add(basketDetail);

                    }
                  
                }
                
            }

            return View(basketList);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteProduct(int ? id)
        {
            if (id is null) return BadRequest();

            var products = JsonConvert.DeserializeObject<List<BasketDetailVM>>(_accessor.HttpContext.Request.Cookies["basket"]);

            var deleteProduct=products.FirstOrDefault(m => m.Id == id);

            int deleteIndex=products.IndexOf(deleteProduct);

            products.RemoveAt(deleteIndex);

            _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(products));

            return RedirectToAction(nameof(Index));

        }
    }
}
