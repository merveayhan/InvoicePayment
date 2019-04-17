using InvoicePayment.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicePayment.Model.Entity
{
    public class AppUser:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }


        public virtual List<Payment> Payments { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }
}
