using InvoicePayment.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InvoicePayment.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult UserLogin()
        {

            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult UserLogin(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                if (db.AppUsers.Any(x => x.Status == InvoicePayment.Model.Enum.Status.Active || x.Status == InvoicePayment.Model.Enum.Status.Update))
                {
                    if (db.AppUsers.Any(x => x.Role == Model.Enum.Role.Admin))
                    {
                        FormsAuthentication.SetAuthCookie(model.FirstName + " " + model.LastName, true);
                        return RedirectToAction("AdminHomeIndex", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Your Email or Password is wrong";
                        return View();
                    }
                    //Member
                }
                else
                {
                    ViewBag.Message = "Your Email or Password is wrong";
                    return View();

                }

            }
            else
            {
                ViewBag.Message = "Your Email or Password is wrong";
                return View();

            }

        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("UserLogin", "Account");
        }
    }
}