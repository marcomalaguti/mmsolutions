namespace MMS.Erp.Application.DTOs;
public class InvoiceDto
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public int? VAT { get; set; }
    public decimal DutyStamp { get; set; }
    public bool IsPaid { get; set; }
}
