using ClassWork.Models;
using ClassWork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ClassWork.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
       public IActionResult Login()
       {
            return View();
       }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Loging(LoginVM model) 
        {

            List<User> dbUsers = GetAll();

            var findUserByEmail = dbUsers.FirstOrDefault(m => m.Email == model.Email);
            if (findUserByEmail == null)
            {
                ViewBag.error = "Email or password is wrong";
                return View();
            }

            if (findUserByEmail.Password!=model.Password)
            {
                ViewBag.error = "Email or password is wrong";
                return View();
            }


            HttpContext.Session.SetString("user",JsonSerializer.Serialize(findUserByEmail));
            
            return RedirectToAction("Index","Home");
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

        private List<User> GetAll()
        {
            User user1 = new()
            {
                Id = 1,
                Username = "resul123",
                Email = "resul@gmail.com",
                Password = "Resul123_"
            };

            User user2 = new()
            {
                Id = 2,
                Username = "gultaj123",
                Email = "gultaj@gmail.com",
                Password = "Gultaj123_"
            };

            User user3 = new()
            {
                Id = 3,
                Username = "novreste123",
                Email = "novreste@gmail.com",
                Password = "Novreste123_"
            };

            List<User> users = new() { user1, user2, user3 };

            return(users);

        }
    }
}
