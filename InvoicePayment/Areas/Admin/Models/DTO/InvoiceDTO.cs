using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoicePayment.Areas.Admin.Models.DTO
{
    public class InvoiceDTO:BaseDTO
    {
        public string InvoiceName { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int AppUserID { get; set; }
    }
}