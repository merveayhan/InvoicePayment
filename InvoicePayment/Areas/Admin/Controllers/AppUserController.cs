using InvoicePayment.Areas.Admin.Models.DTO;
using InvoicePayment.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicePayment.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {
        
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(AppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;              
                user.Password = model.Password;
                user.Phone = model.Phone;
                user.Role = model.Role;
              
                db.AppUsers.Add(user);
                db.SaveChanges();
                return Redirect("/Admin/AppUser/UserList");
            }
            else
            {
                return Redirect("/Admin/AppUser/UserList");
                //return View();
            }
        }

        public ActionResult UpdateUser(int id)
        {
            AppUser user = db.AppUsers.FirstOrDefault(x => x.ID == id);
            AppUserDTO model = new AppUserDTO();
            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.UserName = user.UserName;        
            model.Password = user.Password;
            model.Phone = user.Phone;
            model.Role = user.Role;
            


            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateUser(AppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = db.AppUsers.FirstOrDefault(x => x.ID == model.ID);
                user.FirstName = model.UserName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;              
                user.Password = model.Password;
                user.Phone = model.Phone;
                user.Role = model.Role;
                user.Status = Model.Enum.Status.Update;
                user.UpdateDate = DateTime.Now;
                db.SaveChanges();
                ViewBag.ProcessCondition = 1;
                return Redirect("/Admin/AppUser/UserList");
            }

            else
            {
                ViewBag.ProcessCondition = 2;
                return View();
            }
        }

        public ActionResult DeleteUser(int id)
        {
            if (ModelState.IsValid)
            {
                AppUser user = db.AppUsers.FirstOrDefault(x => x.ID == id);
                user.Status = Model.Enum.Status.Delete;
                user.DeleteDate = DateTime.Now;
                db.SaveChanges();
                ViewBag.ProcessCondition = 1;
                return Redirect("/Admin/AppUser/UserList");
            }
            else
            {
                ViewBag.ProcessCondition = 2;
                return Redirect("/Admin/AppUser/UserList");
            }
        }

        public ActionResult UserList()
        {
            List<AppUserDTO> model = db.AppUsers.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Update).Select(x => new AppUserDTO()
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserName = x.UserName,             
                Password = x.Password,
                Phone = x.Phone,
                Role = x.Role,
                
            }).ToList();

            return View(model);
        }
    }
}