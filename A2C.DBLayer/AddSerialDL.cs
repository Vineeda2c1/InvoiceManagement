

using A2C.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2C.DBLayer
{
    public class AddSerialDL
    {
        string cs = ConfigurationManager.ConnectionStrings["A2CConnectionString"].ToString();

        #region PurchaseOrder
        public List<SerialNumberEnity> GetPurchaseDetail()
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetPurchaseOrder", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.GulfNo = dr["GulfNo"].ToString();
                            serialentity.PurchaseQty = Convert.ToInt32(dr["Qty"]);
                            serialentity.ReceivedQty = Convert.ToInt32(dr["ReceivedQty"]);
                            serialentity.SCreatedDate = dr["CreatedDate"].ToString();
                            serialentity.Type = Convert.ToInt32(dr["Type"]);
                            


                            serialentityList.Add(serialentity);

                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }
        public int AddNewInvoice(List<OrderInvoiceEntity> entity)
        {
            

            ConvertEntitiesDL obj = new ConvertEntitiesDL();
            DataTable table = obj.ConvertInvoiceOrderListToDataTable(entity);
            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spInsertInvoiceDetails", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlParameter customrId = cmd.Parameters.AddWithValue("@tblInvoice", table); 
                    return (int)cmd.ExecuteScalar();

                }
            }


        }
        public int AddComment(List<OrderInvoiceEntity> entity)
        {
           

            ConvertEntitiesDL obj = new ConvertEntitiesDL();
            DataTable table = obj.ConvertInvoicCommentListToDataTable(entity);

           
            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateInvoiceComment", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlParameter customrId = cmd.Parameters.AddWithValue("@INVOICETRANSID", table.Rows[0][0].ToString());
                    SqlParameter Comment = cmd.Parameters.AddWithValue("@INVOICECOMMENT", table.Rows[0][1].ToString());
                    return (int)cmd.ExecuteScalar();

                }
            }

            
        }
        

             public int AddUploadInvoiceFile(List<OrderInvoiceEntity> entity)
             {
  
               ConvertEntitiesDL obj = new ConvertEntitiesDL();
               DataTable table = obj.ConvertInvoiceUploadListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateInvoiceOrderUpload", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlParameter customrId = cmd.Parameters.AddWithValue("@INVOICEORDERNO", table.Rows[0][0].ToString());
                    SqlParameter Comment = cmd.Parameters.AddWithValue("@UPLOADFILENAME", table.Rows[0][1].ToString());
                    return (int)cmd.ExecuteScalar();

                }
            }


        }


        public int AddETA(List<OrderInvoiceEntity> entity)
        {
          

            ConvertEntitiesDL obj = new ConvertEntitiesDL();
            DataTable table = obj.ConvertInvoiceETAListToDataTable(entity);


            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateEtaInvoiceOrder", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlParameter INVOrderNo = cmd.Parameters.AddWithValue("@INVOrderNo", table.Rows[0][0].ToString());
                    SqlParameter ETADate = cmd.Parameters.AddWithValue("@ETADATE", table.Rows[0][1].ToString()); 

                    return (int)cmd.ExecuteScalar();

                }
            }



        }


        public int AddImageUpload(ImageUpload entity)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@Filename", entity.ImageFile);
                cmd.Parameters.AddWithValue("@FilePath", entity.path);

                return (int)cmd.ExecuteNonQuery();
            }
        }
        public int AcceptInvoicedetails(int Statusid)
        {


            ConvertEntitiesDL obj = new ConvertEntitiesDL();
            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("Sp_UpdateInvoiceStatusDetails", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlParameter customrId = cmd.Parameters.AddWithValue("@Statusid", Statusid);
                    return (int)cmd.ExecuteScalar();

                }
            }


        }
        public int AddInvoiceDetails(List<OrderInvoiceEntity> entity)
        {
            int value = 0;
            try
            {
                // int i = 0;
                ConvertEntitiesDL obj = new ConvertEntitiesDL();
                DataTable table = obj.ConvertInvoiceOrderUpdateListToDataTable(entity);

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("[spUpdateInvoiceDetails]", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter customrId = cmd.Parameters.AddWithValue("@tblInvoiceUpdate", table);
                    value = Convert.ToInt32(cmd.ExecuteScalar());



                }
            }
            catch (Exception ex)
            {

            }
            return value;
        }

        public int AddNewPurchase(List<SerialNumberEnity> entity,int Category)
        {
            // int i = 0;
            ConvertEntitiesDL obj = new ConvertEntitiesDL();
            DataTable table = obj.ConvertPurchaseOrderListToDataTable(entity);

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("[spInsertPurchaseOrder]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                SqlParameter customrId = cmd.Parameters.AddWithValue("@tblEmp",table);
                SqlParameter category = cmd.Parameters.AddWithValue("@Category", Category);



                return (int)cmd.ExecuteScalar();

            }
        }
        public int UpdateReceivedQty(int ReceiveOrderId, string Gulf, int Received, string ReceiveDate)
        {

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spUpdateReceivedQty", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();


                    cmd.Parameters.AddWithValue("@ReceiveOrderId", ReceiveOrderId);
                    cmd.Parameters.AddWithValue("@Gulf", Gulf);
                    cmd.Parameters.AddWithValue("@Received", Received);
                    cmd.Parameters.AddWithValue("@ReceiveDate", ReceiveDate);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

        public int ReceiveAll(string Gulf)
        {
            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spReceiveAllQty", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    cmd.Parameters.AddWithValue("@Gulf", Gulf);
              
                    return (int)cmd.ExecuteScalar();

                }
            }
        }

      

        #endregion
       

       
     
        public int ReleaseStockFromProduction(List<SerialNumberEnity> entity)
        {
            // int i = 0;
            //SerialNumberEnity serialentity;
            //List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            DataTable table = ConvertReleasefromProdListToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spReleaseStockFromProduction", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

        static DataTable ConvertReleasefromProdListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
            dt.Columns.Add("IssueName");

            //dt.Columns.Add("CreatedBy");

            DataRow Order;


            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();

                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;
                Order["IssueName"] = array.IssueName;

                dt.Rows.Add(Order);
            }

            return dt;
        }

      
        public int ReleaseForTestingWorkShop(List<SerialNumberEnity> entity,string Flag)
        {
            // int i = 0;
            //SerialNumberEnity serialentity;
            //List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            DataTable table = ConvertReleasefromProdListToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spReleaseforWorkShopandTesting", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }
      

        public int AcceptInWorkshop(string InhouseSerialNo, string Ordernumber,string IssueName,string Flag)
        {
            // int i = 0;
            //SerialNumberEnity serialentity;
            //List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            //DataTable table = ConvertReleasefromProdListToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spAcceptInWorkshop", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter Inhouse = cmd.Parameters.AddWithValue("@InhouseSerialNo", InhouseSerialNo);
                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);
                    SqlParameter order = cmd.Parameters.AddWithValue("@OrderNo", Ordernumber);
                    SqlParameter Issue = cmd.Parameters.AddWithValue("@IssueName", IssueName);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

      
        public List<SerialNumberEnity> GetAllMakeProductData(int id, string Flag)
        {
            SerialNumberEnity productDetail;
            List<SerialNumberEnity> productDetailList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGETPRODUCTDETAIL", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter ProductId = cmd.Parameters.AddWithValue("@ProductId", id);
                    SqlParameter ProductFlag = cmd.Parameters.AddWithValue("@Flag", Flag);


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            productDetail = new SerialNumberEnity();

                            productDetail.MakeId = Convert.ToInt32(dr["ProductId"]);
                            productDetail.MakeName = dr["ProductName"].ToString();

                            productDetailList.Add(productDetail);

                        }
                        if (isnull) return null;
                        else return productDetailList;
                    }

                }
            }
        }

       
        public List<SerialNumberEnity> GetCreateNewOrderForOkStock(string Flag)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spCreateNewOrderForOkStock", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.GulfNo = dr["GulfNo"].ToString();
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.ProcessorName = dr["ProcessorType"].ToString();
                            serialentity.AvailableQty = Convert.ToInt32(dr["AvailableQty"]);

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<SerialNumberEnity> GetCreateNewOrderDetail(int GulfNo)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spCreateNewOrderForOkStockDetail", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@GulfNo", GulfNo);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.GulfNo = dr["GulfNo"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.ProcessorName = dr["ProcessorType"].ToString();

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public List<SerialNumberEnity> GetSilverStock(string Flag)
        {
            // int i = 0;
            SerialNumberEnity serialentity;
            List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetSilverStock", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter flag = cmd.Parameters.AddWithValue("@Flag", Flag);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            serialentity = new SerialNumberEnity();

                            serialentity.GulfNo = dr["GulfNo"].ToString();
                            serialentity.BatchNo = dr["BatchNo"].ToString();
                            serialentity.MakeName = dr["MakeName"].ToString();
                            serialentity.ModelName = dr["ModelName"].ToString();
                            serialentity.InhouseSerialNo = dr["InhouseSerialNo"].ToString();
                            serialentity.OriginalSerialNo = dr["OriginalSerialNo"].ToString();
                            serialentity.Status = dr["Status"].ToString();

                            serialentityList.Add(serialentity);
                        }
                        if (isnull) return null;
                        else return serialentityList;
                    }

                }
            }
        }

        public int ConvertToSilverStock(List<SerialNumberEnity> entity)
        {
            // int i = 0;
            //SerialNumberEnity serialentity;
            //List<SerialNumberEnity> serialentityList = new List<SerialNumberEnity>();

            DataTable table = ConvertSilverStockListToDataTable(entity);

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spConvertStockToSilver", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();

                    SqlParameter custId = cmd.Parameters.AddWithValue("@tblEmp", table);

                    return (int)cmd.ExecuteScalar();

                }
            }
        }

        static DataTable ConvertSilverStockListToDataTable(List<SerialNumberEnity> list)
        {
            int lineNo = 0;

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("OrderLineNo");
            dt.Columns.Add("InhouseSerialNo");
            dt.Columns.Add("OriginalSerialNo");
           
            DataRow Order;

            // Add rows.
            foreach (var array in list)
            {
                Order = dt.NewRow();
                lineNo = lineNo + 1;

                Order["OrderLineNo"] = lineNo;
                Order["InhouseSerialNo"] = array.InhouseSerialNo;
                Order["OriginalSerialNo"] = array.OriginalSerialNo;

                dt.Rows.Add(Order);
            }
            return dt;
        }








        public List<OrderInvoiceEntity> Getinvoicedetails()
        {
            // int i = 0;
            OrderInvoiceEntity inventity;
            List<OrderInvoiceEntity> invList = new List<OrderInvoiceEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetInvoiceDetails", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            inventity = new OrderInvoiceEntity();
                            inventity.InvOrderNo = Convert.ToInt32(dr["InvOrderno"]);
                            inventity.InvoiceNo = Convert.ToInt32(dr["InvoiceNo"]);
                            inventity.InvoiceType = dr["InvoiceType"].ToString();
                            inventity.CustomerName = dr["CustomerName"].ToString();
                            inventity.InvoiceDate = Convert.ToDateTime(dr["Currentdate"]);
                            inventity.deliverydate = Convert.ToDateTime(dr["DeliveryDate"]);
                            int i = dr.GetOrdinal("ETAdate");
                                if (dr.IsDBNull(i))
                            { inventity.ETADate = DateTime.MinValue; }
                                else
                            { inventity.ETADate = Convert.ToDateTime(dr["ETAdate"]); }
                         
                          
                            inventity.InvoiceAmount = Convert.ToDecimal(dr["Inv_Amt"]);
                            inventity.RecieveAmt = Convert.ToDecimal(dr["RecieveAmt"]);
                            inventity.UploadFileName = dr["UploadFile"].ToString();
                            inventity.PendingDays = Convert.ToInt32(dr["Pendingdays"]);
                            invList.Add(inventity);

                        }
                        if (isnull) return null;
                        else return invList;
                    }

                }
            }
        }



        public List<OrderInvoiceEntity> GetInvReportbyETA()
        {
            // int i = 0;
            OrderInvoiceEntity inventity;
            List<OrderInvoiceEntity> invList = new List<OrderInvoiceEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            inventity = new OrderInvoiceEntity();
                            inventity.InvoiceNo = Convert.ToInt32(dr["Invoiceno"]);
                            inventity.InvoiceType = (dr["InvoiceType"]).ToString();
                            inventity.CustomerName = dr["CustomerName"].ToString();
                            inventity.InvoiceAmount = Convert.ToInt32(dr["InvoiceAmount"]);                       
                            inventity.RecieveAmt = Convert.ToDecimal(dr["RecieveAmt"]);
                            inventity.InvoiceDate = Convert.ToDateTime(dr["Invoicedate"]);
                            inventity.RecivingDate = Convert.ToDateTime(dr["Receiveddate"]);
                            inventity.InvComment = Convert.ToString(dr["Comment"]);
                            inventity.UploadFileName = Convert.ToString(dr["UploadFile"]);
                            invList.Add(inventity);

                        }
                        if (isnull) return null;
                        else return invList;
                    }

                }
            }
        }
          public List<OrderInvoiceEntity> GetInvoiceStatus()
        {
            // int i = 0;
            OrderInvoiceEntity inventity;
            List<OrderInvoiceEntity> invList = new List<OrderInvoiceEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetInvoiceStatus", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();


                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            inventity = new OrderInvoiceEntity();
                            inventity.InvOrderNo = Convert.ToInt32(dr["InvOrderno"]);
                            inventity.InvoiceNo = Convert.ToInt32(dr["Invoiceno"]);
                            inventity.status_id = Convert.ToInt32(dr["Status_id"]);
                            inventity.InvoiceType = (dr["InvoiceType"]).ToString();
                            inventity.CustomerName = dr["CustomerName"].ToString();
                            inventity.InvoiceAmount = Convert.ToInt32(dr["InvoiceAmount"]);                       
                            inventity.RecieveAmt = Convert.ToDecimal(dr["RecieveAmt"]);
                            inventity.InvoiceDate = Convert.ToDateTime(dr["Invoicedate"]);
                            inventity.RecivingDate = Convert.ToDateTime(dr["Receiveddate"]);
                            inventity.InvComment = Convert.ToString(dr["Comment"]);
                            inventity.UploadFileName = Convert.ToString(dr["UploadFile"]);
                            invList.Add(inventity);

                        }
                        if (isnull) return null;
                        else return invList;
                    }

                }
            }
        }
        public List<OrderInvoiceEntity> GetTransactiondetails(string OrderNo)
        {
            // int i = 0;
            OrderInvoiceEntity inventity;
            List<OrderInvoiceEntity> invList = new List<OrderInvoiceEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetTransactionDetails", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlParameter InvOrderNo = cmd.Parameters.AddWithValue("@OrderNo", OrderNo);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            inventity = new OrderInvoiceEntity();
                            inventity.TransactionId = Convert.ToInt32(dr["Transaction_id"]);
                            inventity.InvOrderNo = Convert.ToInt32(dr["InvoiceOrderNo"]);
                            inventity.InvType = dr["Amt_type"].ToString();
                            inventity.RecieveAmt = Convert.ToDecimal(dr["RecievedAmt"]);
                            inventity.AdjustmentValue =Convert.ToDecimal(dr["AdjustedValue"]);
                            inventity.Reciving_Date = dr["RecieveDate"].ToString();
                            inventity.InvComment = dr["ReceivedComment"].ToString();
                            invList.Add(inventity);

                        }
                        if (isnull) return null;
                        else return invList;
                    }

                }
            }
        }
        public List<OrderInvoiceEntity> GetinvoiceByUser(string username)
        {
            // int i = 0;
            OrderInvoiceEntity inventity;
            List<OrderInvoiceEntity> invList = new List<OrderInvoiceEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetInvoiceDetailsbyUserName", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlParameter UploadType = cmd.Parameters.AddWithValue("@USERNAME", username);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            inventity = new OrderInvoiceEntity();
                            inventity.Emp_id = Convert.ToInt32(dr["Emp_id"]);
                            invList.Add(inventity);

                        }
                        if (isnull) return null;
                        else return invList;
                    }

                }
            }
        }
        public List<OrderInvoiceEntity> GetCommentbyRoles(string username)
        {
            // int i = 0;
            OrderInvoiceEntity inventity;
            List<OrderInvoiceEntity> invList = new List<OrderInvoiceEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("spGetCommentbyRoles", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlParameter UploadType = cmd.Parameters.AddWithValue("@USERNAME", username);

                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            inventity = new OrderInvoiceEntity();
                            inventity.Emp_id = Convert.ToInt32(dr["Emp_id"]);
                            invList.Add(inventity);

                        }
                        if (isnull) return null;
                        else return invList;
                    }

                }
            }
        }

        public List<OrderInvoiceEntity> CheckReceiveAmt(int ReceiveOrderId, decimal AdjustedAmt, decimal ReceiveAmt)
        {
            // int i = 0;
            OrderInvoiceEntity inventity;
            List<OrderInvoiceEntity> invList = new List<OrderInvoiceEntity>();

            using (SqlConnection myConnection = new SqlConnection(cs))
            {

                using (SqlCommand cmd = new SqlCommand("SpCheckReceivedAmt", myConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    SqlParameter ReceivedAmt = cmd.Parameters.AddWithValue("@ReceiveAmt", ReceiveAmt);
                    SqlParameter Adjustedvalue = cmd.Parameters.AddWithValue("@AdjustedValue", AdjustedAmt);
                    SqlParameter Invordeno = cmd.Parameters.AddWithValue("@InvOrderNo", ReceiveOrderId);
                    bool isnull = true;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            isnull = false;
                            inventity = new OrderInvoiceEntity();
                           
                            inventity.ReceivedValue = Convert.ToInt32(dr["ReceivedAmt"]);
                            invList.Add(inventity);

                        }
                        if (isnull) return null;
                        else return invList;
                    }

                }
            }
        }
    }
}
