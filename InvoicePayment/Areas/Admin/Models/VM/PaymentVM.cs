using InvoicePayment.Areas.Admin.Models.DTO;
using InvoicePayment.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePayment.Areas.Admin.Models.VM
{
    public class PaymentVM
    {
        public PaymentVM()
        {
            AppUsers = new List<AppUser>();
            Payment = new PaymentDTO();
        }
        public List<AppUser> AppUsers { get; set; }
        public PaymentDTO Payment { get; set; }
    }
}