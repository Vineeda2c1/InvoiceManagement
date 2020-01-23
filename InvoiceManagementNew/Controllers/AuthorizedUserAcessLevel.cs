
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Routing;
using A2C.BusinessEntity;
using A2C.BusinessLayer;

namespace System.Web.Mvc
{
    public  class AuthorizedUserAcessLevel:AuthorizeAttribute
    {
        public static string UserRoles { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
     
            var list="";
            LoginBL loginBl = new LoginBL();
            List <Roles_Model> rol = new List<Roles_Model>();
            List<Roles_Model> Pages = new List<Roles_Model>();
            Roles_Model findpage;
            Roles_Model obj = new Roles_Model();
            
            var isAuthorised= base.AuthorizeCore(httpContext);
            if (isAuthorised ==false)
            {
                return false;
            }
            string CurrentUser = HttpContext.Current.User.Identity.Name.ToString();
            if (CurrentUser != null &&  CurrentUser!=" ")

            { 
            var rd = httpContext.Request.RequestContext.RouteData;
            string currentAction = rd.GetRequiredString("action");
            string currentController = rd.GetRequiredString("controller");

            rol= loginBl.GetUserroles(CurrentUser);
            string[] UR = new string[1];
            foreach ( Roles_Model item in rol)
            { 
         
            UR[0] = item.User_type.ToString();
       
            }
            Pages = loginBl.GetPagebyroles(CurrentUser, UR[0].ToString());
            int i = 0;
            if (Pages !=null)
            {
                string[] arrpage = new string[Pages.Count];
                foreach (Roles_Model itm in Pages)
                {
                   arrpage[i] = itm.Page_name.ToString();
                    //findpage = new Roles_Model();
                    //findpage.Page_name = item.Page_name;
                    i++;
                }
              list=  Array.Find(arrpage,
                      element => element.StartsWith(currentAction,
                      StringComparison.Ordinal));

            }
           
          
           
             if (list ==currentAction)
                { return true; }
            else { return false; }

            }
            else
            {
                return false;

            }
            //return isAuthorised;
        } 

    }


}
