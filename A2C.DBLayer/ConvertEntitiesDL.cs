
using A2C.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2C.DBLayer
{
    public class ConvertEntitiesDL
    {
      public DataTable ConvertNewSerialListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("GulfNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("MakeName");
            dt.Columns.Add("ModelName");
            dt.Columns.Add("ProcessorName");
            dt.Columns.Add("RevisedPurchasePrice");
            dt.Columns.Add("ProjectName");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;

            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["GulfNo"] = array.GulfNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;

                Order["MakeName"] = array.MakeName;
                Order["ModelName"] = array.ModelName;
                Order["ProcessorName"] = array.ProcessorName;
                Order["RevisedPurchasePrice"] = array.PurchasePrice;
                Order["ProjectName"] = array.ProjectName;

                dt.Rows.Add(Order);
            }

            return dt;
        }

        public DataTable ConvertOkUploadListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("OrderNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["OrderNo"] = array.OrderNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;

                dt.Rows.Add(Order);
            }

            return dt;
        }

        public DataTable ConvertPackageUploadListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("OrderNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("CommonColumn");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["OrderNo"] = array.OrderNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;
                Order["CommonColumn"] = array.Grade;

                dt.Rows.Add(Order);
            }

            return dt;
        }
        public DataTable ConvertSaleUploadListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("OrderNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("InvoiceNo");
            dt.Columns.Add("SoldPrice");
            dt.Columns.Add("SoldDate");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;

            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["OrderNo"] = array.OrderNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;
                Order["InvoiceNo"] = array.InvoiceNo;
                Order["SoldPrice"] = array.SoldPrice;
                Order["SoldDate"] = array.SoldDate;

                dt.Rows.Add(Order);
            }

            return dt;
        }
        public DataTable ConvertCommentUploadListToDataTable(List<OrderInvoiceEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("OrderNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("Comment");
           
            //dt.Columns.Add("CreatedBy");

            DataRow Order;

            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["OrderNo"] = array.OrderNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;
                Order["Comment"] = array.Comment;
               
                dt.Rows.Add(Order);
            }

            return dt;
        }

        public DataTable ConvertPurchaseUploadListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("GulfNo");
            dt.Columns.Add("MakeName");
            dt.Columns.Add("ModelName");
            dt.Columns.Add("ProcessorName");
            dt.Columns.Add("PurchaseQty");
            dt.Columns.Add("PurchasePrice");
            dt.Columns.Add("PurchaseDate");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["GulfNo"] = array.GulfNo;
                Order["MakeName"] = array.MakeName;
                Order["ModelName"] = array.ModelName;
                Order["ProcessorName"] = array.ProcessorName;
                Order["PurchaseQty"] = array.PurchaseQty;
                Order["PurchasePrice"] = array.PurchasePrice;
                Order["PurchaseDate"] = array.PurchaseDate;

                dt.Rows.Add(Order);
            }

            return dt;
        }

        public DataTable ConvertPurchaseOrderListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("GulfNo");
            dt.Columns.Add("MakeId");
            dt.Columns.Add("ModelId");
            dt.Columns.Add("ProcessorId");
            dt.Columns.Add("PurchasedQty");
            dt.Columns.Add("PurchasedPrice");
            dt.Columns.Add("PurchasedDate");
            dt.Columns.Add("ProjectId");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["GulfNo"] = array.GulfNo;
                Order["MakeId"] = array.MakeId;
                Order["ModelId"] = array.ModelId;
                Order["ProcessorId"] = array.ProcessorId;
                Order["PurchasedQty"] = array.PurchaseQty;
                Order["PurchasedPrice"] = array.PurchasePrice;
                Order["PurchasedDate"] = array.PurchaseDate;
                Order["ProjectId"] = array.ProjectId;

                dt.Rows.Add(Order);
            }

            return dt;
        }


        #region InvoiceOrder

        public DataTable ConvertInvoiceOrderListToDataTable(List<OrderInvoiceEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("InvoiceNo");
            dt.Columns.Add("UserName");
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("InvoiceDate");
            dt.Columns.Add("DeliveryDate");
            dt.Columns.Add("InvoiceAmt");
            dt.Columns.Add("InvoiceType");
            dt.Columns.Add("UploadImage");

            //dt.Columns.Add("CreatedBy");

            DataRow Invoice;


            // Add rows.
            foreach (var array in list)
            {
                Invoice = dt.NewRow();

                lineNo = lineNo + 1;

                Invoice["InvoiceNo"] = array.InvoiceNo;
                Invoice["UserName"] = array.UserName;
                Invoice["CustomerName"] = array.CustomerName;
                Invoice["InvoiceDate"] = array.InvoiceDate;
                Invoice["DeliveryDate"] = array.deliverydate;
                Invoice["InvoiceAmt"] = array.InvoiceAmount;
                Invoice["InvoiceType"] = array.InvoiceType;
                Invoice["UploadImage"] = array.UploadFileName;
                dt.Rows.Add(Invoice);
            }

            return dt;
        }

        public DataTable ConvertInvoiceETAListToDataTable(List<OrderInvoiceEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("INVOrderNo");
            dt.Columns.Add("ETADATE");
           


            //dt.Columns.Add("CreatedBy");

            DataRow Invoice;


            // Add rows.
            foreach (var array in list)
            {
                Invoice = dt.NewRow();

                lineNo = lineNo + 1;
                Invoice["INVOrderNo"] = array.InvOrderNo;
                Invoice["ETADATE"] = array.ETADate;
               
               
                dt.Rows.Add(Invoice);
            }

            return dt;
        }
        public DataTable ConvertInvoicCommentListToDataTable(List<OrderInvoiceEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("INVTransId");
            dt.Columns.Add("Comment");



            //dt.Columns.Add("CreatedBy");

            DataRow Invoice;


            // Add rows.
            foreach (var array in list)
            {
                Invoice = dt.NewRow();

                lineNo = lineNo + 1;
                Invoice["INVTransId"] = array.TransactionId;
                Invoice["Comment"] = array.InvComment;


                dt.Rows.Add(Invoice);
            }

            return dt;
        }
        public DataTable ConvertInvoiceUploadListToDataTable(List<OrderInvoiceEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("INVOrderNo");
            dt.Columns.Add("UploadFile");



            //dt.Columns.Add("CreatedBy");

            DataRow Invoice;


            // Add rows.
            foreach (var array in list)
            {
                Invoice = dt.NewRow();

                lineNo = lineNo + 1;
                Invoice["INVOrderNo"] = array.InvOrderNo;
                Invoice["UploadFile"] = array.UploadFileName;


                dt.Rows.Add(Invoice);
            }

            return dt;
        }
        public DataTable ConvertInvoiceOrderUpdateListToDataTable(List<OrderInvoiceEntity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("InvOrderNo");
            dt.Columns.Add("RecieveAmt");
            dt.Columns.Add("AmtType");
            dt.Columns.Add("ChequeNo");
            dt.Columns.Add("Chequedate");
            dt.Columns.Add("ReciveDate");
            dt.Columns.Add("AdjustmentValue");
            dt.Columns.Add("Comment");
            //dt.Columns.Add("CreatedBy");

            DataRow Invoice;


            // Add rows.
            foreach (var array in list)
            {
                Invoice = dt.NewRow();

                lineNo = lineNo + 1;

              
                Invoice["InvOrderNo"] = array.InvOrderNo;
                Invoice["RecieveAmt"] = array.RecieveAmt;
                Invoice["AmtType"] = array.InvType;
                Invoice["ChequeNo"] = array.ChequeNo;
                Invoice["Chequedate"] = array.Chequedate;
                Invoice["ReciveDate"] = array.RecivingDate;
                Invoice["AdjustmentValue"] = array.AdjustmentValue;
                Invoice["Comment"] = array.InvComment;
                dt.Rows.Add(Invoice);
            }

            return dt;
        }
        #endregion
        #region ProcessOrder
        //public DataTable ConvertSerialNoToDataTable(List<ProcessOrderEntity> list)
        //{
        //    int lineNo = 0;

        //    DataTable dt = new DataTable();
        //    dt.Clear();
        //    dt.Columns.Add("OrderLineNo");
        //    dt.Columns.Add("InhouseSerialNo");
        //    dt.Columns.Add("SalesPricePerPiece");

        //    DataRow Order;


        //    // Add rows.
        //    foreach (var array in list)
        //    {
        //        Order = dt.NewRow();

        //        lineNo = lineNo + 1;

        //        Order["OrderLineNo"] = lineNo;
        //        Order["InhouseSerialNo"] = array.InhouseSerialNo;
        //        Order["SalesPricePerPiece"] = array.SalesPricePerPiece;

        //        dt.Rows.Add(Order);
        //    }

        //    return dt;
        //}

        #endregion
    }
}
