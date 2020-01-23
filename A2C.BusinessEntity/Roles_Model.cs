using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2C.BusinessEntity
{
    public class Roles_Model
    {
        public int User_id { get; set; }
        public string User_type { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Page_name { get; set; }
        public string ActionName { get; set; }
        public string MenuLink { get; set; }

    }
}