using CalorieCalc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieCalc.Controllers
{

    public class HomeController : Controller
    {

        private FoodContext context { get; set; }

        public HomeController(FoodContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()

        {


            ViewBag.Users = context.Users.OrderBy(
            m => m.UserName).ToList();
            return View();

        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            ViewBag.Users
            = context.Users.OrderBy(g => g.UserName).ToList();
            var user = context.Users.Find(id);
            return View("AddUser", user);

        }

        [HttpPost]
        public IActionResult Update(User user)
        {

            if (ModelState.IsValid)
            {
                context.Database.OpenConnection();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users ON");

            

                if (user.UserId == 0)
                {

                    User LastElement = context.Users.OrderByDescending(p => p.UserId).FirstOrDefault();
                    if (LastElement == null || LastElement.UserId == -1)
                    {
                        int NextId = 1;
                        user.UserId = NextId;
                    }
                    else
                    {
                        int NextId = LastElement.UserId + 1;
                        user.UserId = NextId;
                    }



                    context.Users.Add(user);

                }

                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Action =
                (user.UserId == 0) ? "Add" : "Update";
                ViewBag.Users =
                 context.Users.OrderBy(g => g.UserName).ToList();
                return View("AddUser", user);
            }

            

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Users
            = context.Users.OrderBy(g => g.UserName).ToList();
            return View("AddUser", new User());
        }




    }


}


