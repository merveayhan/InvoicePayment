using InvoicePayment.Areas.Admin.Models.DTO;
using InvoicePayment.Areas.Admin.Models.VM;
using InvoicePayment.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoicePayment.Areas.Admin.Controllers
{
    public class PaymentController : BaseController
    {
        public ActionResult AddPayment()
        {
            List<AppUser> model = db.AppUsers.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Update).OrderBy(x => x.AddDate).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddPayment(PaymentDTO model)
        {
            if (ModelState.IsValid)
            {
                Payment payment = new Payment();
                payment.InvoiceType = model.InvoiceType;
                payment.IdentificationNumber = model.IdentificationNumber;
                payment.InvoiceNumber = model.InvoiceNumber;
                payment.FirstName = model.FirstName;
                payment.LastName = model.LastName;
                payment.InvoiceAmount = model.InvoiceAmount;
                payment.AppUserID = model.AppUserID;
                db.Payments.Add(payment);
                db.SaveChanges();
                ViewBag.ProcessCondition = 1;
                return Redirect("/Admin/Payment/PaymentList");
            }
            else
            {
                ViewBag.ProcessCondition = 1;
                return View();
            }
        }

        public ActionResult PaymentList()
        {
            List<PaymentDTO> model = db.Payments.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Update).Select(x => new PaymentDTO
            {
                ID = x.ID,
                InvoiceType = x.InvoiceType,
                IdentificationNumber = x.IdentificationNumber,
                InvoiceNumber = x.InvoiceNumber,
                FirstName = x.FirstName,
                LastName = x.LastName,
                InvoiceAmount = x.InvoiceAmount,
                AppUserID = x.AppUserID,

            }).ToList();

            return View(model);
        }

        public ActionResult UpdatePayment(int id)
        {
            PaymentVM model = new PaymentVM();
            Payment payment = db.Payments.FirstOrDefault(x => x.ID == id);
            model.Payment.ID = payment.ID;
            model.Payment.InvoiceType = payment.InvoiceType;
            model.Payment.IdentificationNumber = payment.IdentificationNumber;
            model.Payment.InvoiceNumber = payment.InvoiceNumber;
            model.Payment.FirstName = payment.FirstName;
            model.Payment.LastName = payment.LastName;
            model.Payment.InvoiceAmount = payment.InvoiceAmount;

            List<AppUser> appusermodel = db.AppUsers.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Update).ToList();

            model.AppUsers = appusermodel;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdatePayment(PaymentDTO model)
        {
            if (ModelState.IsValid)
            {
                Payment payment = db.Payments.FirstOrDefault(x => x.ID == model.ID);
                payment.InvoiceType = model.InvoiceType;
                payment.IdentificationNumber = model.IdentificationNumber;
                payment.InvoiceNumber = model.InvoiceNumber;
                payment.FirstName = model.FirstName;
                payment.LastName = model.LastName;
                payment.InvoiceAmount = model.InvoiceAmount;
                payment.AppUserID = model.AppUserID;

                db.SaveChanges();
                return Redirect("/Admin/Payment/PaymentList");
            }
            else
            {
                return View();
            }
        }
        public ActionResult DeletePayment(int id)
        {
            if (ModelState.IsValid)
            {
                Payment payment = db.Payments.FirstOrDefault(x => x.ID == id);
                payment.Status = InvoicePayment.Model.Enum.Status.Delete;
                payment.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/Payment/PaymentList");
            }
            return View();
            // return Redirect("/Admin/Product/ProductList");
        }
    }
}