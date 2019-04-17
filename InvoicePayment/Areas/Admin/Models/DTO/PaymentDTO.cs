using InvoicePayment.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePayment.Areas.Admin.Models.DTO
{
    public class PaymentDTO:BaseDTO
    {
        public InvoiceType InvoiceType { get; set; }
        public string IdentificationNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InvoiceAmount { get; set; }

        public int AppUserID { get; set; }
    }
}