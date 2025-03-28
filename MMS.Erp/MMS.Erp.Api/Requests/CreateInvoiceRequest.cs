namespace MMS.Erp.Api.Requests;
using System;

public class CreateInvoiceRequest
{
    public int SequenceNumber { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public int? VAT { get; set; }
    public bool? DutyStamp { get; set; }
}
