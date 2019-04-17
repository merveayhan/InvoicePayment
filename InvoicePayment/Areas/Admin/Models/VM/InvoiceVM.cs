using InvoicePayment.Areas.Admin.Models.DTO;
using InvoicePayment.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePayment.Areas.Admin.Models.VM
{
    public class InvoiceVM
    {
        public InvoiceVM()
        {
            AppUsers = new List<AppUser>();
            Invoice = new InvoiceDTO();
        }
        public List<AppUser> AppUsers { get; set; }
        public InvoiceDTO Invoice { get; set; }
    }
}