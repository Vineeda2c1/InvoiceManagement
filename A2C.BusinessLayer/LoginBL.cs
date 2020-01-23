
using A2C.BusinessEntity;
using A2C.DBLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2C.BusinessLayer
{
  public class LoginBL
    {
        public int UserLoginCheck(LoginEntity entity)
        {
            LoginDAL paintdal = new LoginDAL();
            return paintdal.UserLoginCheck(entity);
        }
        public LoginEntity GetUserDetails(LoginEntity entity)
        {
            LoginDAL paintdal = new LoginDAL();
            return paintdal.GetUserDetails(entity);
        }
        public LoginEntity GetUserType(LoginEntity entity)
        {
            LoginDAL paintdal = new LoginDAL();
            return paintdal.GetUserType(entity);
        }
        public int UpdateUserDetail(LoginEntity entity)
        {
            LoginDAL paintdal = new LoginDAL();
            return paintdal.UpdateUserDetail(entity);
        }
        public List<Roles_Model> GetUserroles(string username)
        {
            LoginDAL getrole = new LoginDAL();
            return getrole.GetUserRoles(username);
        }
        public List<Roles_Model> GetPagebyroles(string username, string User_type)
        {
            LoginDAL getrole = new LoginDAL();
            return getrole.GetUser_Roles(username, User_type);
        }
        public List<Roles_Model> Get_AllPagesName(string username)
        {
            LoginDAL getrole = new LoginDAL();
            return getrole.Get_AllPagesName(username);
        }
      
        public List<Roles_Model> GetUserbyroles(string username)
        {
            LoginDAL getrole = new LoginDAL();
            return getrole.GetUserbyRoles(username);
        }
        public LoginEntity GetTopPageMenu(string username)
        {
            LoginDAL getPage = new LoginDAL();
            return getPage.GetTopMenu(username);
        }
    }
}
