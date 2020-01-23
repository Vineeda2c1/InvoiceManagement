using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2C.BusinessEntity
{
   public class LoginEntity
    {
        public int  UserId { get; set; }
        public string User_Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string UserType { get; set; }
        public string NewPassword { get; set; }
        public string Userpage { get; set; }
        public string ActionName { get; set; }

        public string Menu_Name { get; set; }
    }
}
