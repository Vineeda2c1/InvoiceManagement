using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvoiceManagementNew.Models
{
    public class LoginModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required.")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string UserType { get; set; }
        public string NewPassword { get; set; }

       
    }
}