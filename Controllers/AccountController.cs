using SearchFunctionality.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SearchFunctionality.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var Context = new employeeEntities())
            {
                bool IsValid = Context.Users.Any(x => x.UserName == model.UserName && x.password == model.password);
                if (IsValid)
                {
                    //Cookies is a small piece of information stored on the client machine.
                    //That is often used to identify the user
                    // it'll load the cookies and parse the value
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "employees");
                }
                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Models.User model)
        {
            using (var Context = new employeeEntities())
            {
                Context.Users.Add(model);
                Context.SaveChanges();
            }
            return RedirectToAction("login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }






    }
