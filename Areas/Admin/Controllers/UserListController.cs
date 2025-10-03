using CalorieCalc.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace CalorieCalc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserListController : Controller
    {

        private FoodContext context { get; set; }


        public UserListController(FoodContext ctx)
        {
            context = ctx;

        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }


        public IActionResult List()
        {
            var data = new FoodUserListView();

            data.users = context.Users.ToList();


            return View(data);
        }

        [HttpGet]

        public IActionResult Users()
        {

            var data = new FoodUserListView();


            data.users = context.Users.ToList();


            return View(data);

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Users
            = context.Users.OrderBy(g => g.UserName).ToList();
            return View("AddUpdate", new User());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            ViewBag.Users
            = context.Users.OrderBy(g => g.UserName).ToList();
            var user = context.Users.Find(id);
            return View("AddUpdate", user);

        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.UserId == 0)
                {
                    context.Users.Add(user);
                }
                else
                {
                    context.Users.Update(user);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action =
                (user.UserId == 0) ? "Add" : "Update";
                ViewBag.Users =
                 context.Users.OrderBy(g => g.UserName).ToList();
                return View("AddUpdate", user);
            }
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Admin", "Home");
        }
    }
}
