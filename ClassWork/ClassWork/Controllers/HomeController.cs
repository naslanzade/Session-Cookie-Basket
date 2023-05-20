using ClassWork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ClassWork.Controllers
{
    public class HomeController : Controller
    {    

        public IActionResult Index()
        {
            //HttpContext.Session.SetInt32("age", 19);
            //HttpContext.Session.SetString("name", "Gultaj");
            //Response.Cookies.Append("surname", "Jafarova",new CookieOptions {MaxAge=TimeSpan.FromMinutes(20)});                      
            //Book book = new() { 

            //    Id = 1,
            //    Name = "Iskandarname",
            //    Author="Nizami"            
            //};

            //var serializeObject=JsonSerializer.Serialize(book);
            //HttpContext.Session.SetString("book", serializeObject);


            if (HttpContext.Session.GetString("user") != null)
            {
                User user=JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
                ViewBag.username = user.Username;
            }



            return View();
        }

        public IActionResult Privacy()
        {
            //ViewBag.age=HttpContext.Session.GetInt32("age");
            //ViewBag.name = HttpContext.Session.GetString("name");
            //ViewBag.surname = Request.Cookies["surname"];
            //var model = JsonSerializer.Deserialize<Book>(HttpContext.Session.GetString("book"));

            return View();
        }


        
    }

    //class Book
    //{
    //    public int Id { get; set; }
    //    public string ? Name { get; set; }
    //    public string ? Author { get; set; }

    //}

}