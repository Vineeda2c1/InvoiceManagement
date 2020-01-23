
using System;
using A2C.BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.Security;
using A2C.BusinessEntity;
using InvoiceManagementNew.Models;
using System.IO;
using System.Web.UI;
using System.Web.Helpers;

namespace InvoiceManagementNew.Controllers
{
    public class HomeController : Controller
    {
        public static string Username;
        public static string Password;

        //   [Authorize]


        public ActionResult UserLogin(LoginModel loginObj, string returnUrl)
        {
            try
            {

                LoginBL loginBl = new LoginBL();
                LoginEntity loginEntity = new LoginEntity();
                LoginEntity newloginEntity = new LoginEntity();
                Roles_Model rm = new Roles_Model();
                LoginModel loginmodel = new LoginModel();
                int i = 0;
                if (ModelState.IsValid)
                {
                    loginEntity.UserName = loginObj.UserName;
                    loginEntity.Password = loginObj.Password;
                    i = loginBl.UserLoginCheck(loginEntity);
                    if (i == 1)
                    {
                        newloginEntity = loginBl.GetUserDetails(loginEntity);
                        Session["Username"] = newloginEntity.UserName;
                        Session["UserType"] = newloginEntity.UserType;
                        Session["Password"] = newloginEntity.Password;
                        Session["UserPage"] = newloginEntity.Userpage;
                        Session["Controler_Name"] = newloginEntity.ActionName;
                        Session["UserID"] = Convert.ToString(newloginEntity.UserId);
                        string Loginame = Request.Form["UserName"].ToString();
                        Username = Session["Username"].ToString();
                        Password = Session["Password"].ToString();
                        if (Loginame.ToUpper() == Username.ToUpper())
                        {
                            FormsAuthentication.SetAuthCookie(Session["Username"].ToString(), true);
                            var Toppage = loginBl.GetTopPageMenu(Session["Username"].ToString());
                            return Redirect(returnUrl ?? Url.Action(Toppage.Userpage, Toppage.ActionName));

                        }
                    }
                    ModelState.AddModelError("", "Incorrect Username and Password");
                    Session["Username"] = "";
                    Session["Password"] = "";
                    Session["UserType"] = "";
                    Session["UserId"] = "";
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }

            }
            catch (Exception ex)
            {

            }

            return View("LoginPage");
        }
        public ActionResult LoginPage()
        {

            return View();


        }
        [AuthorizedUserAcessLevel]
        public ActionResult UserSetting()
        {

            return View("UserSetting");
        }
        [AuthorizedUserAcessLevel]
        [HttpGet]
        public ActionResult Orderinvoice()
        {
            AddSerialBL obj = new AddSerialBL();
            List<InvoiceDetailsModel> Olist = new List<InvoiceDetailsModel>();

            List<OrderInvoiceEntity> Oent = obj.Getinvoicedetails();

            InvoiceDetailsModel ordobj;

            if (Oent != null)
            {
                foreach (OrderInvoiceEntity item in Oent)
                {
                    ordobj = new InvoiceDetailsModel();
                    ordobj.InvOrderNo = item.InvOrderNo;
                    ordobj.InvoiceNo = item.InvoiceNo;
                    ordobj.InvoiceType = item.InvoiceType;
                    ordobj.CustomerName = item.CustomerName;
                    ordobj.InvoiceDate = item.InvoiceDate;
                    ordobj.deliverydate = item.deliverydate;
                    ordobj.ETADate = item.ETADate;
                    ordobj.InvoiceAmount = item.InvoiceAmount;
                    ordobj.PendingAmount =Convert.ToDecimal(item.InvoiceAmount) - Convert.ToDecimal(item.RecieveAmt);
                    ordobj.RecieveAmt = item.RecieveAmt;
                    ordobj.PendingDays = item.PendingDays;
                    ordobj.UploadFile = item.UploadFileName.ToLower();
                    if (ordobj.UploadFile.IndexOf("jpeg") > 0)
                    {
                        ordobj.Icon = "Jpeg.png";
                    }
                    else
                    if (ordobj.UploadFile.IndexOf("jpg") > 0)
                    {
                        ordobj.Icon = "Jpeg.png";
                    }
                    else
                  if (ordobj.UploadFile.IndexOf("pdf") > 0)
                    {
                        ordobj.Icon = "download.png";
                    }
                    else
                  if (ordobj.UploadFile.IndexOf("xlsx") > 0)
                    {
                        ordobj.Icon = "Excel.jpg";
                    }
                    else
                    if (ordobj.UploadFile.IndexOf("xls") > 0)
                    {
                        ordobj.Icon = "Excel.jpg";
                    }
                    else
                    {
                        ordobj.Icon = "Unknown.png";
                    }
                    Olist.Add(ordobj);

                }

            }

            return View(Olist);


        }
        [AuthorizedUserAcessLevel]
        public ActionResult InvoiceDetails()
        {
            AddSerialBL obj = new AddSerialBL();
            List<InvoiceDetailsModel> Olist = new List<InvoiceDetailsModel>();

            List<OrderInvoiceEntity> Oent = obj.GetInvoiceStatus();

            InvoiceDetailsModel ordobj;

            if (Oent != null)
            {
                foreach (OrderInvoiceEntity item in Oent)
                {
                    ordobj = new InvoiceDetailsModel();
                    ordobj.InvOrderNo = item.InvOrderNo;
                    ordobj.Status_id = item.status_id;
                    ordobj.InvoiceNo = item.InvoiceNo;
                    ordobj.InvoiceType = item.InvoiceType;
                    ordobj.CustomerName = item.CustomerName;
                    ordobj.InvoiceDate = item.InvoiceDate;
                    ordobj.RecivingDate = item.RecivingDate;
                    ordobj.InvoiceAmount = item.InvoiceAmount;
                    ordobj.PendingAmount = Convert.ToDecimal(item.InvoiceAmount) - Convert.ToDecimal(item.RecieveAmt);
                    ordobj.UploadFile = item.UploadFileName.ToLower();

                    if (ordobj.UploadFile.IndexOf("jpeg") > 0)
                    {
                        ordobj.Icon = "Jpeg.png";
                    }
                    else
                   if (ordobj.UploadFile.IndexOf("jpg") > 0)
                    {
                        ordobj.Icon = "Jpeg.png";
                    }
                    else
                 if (ordobj.UploadFile.IndexOf("pdf") > 0)
                    {
                        ordobj.Icon = "download.png";
                    }
                    else
                 if (ordobj.UploadFile.IndexOf("xlsx") > 0)
                    {
                        ordobj.Icon = "Excel.jpg";
                    }
                    else
                   if (ordobj.UploadFile.IndexOf("xls") > 0)
                    {
                        ordobj.Icon = "Excel.jpg";
                    }
                    else
                    {
                        ordobj.Icon = "Unknown.png";
                    }

                    ordobj.RecieveAmt = item.RecieveAmt;
                    ordobj.InvComment = item.InvComment;
                    Olist.Add(ordobj);

                }

            }

            return View(Olist);


        }


        public JsonResult InvoiceImageUpload(ImageUploadModel modal)
        {
           
            AddSerialBL obj = new AddSerialBL();
            ImageUpload entity = new ImageUpload();
            if (ModelState.IsValid)
            {
                entity.ImageFile = modal.ImageFile;
                entity.ImageType = modal.ImageType;
                string imagepath = Path.Combine(Server.MapPath("~/Content/InvoiceImages"));
                entity.path = imagepath;
                if (!Directory.Exists(imagepath))
                {
                    Directory.CreateDirectory(imagepath);
                }
                if (modal.UploadImage != null)
                {
                    string fileName = Path.GetFileName(modal.ImageFile);
                    modal.UploadImage.SaveAs(imagepath + fileName);

                }
            }
         

            var result = obj.AddImageUpload(entity);
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public ActionResult OrderinvoiceUser(string Username)
        {
            AddSerialBL obj = new AddSerialBL();
            var result = obj.GetinvoiceByUser(Username);
            return Json(result, JsonRequestBehavior.AllowGet);
       }
        public ActionResult CommentRoles(string Username)
        {
            AddSerialBL obj = new AddSerialBL();
            var result = obj.GetCommentbyRoles(Username);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckReceiveAmt(int ReceiveOrderId, decimal AdjustedAmt, decimal ReceiveAmt)
        {
            AddSerialBL obj = new AddSerialBL();
            var result = obj.CheckReceiveAmt(ReceiveOrderId, AdjustedAmt, ReceiveAmt);
            return Json(result, JsonRequestBehavior.AllowGet);


        }

        public ActionResult InvoiceTransactionDetails(string OrderNo)
        {
            AddSerialBL obj = new AddSerialBL();
            var result = obj.GetTransactiondetails(OrderNo);
            return Json(result, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        //    public ActionResult  OrderInvoice(List<OrderInvoiceEntity> Invoicedetails)
        public ActionResult OrderInvoice(List<OrderInvoiceEntity> Invoicedetails )
        {
            string fileName="";
            string path = Server.MapPath("~/Content/Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files["postedFile"];
                    if (file != null && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                         fileName = file.FileName;
                        //string fileName = Path.GetFileName(invoicemodel.UploadImage.FileName);
                        //string invstatus = Request.Form["uploadType"].ToString();
                        file.SaveAs(Path.Combine (path,fileName));
                    }
                }
            }
            catch(Exception ex)
            {
                string msg= ex.Message;
            }
            List<OrderInvoiceEntity> ulist = new List<OrderInvoiceEntity>();
            OrderInvoiceEntity ent;
         //   var Invorderno = Invoicedetails.ToArray();
            ent = new OrderInvoiceEntity();
            ent.InvOrderNo = Convert.ToInt32( Request.Form["UploadInvOrderNo"]);
            ent.UploadFileName = fileName.ToString();
            ulist.Add(ent);

            AddSerialBL obj = new AddSerialBL();
            int value = obj.AddUploadInvoiceFile(ulist);

            if (value==1)
            {
                Response.Write("<script>alert('Updated successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Not Updated successfully')</script>");
            }

            return (RedirectToAction("OrderInvoice"));

        }
        public ActionResult AddInvoiceOrder(List<OrderInvoiceEntity> Invoicedetails, FormCollection formCollection)
        {
          
            AddSerialBL obj = new AddSerialBL();
            return Json(obj.AddNewInvoice(Invoicedetails), JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddComment(List<OrderInvoiceEntity> InvoiceComment)
        {


            AddSerialBL obj = new AddSerialBL();
            return Json(obj.AddComment(InvoiceComment), JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddETA(List<OrderInvoiceEntity> InvoiceETA)
        {


            AddSerialBL obj = new AddSerialBL();
            return Json(obj.AddETA(InvoiceETA), JsonRequestBehavior.AllowGet);

        }
        public ActionResult AcceptInvoicedetails(int Statusid)
        {


            AddSerialBL obj = new AddSerialBL();
            return Json(obj.AcceptInvoicedetails(Statusid), JsonRequestBehavior.AllowGet);

        }
        
        public ActionResult UpdateUserDetail(LoginModel user)
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("LoginPage");
            }
            LoginBL paintBl = new LoginBL();

            LoginEntity loginentity = new LoginEntity();

            loginentity.UserId = user.UserId;
            loginentity.UserName = user.UserName;
            loginentity.NewPassword = user.NewPassword;
            loginentity.Password = user.Password;
            int i = paintBl.UpdateUserDetail(loginentity);
            if (i == 1)
            {
                Session["Username"] = string.Empty;
                Session["Password"] = string.Empty;

                Session["Password"] = user.NewPassword;

                Session["Username"] = user.UserName;

            }


            return Json(i, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddInvoiceDetails(List<OrderInvoiceEntity> Invoicedetails)
        {


            AddSerialBL obj = new AddSerialBL();
            return Json(obj.AddInvoiceDetails(Invoicedetails), JsonRequestBehavior.AllowGet);



        }
        [AuthorizedUserAcessLevel]
        public ActionResult Index()
        {
            Session["Username"] = "";
            Session["Orderno"] = "";
            return View();
        }
        public ActionResult PageNotfound()
        {
            return View();
        }
        public ActionResult Reports()
        {

            return View();


        }
        public ActionResult Logout()
        {
            //    clsDispose_Fin objClass = new clsDispose_Fin();
            try
            {
                Session["Username"] = null;
                Session["Password"] = null;
                Session["UserType"] = null;
                Session["UserId"] = null;
                FormsAuthentication.SignOut();
                Session.Abandon();
                System.Web.HttpContext.Current.Application.Remove(System.Web.HttpContext.Current.User.Identity.Name);
                Session.RemoveAll();
            }
            catch (Exception ex)
            { }
            //finally
            //{
            //    if (objClass != null)
            //        ((IDisposable)objClass).Dispose();
            //}
            return RedirectToAction("LoginPage");
        }
    }
}