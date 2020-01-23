using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace A2C.BusinessEntity
{
    public class MasterSerialNumberEntity
    {
        public MasterSerialNumberEntity()
        {
            new List<MasterSerialNumberEntity>();
        }

        public List<SerialNumberEnity> serialNumberEntity { get; set; }
        public List<OrderInvoiceEntity> orderInvoiceEntity { get; set; }

    }
    public class SerialNumberEnity
    {
        //public int SerialId { get; set; }
        //public int RecordId { get; set; }
        public int ResultType { get; set; }
        public string GulfNo { get; set; }
        public int PurchaseQty { get; set; }
        public int ReceivedQty { get; set; }
        public string OrderNo { get; set; }
        public int OrderId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int MakeId { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
        public int ModelId { get; set; }
        public string BatchNo { get; set; }
        public string InhouseSerialNo { get; set; }
        public string OriginalSerialNo { get; set; }
        public string SCreatedDate { get; set; }
        public string Comment { get; set; }
        public string IssueName { get; set; }
        public string PendingScrapReason { get; set; }
        public string Status { get; set; }
        public int ProcessorId { get; set; }
        public string ProcessorName { get; set; }
        public int AvailableQty { get; set; }
        public decimal PurchasePrice { get; set; }
        public string PurchaseDate { get; set; }
        public string Category { get; set; }
        public string Grade { get; set; }
        public int IntransitQty { get; set; }
        public int UploadedQty { get; set; }
        public string InvoiceNo { get; set; }
        public string SoldPrice { get; set; }
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public string SoldDate { get; set; }
        public string Description { get; set; }
        public decimal TotalCostN { get; set; }
        public int Disputed { get; set; }
        public string Invstatus { get; set; }
    }

    public class OrderInvoiceEntity : SerialNumberEnity
    {
        public int InvoiceNo { get; set; }
        public int status_id { get; set; }
        public int InvOrderNo { get; set; }
        public int Emp_id { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string InvoiceComment { get; set; }
        public DateTime deliverydate { get; set; }
        public decimal PendingAmount { get; set; }
        public decimal RecieveAmt { get; set; }
        public string InvType { get; set; }
        public string InvoiceType { get; set; }
        public string ChequeNo { get; set; }
        public string Chequedate { get; set; }
        public DateTime RecivingDate { get; set; }
        public string Reciving_Date { get; set; }
        public decimal AdjustmentValue { get; set; }
        public string InvComment { get; set; }
        public int PendingDays { get; set; }
        public int ReceivedValue { get; set; }
        public int TransactionId { get; set; }
        public string UploadFileName { get; set; }
        public DateTime ETADate { get; set; }
        public int ETAStatus{ get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

    }

    public class ImageUpload
        {
          public int id { get; set; }
        public string ImageFile { get; set; }
        public string ImageType { get; set; }
        public string path { get; set; }
    }

}
