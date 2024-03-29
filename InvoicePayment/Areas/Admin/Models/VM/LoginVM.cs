﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoicePayment.Areas.Admin.Models.VM
{
    public class LoginVM
    {

        [
            EmailAddress(ErrorMessage = "You enter wrong email"),
            Required(ErrorMessage = "Please enter email address"),
            DisplayName("E-Posta")
        ]

        public string UserName { get; set; }
        [
            Required(ErrorMessage = "Please enter email address"),
             DisplayName("Password")
        ]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}