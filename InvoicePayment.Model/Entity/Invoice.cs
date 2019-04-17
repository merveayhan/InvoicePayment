using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicePayment.Model.Entity
{
    public class Invoice:BaseEntity
    {
        public string InvoiceName { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
