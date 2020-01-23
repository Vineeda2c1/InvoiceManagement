using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManagementNew.Models
{
    public class MasterSerialNumberModel
    {
    }
    public class InvoiceDetailsModel
        {
        public int InvOrderNo { get; set; }
        public int Status_id { get; set; }
        public int InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal PendingAmount { get; set; }
        public DateTime deliverydate { get; set; }
        public decimal RecieveAmt { get; set; }
        public string InvType { get; set; }
        public string InvoiceType { get; set; }
        public decimal ChequeNo { get; set; }
        public DateTime Chequedate { get; set; }
        public DateTime RecivingDate { get; set; }
        public DateTime ETADate { get; set; }
        public decimal AdjustmentValue { get; set; }
        public string InvComment { get; set; }
        public int PendingDays { get; set; }
        public string  UploadFile { get; set; }
        public string Icon { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
    }
    public class ImageUploadModel
    {

        public int imageId { get; set; }
        public string Title { get; set; }
        public string ImageFile { get; set; }
        public string ImageType { get; set; }
        public HttpPostedFileBase UploadImage { get; set; }
    }
  
}