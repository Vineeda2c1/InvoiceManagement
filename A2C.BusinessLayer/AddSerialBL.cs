using A2C.BusinessEntity;
using A2C.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2C.BusinessLayer
{
    public class AddSerialBL
    {




        public int AddNewInvoice(List<OrderInvoiceEntity> ent)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AddNewInvoice(ent);
        }
        public int AcceptInvoicedetails(int Statusid)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AcceptInvoicedetails(Statusid);
        }
        public int AddInvoiceDetails(List<OrderInvoiceEntity> ent)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AddInvoiceDetails(ent);
        }
        public int AddComment(List<OrderInvoiceEntity> ent)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AddComment(ent);
        }
        public int AddUploadInvoiceFile(List<OrderInvoiceEntity> ent)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AddUploadInvoiceFile(ent);
        }
        public int AddETA(List<OrderInvoiceEntity> ent)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AddETA(ent);
        }
        public int AddImageUpload(ImageUpload ent)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.AddImageUpload(ent);
        }
        public List<OrderInvoiceEntity> Getinvoicedetails()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.Getinvoicedetails();
        }
        public List<OrderInvoiceEntity> GetInvoiceStatus()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetInvoiceStatus();
        }
        public List<OrderInvoiceEntity> GetInvReportbyETA()
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetInvoiceStatus();
        }
        public List<OrderInvoiceEntity> GetTransactiondetails( string OrderNo)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetTransactiondetails(OrderNo);
        }
        public List<OrderInvoiceEntity> GetinvoiceByUser(string Username)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetinvoiceByUser(Username);
        }
        public List<OrderInvoiceEntity> GetCommentbyRoles(string Username)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.GetCommentbyRoles(Username);
        }
        public List<OrderInvoiceEntity> CheckReceiveAmt(int ReceiveOrderId, decimal AdjustedAmt, decimal ReceiveAmt)
        {
            AddSerialDL productdal = new AddSerialDL();
            return productdal.CheckReceiveAmt(ReceiveOrderId,AdjustedAmt,ReceiveAmt);
        }

    }
}
