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
    public class InvoiceController : BaseController
    {
        
        public ActionResult AddInvoice()
        {
            List<AppUser> model =db.AppUsers.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Update).OrderBy(x => x.AddDate).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddInvoice(InvoiceDTO model)
        {
            if (ModelState.IsValid)
            {
                Invoice invoice = new Invoice();
                invoice.InvoiceName = model.InvoiceName;
                invoice.InvoiceDate = model.InvoiceDate;
                invoice.AppUserID = model.AppUserID;
                db.Invoices.Add(invoice);
                db.SaveChanges();
                ViewBag.ProcessCondition = 1;
                return Redirect("/Admin/Invoice/InvoiceList");
            }
            else
            {
                ViewBag.ProcessCondition = 1;
                return View();
            }
        }

        public ActionResult InvoiceList()
        {
            List<InvoiceDTO> model = db.Invoices.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Update).Select(x => new InvoiceDTO
            {
                ID = x.ID,
                InvoiceDate = x.InvoiceDate,
                InvoiceName = x.InvoiceName,                
                AppUserID = x.AppUserID,
                
            }).ToList();

            return View(model);
        }

        public ActionResult UpdateInvoice(int id)
        {
            InvoiceVM model = new InvoiceVM();
            Invoice invoice = db.Invoices.FirstOrDefault(x => x.ID == id);
            model.Invoice.ID = invoice.ID;
            model.Invoice.InvoiceDate = invoice.InvoiceDate;
            model.Invoice.InvoiceName = invoice.InvoiceName;
           

            List<AppUser> appusermodel = db.AppUsers.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Update).ToList();

            model.AppUsers = appusermodel;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateInvoice(InvoiceDTO model)
        {
            if (ModelState.IsValid)
            {
                Invoice invoice = db.Invoices.FirstOrDefault(x => x.ID == model.ID);
                invoice.InvoiceDate = model.InvoiceDate;
                invoice.InvoiceName = model.InvoiceName;               
                invoice.AppUserID = model.AppUserID;

                db.SaveChanges();
                return Redirect("/Admin/Invoice/InvoiceList");
            }
            else
            {
                return View();
            }
        }
        public ActionResult DeleteInvoice(int id)
        {
            if (ModelState.IsValid)
            {
                Invoice invoice = db.Invoices.FirstOrDefault(x => x.ID == id);
                invoice.Status = InvoicePayment.Model.Enum.Status.Delete;
                invoice.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/Invoice/InvoiceList");
            }
            return View();
            // return Redirect("/Admin/Product/ProductList");
        }
    }
}