
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync();
            SliderInfo sliderInfo = await _context.SlidersInfo.Where(m=>!m.SoftDeleted).FirstOrDefaultAsync();
            IEnumerable<Blog> blog = await _context.Blogs.Where(m => !m.SoftDeleted).Take(3).ToListAsync();
            BlogDetail blogDetail = await _context.BlogsDetails.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
            IEnumerable<Category> categories = await _context.Categories.Where(m => !m.SoftDeleted).ToListAsync();
            IEnumerable<Product> products=await _context.Products.Include(m=>m.Images).ToListAsync();
            About about = await _context.Abouts.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
            IEnumerable<Expert>  experts= await _context.Experts.Where(m => !m.SoftDeleted).Take(4).ToListAsync();
            IEnumerable<Start> starts = await _context.Starts.Where(m => !m.SoftDeleted).Take(2).ToListAsync();
            IEnumerable<Instagram> instagrams = await _context.Instagrams.Where(m => !m.SoftDeleted).ToListAsync();

            HomeVM homeVM = new() 
            { 
            
                SliderInfo = sliderInfo,
                Sliders = sliders,
                Blogs= blog,
                BlogDetail = blogDetail,
                Categories = categories,
                Products = products,
                About = about,
                Experts = experts,
                Starts = starts,
                Instagram = instagrams
                
            
            };

            return View(homeVM);
        }

       
    }
}