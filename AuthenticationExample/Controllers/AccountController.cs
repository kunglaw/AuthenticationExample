using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationExample.Models;
using AuthenticationExample.Libraries;
using System.Web.Script.Serialization;

namespace AuthenticationExample.Controllers
{
    public class AccountController : Controller
    {
        UserDBEntities1 objUserDBEntities1 = new UserDBEntities1();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel userModel) // dari form input post
        {
            User objUser = new User(); // dari models

            objUser.created_at = DateTime.Now;

            objUser.firstname = userModel.FirstName;
            objUser.lastname = userModel.LastName;
            objUser.email = userModel.Email;
            objUser.password = Encryption.md5(userModel.Password);

            objUserDBEntities1.Users.Add(objUser);

            //objUserDBEntities1.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.Users ON");
            objUserDBEntities1.SaveChanges();
            //objUserDBEntities1.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT dbo.Users OFF");
            userModel.SuccessMessage = "User is Successfully Added";

            return View(userModel);

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {

            //var json = new JavaScriptSerializer().Serialize(objLoginModel);
            //return Content(json);

            if(ModelState.IsValid)
            {
                var encryptPass = Encryption.md5(objLoginModel.Password);
                var fetch = objUserDBEntities1.Users.Where(m => m.email == objLoginModel.Email && m.password == encryptPass).FirstOrDefault();
                //return Content(new JavaScriptSerializer().Serialize(fetch));

                if ( fetch == null)
                {
                    ModelState.AddModelError("Error", "Email or Password are wrong");
                    return View();
                }
                else
                {
                    Session["Email"] = objLoginModel.Email;
                    //Response.Redirect("");
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
           
            //
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}