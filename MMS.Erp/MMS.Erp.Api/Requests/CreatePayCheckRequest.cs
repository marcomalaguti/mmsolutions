namespace MMS.Erp.Api.Requests;

public class CreatePayCheckRequest
{
    public decimal SalaryAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public bool? IsSettled { get; set; }
    public DateTime? Date { get; set; }
    public IFormFile? PaySlipPdf { get; set; }
    public IFormFile? F24Pdf { get; set; }
}
