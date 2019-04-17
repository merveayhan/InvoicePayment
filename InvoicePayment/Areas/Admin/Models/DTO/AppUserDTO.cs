using InvoicePayment.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoicePayment.Areas.Admin.Models.DTO
{
    public class AppUserDTO:BaseDTO
    {
        [Required(ErrorMessage = "Please add your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please add your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please add your user name")]
        public string UserName { get; set; }     
        [Required(ErrorMessage = "Please add your password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please add your phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please choose a user role")]
        public Role Role { get; set; }
        

    }
}