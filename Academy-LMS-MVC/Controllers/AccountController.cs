using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Academy_LMS_MVC.Models;
using Academy_LMS_MVC.BLL;

namespace Academy_LMS_MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {


            return View();
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(Users user)
        {
            UsersOperationsBLL usersOperations = new UsersOperationsBLL();
            int result = usersOperations.Register(user);
            if(result == 0)
            {
                ViewData["UserNotSaved"] = "User Not Registered, Please try again";
                return View();
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult LoginUser(string Email, string Passwod)
        {
            UsersOperationsBLL usersOperationsBLL = new UsersOperationsBLL();
            Users user = new Users();

            if (usersOperationsBLL.UserExists(Email) == 1)
            {
                //user=usersOperationsBLL.Login(Email, Passwod);
                return View();
            }
            else
            {
                ViewData["NotExist"] = "This Email is not present in your system";
                return View();
            }
           
            
        }
    }
}