using System;
using A2C.BusinessLayer;
using A2C.BusinessEntity;
using System.Collections.Generic;
using InvoiceManagementNew.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManagementNew.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CompleteETA(FormCollection formCollection)
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
                    ordobj.InvoiceNo = item.InvoiceNo;
                    ordobj.InvoiceType = item.InvoiceType;
                    ordobj.CustomerName = item.CustomerName;
                    ordobj.InvoiceDate = item.InvoiceDate;
                    ordobj.RecivingDate = item.RecivingDate;
                    ordobj.InvoiceAmount = item.InvoiceAmount;
                    ordobj.PendingAmount = Convert.ToDecimal(item.InvoiceAmount) - Convert.ToDecimal(item.RecieveAmt);
                    ordobj.RecieveAmt = item.RecieveAmt;
                    Olist.Add(ordobj);

                }

             
            }
            return View(Olist);
        }
        public ActionResult Report()
        {
            return View();
        }
    }
}