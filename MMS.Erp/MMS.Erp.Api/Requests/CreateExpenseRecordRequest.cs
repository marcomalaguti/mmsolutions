namespace MMS.Erp.Api.Requests;

using MMS.Erp.Domain.Enums;

public class CreateExpenseRecordRequest
{
    public ExpenseRecordTypeEnum TypeId { get; set; }
    public string? Description { get; set; }
    public int? TraveledKm { get; set; }
    public decimal? KmReimbursement { get; set; }
    public decimal? Tolls { get; set; }
    public decimal? Meals { get; set; }
    public decimal? Accommodation { get; set; }
    public decimal? LumpSum { get; set; }
    public IFormFile? Attachment { get; set; }
}
